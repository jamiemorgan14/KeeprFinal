<template>
  <div class="home">
    <navbar></navbar>
    <transition name="modal">
      <CreateKeep v-if="showModal" @closemodal="closemodal"></CreateKeep>
    </transition>
    <div class="container">
      <h1>Welcome Home</h1>
      <div class="row" @mouseover="clickableCard = true" @mouseleave="clickableCard = false">
        <div class="card-columns">
          <div @click="viewKeep(keep.id)" v-for="keep in keeps" class="card" :class="{'clickable-card': clickableCard}">
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
    <i class="fas fa-4x fa-plus-square" @click="showModal = true"></i>
  </div>
</template>

<script>
  import CreateKeep from '@/components/CreateKeepModal.vue'
  import Navbar from '@/components/Navbar.vue'
  import Modal from '@/components/Modal.vue'

  export default {
    name: "home",
    data() {
      return {
        showModal: false,
        clickableCard: false
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      this.$store.dispatch('getKeeps')
    },
    methods: {
      viewKeep(id) {
        this.$router.push('keeps/' + id)
      },
      deleteKeep(id) {
        this.$store.dispatch('deleteKeep', id)
      },
      closemodal() {
        this.showModal = false
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps;
      }
    },
    components: {
      Navbar,
      CreateKeep,
      Modal
    }
  };
</script>

<style scoped>
  .fa-plus-square {
    position: fixed;
    bottom: 3%;
    right: 3%
  }

  .card {
    z-index: -1
  }

  .clickable-card {
    z-index: 1
  }

  .card-columns {
    column-count: 5
  }

  .modal-enter,
  .modal-leave-active {
    opacity: 0;
  }

  .modal-enter-active,
  .modal-leave-active {
    transition: opacity .45s ease
  }
</style>