<template>
  <div class="CreateKeep">
    <modal>
      <span slot="header">Create a New Keep</span>
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
            <input type="checkbox" class="form-check-input" id="private">
            <label class="form-check-label" for="private">Mark as Private</label>
          </div>
          <button type="submit" class="btn btn-primary">Create Keep</button>
        </form>
      </span>
      <span slot="icon">icon</span>
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
          userId: this.$store.state.user.id
        }
      }
    },
    computed: {},
    methods: {
      createKeep() {
        this.$store.dispatch('createKeep', this.newKeep)
      }
    },
    components: {
      Modal
    }
  }
</script>