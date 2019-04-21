<template>
  <div class="Vault">
    <navbar></navbar>
    <div class="container">
      <h1 v-if="currentVault" class="header">You're in {{currentVault.name}}</h1>
      <h4 v-if="currentVault" class="sub-titles">{{currentVault.description}}</h4>
      <div class="row">
        <div class="card-columns">
          <div v-for="keep in vaultKeeps" class="card">
            <i class="fas fa-times mb-2" @click.stop="deleteVaultKeep(keep.id)"></i>
            <img class="card-img-top" :src="keep.img" alt="Card image cap">
            <div class="card-body">
              <h5 class="card-title">{{keep.name}}</h5>
              <p class="card-text">{{keep.description}}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import store from '../store.js'
  import Navbar from '@/components/Navbar.vue'
  export default {
    name: "Vault",
    props: [],
    created() {
      this.$store.dispatch('getActiveVault', this.$route.params.vaultId)
      this.$store.dispatch('getVaultKeeps', this.$route.params.vaultId)
    },
    watch: {
      $route: function (to, from) {
        this.$store.dispatch('getActiveVault', this.$route.params.vaultId)
        this.$store.dispatch('getVaultKeeps', this.$route.params.vaultId)
      }
    },
    data() {
      return {
      }
    },
    computed: {
      currentVault() {
        return this.$store.state.activeVault
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {
      deleteVaultKeep(keepId) {
        this.$store.dispatch('deleteVaultKeep', { keepId: keepId, vaultId: this.currentVault.id });
      }
    },
    components: {
      Navbar
    }
  }
</script>

<style scoped>
  .Vault {
    min-height: 100vh
  }

  .header {
    color: #ff5959
  }

  .sub-titles {
    color: #4f9da6
  }
</style>