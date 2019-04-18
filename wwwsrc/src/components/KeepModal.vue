<template>
  <div class="Keep">
    <modal @closemodal="$emit('closemodal')" v-if="currentKeep">
      <span slot="header">{{currentKeep.name}}
        <hr>
        {{currentKeep.description}}
      </span>
      <span slot="content">
        <div class="text-center mx-5 mb-2">
          <div class="card-body">
            <img :src="currentKeep.img" alt="">
          </div>
          <hr>
          <div v-if="this.$store.state.user.id">
            <div class="d-flex justify-content-between">
              <i class="fas fa-plus-square"></i>
              <i class="far fa-trash-alt"></i>
              <i class="fas fa-piggy-bank" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"></i>
              <!-- Example split danger button -->

              <div class="dropdown-menu">
                <a v-for="vault in vaults" @click="addVaultKeep(chosenKeep, vault.id)" class="dropdown-item" href="#">{{vault.name}}</a>
                <a class="dropdown-item" href="#">Nevermind!</a>
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