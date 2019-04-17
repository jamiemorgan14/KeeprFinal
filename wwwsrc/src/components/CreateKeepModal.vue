<template>
  <div class="CreateKeep">
    <modal @closemodal="$emit('closemodal')" v-if="!createVaultForm">
      <span slot="header">Create a New Keep
        <button class="btn btn-info" @click="createVaultForm = true">Create a vault</button>
      </span>

      <span slot="content">
        <form @submit.prevent="createKeep">
          <div class="form-group">
            <label for="keepName">Keep Name</label>
            <input v-model="newKeep.name" type="text" class="form-control" id="keepName" placeholder="Keep Name">
          </div>
          <div class="form-group">
            <label for="vaultDescription">Keep Description</label>
            <input v-model="newKeep.description" type="text" class="form-control" id="keepDescription" placeholder="Keep Description">
          </div>
          <div class="form-group">
            <label for="vaultImage">Keep Image</label>
            <input v-model="newKeep.img" type="text" class="form-control" id="keepImage" placeholder="Upload an Image URL">
          </div>
          <div class="form-check">
            <input type="checkbox" class="form-check-input" id="private" @click="flipPrivate">
            <label class="form-check-label" for="private">Mark as Private</label>
          </div>
          <button type="submit" class="btn btn-primary" @click="$emit('closemodal')">Create Keep</button>
        </form>
      </span>
    </modal>

    <modal v-if="createVaultForm" @closemodal="$emit('closemodal')">
      <span slot="header">Create a Vault
        <button class="btn btn-info" @click="createVaultForm = false">Create Keep</button>
      </span>
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
  import Modal from '@/components/Modal.vue'

  export default {
    name: "CreateKeep",
    props: [],
    data() {
      return {
        newKeep: {
          name: '',
          description: '',
          img: '',
          userId: this.$store.state.user.id,
          isPrivate: false
        },
        createVaultForm: false,
        newVault: {
          name: '',
          description: ''
        }
      }
    },
    computed: {},
    methods: {
      createKeep() {
        this.$store.dispatch('createKeep', this.newKeep)
      },
      createVault() {
        this.$store.dispatch('createVault', this.newVault)
        this.showEditForm = false
      },
      flipPrivate() {
        if (this.newKeep.isPrivate) {
          this.newKeep.isPrivate = false
        } else {
          this.newKeep.isPrivate = true
        }
        console.log(this.newKeep.isPrivate);

      }
    },
    components: {
      Modal
    }
  }
</script>

<style scoped>
</style>