<template>
  <div class="AllVaults">
    <div class="row">
      <div v-for="vault in allVaults" class="card col-sm-12 col-md-5 mx-3">
        <div class="d-flex justify-content-between mx-2">
          <i data-dismiss="modal" class="far fa-eye" @click="goToVault(vault.id)"></i>
          <i class="fas fa-times" @click="deleteVault(vault.id)"></i>
        </div>
        <div class="card-body">
          <h5 class="card-title">{{vault.name}}</h5>
          <p class="card-text">{{vault.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "AllVaults",
    props: [],
    mounted() {
      this.$store.dispatch('getVaults')
    },
    data() {
      return {}
    },
    computed: {
      allVaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      goToVault(id) {
        this.$router.push('vaults/' + id)
      },
      deleteVault(id) {
        debugger
        this.$store.dispatch('deleteVault', id)
      }
    },
    components: {}
  }
</script>

<style scoped>
  .card {
    padding: 0px;
  }
</style>