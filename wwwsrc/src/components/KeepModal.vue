<template>
  <div class="Keep">
    <modal @closemodal="$emit('closemodal')" v-if="currentKeep">
      <span slot="header"></span>
      <span slot="content">
        <div class="card text-center mx-5 mt-5">
          <div class="card-header">
            {{currentKeep.name}}
          </div>
          <div class="card-body">
            <p class="card-text">{{currentKeep.description}}</p>
            <img :src="currentKeep.img" alt="">
          </div>
          <div v-if="this.$store.state.user.id" class="card-footer text-muted">
            <div class="d-flex justify-content-between">
              <i class="fas fa-2x fa-plus-square"></i>
              <i class="far fa-2x fa-trash-alt"></i>
              <!-- Example split danger button -->
              <div class="btn-group">
                <button type="button" class="btn btn-danger" disabled>Add to Vault</button>
                <button type="button" class="btn btn-danger dropdown-toggle dropdown-toggle-split" data-toggle="dropdown"
                  aria-haspopup="true" aria-expanded="false">
                  <span class="sr-only">Toggle Dropdown</span>
                </button>
                <div class="dropdown-menu">
                  <a v-for="vault in vaults" @click="addVaultKeep(chosenKeep, vault.id)" class="dropdown-item" href="#">{{vault.name}}</a>
                  <a class="dropdown-item" href="#">Nevermind!</a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </span>
    </modal>
  </div>
</template>

<script>
  import Modal from '@/components/Modal.vue'
  export default {
    name: "Keep",
    props: ["chosenKeep"],
    data() {
      return {
      }
    },
    created() {
      this.$store.dispatch('getActiveKeep', this.chosenKeep.id)
      this.$store.dispatch('getVaults')
    },
    updated() {

    },
    destroyed() {
      this.$store.dispatch('getActiveKeep', '')
      this.currentKeep.views++
      this.$store.dispatch('editKeep', this.currentKeep)
    },
    computed: {
      currentKeep() {
        return this.$store.state.activeKeep
      },
      vaults() {
        return this.$store.state.vaults
      },
      goHome() {

      }
    },
    methods: {
      addVaultKeep(chosenKeep, vaultId) {
        chosenKeep.keeps++
        this.$store.dispatch('editKeep', chosenKeep)
        chosenKeep.vaultId = vaultId
        this.$store.dispatch('createVaultKeep', { keepId: chosenKeep.id, vaultId: vaultId })
        this.$emit('closemodal')
      }
    },
    components: {
      Modal
    }
  }
</script>
<style scoped>
  img {
    max-width: 70%;
    max-height: 500px
  }
</style>