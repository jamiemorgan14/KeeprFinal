<template>
  <div class="Vault">
    <navbar></navbar>
    <div class="container">
      <h1 v-if="currentVault">You're in {{currentVault.name}}</h1>
      <h4 v-if="currentVault">{{currentVault.description}}</h4>
      <div class="row">
        <div class="card-columns">
          <div v-for="keep in vaultKeeps" class="card">
            <i class="fas fa-times mb-2" @click.stop="deleteKeep(keep.id)"></i>
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
  import Navbar from '@/components/Navbar.vue'
  export default {
    name: "Vault",
    props: [],
    created() {
      this.$store.dispatch('getVaults')
      this.$store.dispatch('getVaultKeeps', this.$route.params.vaultId)
    },
    data() {
      return {}
    },
    computed: {
      currentVault() {
        return this.$store.state.vaults.find(v => v.id == this.$route.params.vaultId)
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {},
    components: {
      Navbar
    }
  }
</script>