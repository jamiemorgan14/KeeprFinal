<template>
  <div class="allVaultModal">
    <modal v-if="!showEditForm" @closemodal="$emit('closemodal')">
      <span slot="header">Your Vaults</span>
      <span slot="content">
        <allVaults></allVaults>
      </span>
      <span slot="icon">
        <i class="fas fa-plus-square fa-3x" @click="showEditForm = true"></i>
      </span>
    </modal>

    <modal v-if="showEditForm" @closemodal="('closemodal')">
      <span slot="header">Create a Vault</span>
      <span slot="content">
        <form @submit.prevent="createVault">
          <div class="form-group">
            <label for="vaultName">Vault Name</label>
            <input v-model="newVault.name" type="text" class="form-control" id="vaultName" placeholder="Vault Name">
          </div>
          <div class="form-group">
            <label for="vaultDescription">Vault Description</label>
            <input v-model="newVault.description" type="text" class="form-control" id="vaultDescription" placeholder="Vault Description">
          </div>
          <button type="submit" class="btn btn-primary">Create Vault</button>
        </form>
      </span>
      <span slot="icon">
        <i class="fas fa-3x fa-undo-alt" @click="showEditForm = false"></i>
      </span>
    </modal>

  </div>
</template>

<script>
  import AllVaults from '@/components/AllVaults.vue'
  import Modal from '@/components/Modal.vue'

  export default {
    name: "allVaultModal",
    props: [],
    data() {
      return {
        showEditForm: false,
        newVault: {
          name: '',
          description: '',
          userId: this.$store.state.user.id
        }
      }
    },
    updated() {
    },
    computed: {},
    methods: {
      createVault() {
        this.$store.dispatch('createVault', this.newVault)
        this.showEditForm = false
      }
    },
    components: {
      AllVaults,
      Modal
    }
  }
</script>

<style>
</style>