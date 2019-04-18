<template>
  <div class="dashboard">
    <navbar></navbar>
    <div class="container">
      <div class="row">
        <div class="col-12 text-center">
          <h1 class="dash">Your Dashboard</h1>
        </div>
      </div>
      <div class="row">
        <div class="col-6 myKeeps">
          <h2 class="sub-title text-left">Your Keeps</h2>
          <hr>
          <div class="row">
            <div v-for="keep in keeps" class="card col-sm-12 col-lg-3 my-2 mx-1" @click="showOneKeep(keep)">
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
          <h2 class="sub-title text-left">Your Vaults</h2>
          <hr>
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
    <transition name="modal">
      <CreateKeep v-if="showVaultsModal" @closemodal="closemodal"></CreateKeep>
      <Keep :chosenKeep="chosenKeep" v-if="showKeepModal" @closemodal="closemodal"></Keep>
    </transition>
    <i class="fas fa-4x fa-plus-square" @click="showVaultsModal = true" v-if="user.id"></i>
  </div>
</template>

<script>
  import Navbar from '@/components/Navbar.vue'
  import AllVaults from '@/components/AllVaults.vue'
  import Modal from '@/components/Modal.vue'
  import Keep from '@/components/KeepModal.vue'
  import CreateKeep from '@/components/CreateKeepModal.vue'

  export default {
    name: "dashboard",
    props: [],
    data() {
      return {
        showEdit: false,
        showVaultsModal: false,
        showKeepModal: false,
        editedKeep: {
          name: '',
          description: '',
          img: '',
          userId: this.$store.state.user.id,
          isPrivate: false
        },
        chosenKeep: {}
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
        this.$store.dispatch('getKeepsByUser', id)
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
      },
      showOneKeep(keep) {
        this.chosenKeep = keep
        this.showKeepModal = true
      },
      closemodal() {
        this.showKeepModal = false
        this.showVaultsModal = false
      }

    },
    components: {
      Navbar,
      AllVaults,
      Modal,
      CreateKeep,
      Keep
    }
  }
</script>

<style scoped>
  hr {
    background-color: #4f9da6;
    width: 60%;
    margin-left: 0
  }

  .dash {
    color: #ff5959
  }

  .sub-title {
    color: #facf5a
  }

  .modal-enter,
  .modal-leave-active {
    opacity: 0;
  }

  .modal-enter-active,
  .modal-leave-active {
    transition: opacity .45s ease
  }

  .dashboard {
    min-height: 100vh
  }

  .fa-plus-square {
    position: fixed;
    bottom: 3%;
    right: 3%;
    color: #facf5a
  }
</style>