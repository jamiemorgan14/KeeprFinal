<template>
  <div class="dashboard">
    <navbar></navbar>
    <div class="container">
      <div class="row">
        <div class="col-12 text-center">
          <h1>Your Dashboard</h1>
        </div>
      </div>
      <div class="row">
        <div class="col-6 myKeeps">
          <h2>Your Keeps</h2>
          <div class="row">
            <div v-for="keep in keeps" class="card col-sm-12 col-lg-4">
              <div class="d-flex justify-content-around">
                <i class="fas fa-times mb-2" @click.stop="deleteKeep(keep.id)"></i>
                <i class="far fa-edit" @click="showEditModal(keep)"></i>
              </div>
              <img class="card-img-top" :src="keep.img" alt="Card image cap">
              <div class="card-body">
                <h5 class="card-title">{{keep.name}}</h5>
                <p class="card-text">{{keep.description}}</p>
                <div>
                  <i class="fas fa-user-secret" v-if="keep.isPrivate"></i>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-6 myVaults">
          <h2>Your Vaults</h2>
          <AllVaults></AllVaults>
        </div>
      </div>
    </div>


    <transition name="modal">
      <modal v-if="showEdit" @closemodal="closemodal">
        <span slot="header">
          Edit this keep
        </span>

        <span slot="content">
          <form @submit.prevent="editKeep(editedKeep)">
            <div class="form-group">
              <label for="keepName">Keep Name</label>
              <input v-model="editedKeep.name" type="text" class="form-control" id="keepName" placeholder="Keep Name">
            </div>
            <div class="form-group">
              <label for="vaultDescription">Keep Description</label>
              <input v-model="editedKeep.description" type="text" class="form-control" id="keepDescription" placeholder="Keep Description">
            </div>
            <div class="form-group">
              <label for="vaultImage">Keep Image</label>
              <input v-model="editedKeep.img" type="text" class="form-control" id="keepImage" placeholder="Upload an Image URL">
            </div>
            <div class="form-check">
              <input v-if="editedKeep.isPrivate" type="checkbox" class="form-check-input" id="private" @click="flipPrivate"
                checked>
              <input v-else type="checkbox" class="form-check-input" id="private" @click="flipPrivate">
              <label class="form-check-label" for="private">Mark as Private</label>
            </div>
            <button type="submit" class="btn btn-primary" @click="$emit('closemodal')">Submit Edit</button>
          </form>
        </span>
      </modal>
    </transition>
  </div>
</template>

<script>
  import Navbar from '@/components/Navbar.vue'
  import AllVaults from '@/components/AllVaults.vue'
  import Modal from '@/components/Modal.vue'
  export default {
    name: "dashboard",
    props: [],
    data() {
      return {
        showEdit: false,
        editedKeep: {
          name: '',
          description: '',
          img: '',
          userId: this.$store.state.user.id,
          isPrivate: false
        }
      }
    },
    created() {
      this.$store.dispatch('getKeepsByUser')
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      deleteKeep(id) {
        this.$store.dispatch('deleteKeep', id)
      },
      showEditModal(keep) {
        this.editedKeep = keep
        this.showEdit = true;
      },
      closemodal() {
        this.showEdit = false
        this.editedKeep = {}
      },
      flipPrivate() {
        if (this.editedKeep.isPrivate) {
          this.editedKeep.isPrivate = false
        } else {
          this.editedKeep.isPrivate = true
        }
        console.log(this.editedKeep.isPrivate);
      },
      editKeep(editedKeep) {
        this.$store.dispatch('editKeep', editedKeep)
      }
    },
    components: {
      Navbar,
      AllVaults,
      Modal
    }
  }
</script>

<style scoped>
  .modal-enter,
  .modal-leave-active {
    opacity: 0;
  }

  .modal-enter-active,
  .modal-leave-active {
    transition: opacity .45s ease
  }
</style>