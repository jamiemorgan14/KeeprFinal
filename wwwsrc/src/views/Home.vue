<template>
  <div class="home">
    <navbar></navbar>
    <div class="container">
      <h1 class="welcome my-3 text-capitalize">Welcome Home {{user.username}}</h1>
      <div class="row" @mouseover="clickableCard = true" @mouseleave="clickableCard = false">
        <div class="card-columns">
          <div @click="viewKeep(keep)" v-for="keep in keeps" class="card w-100" :class="{'clickable-card': clickableCard}">
            <img class="card-img-top" :src="keep.img" alt="Card image cap">
            <div class="card-body">
              <h5 class="card-title">{{keep.name}}</h5>
              <p class="card-text">{{keep.description}}</p>
            </div>
            <div class="d-flex justify-content-around icon-bg py-2">
              <i class="far fa-eye card-icon">: {{keep.views}}</i>
              <i class="fas fa-snowboarding card-icon">: {{keep.keeps}}</i>
              <i class="fas fa-share-alt-square card-icon">: {{keep.shares}}</i>
            </div>
          </div>
        </div>
      </div>
    </div>
    <i class="fas fa-4x fa-plus-square" @click="showVaultsModal = true" v-if="user.id"></i>
    <transition name="modal">
      <CreateKeep v-if="showVaultsModal" @closemodal="closemodal"></CreateKeep>
      <Keep :chosenKeep="chosenKeep" v-if="showKeepModal" @closemodal="closemodal"></Keep>
    </transition>
  </div>
</template>

<script>
  import CreateKeep from '@/components/CreateKeepModal.vue'
  import Navbar from '@/components/Navbar.vue'
  import Modal from '@/components/Modal.vue'
  import Keep from '@/components/KeepModal.vue'

  export default {
    name: "home",
    data() {
      return {
        showVaultsModal: false,
        showKeepModal: false,
        clickableCard: false,
        chosenKeep: {}
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "home" });
      }
      this.$store.dispatch('getKeeps');
    },
    methods: {
      viewKeep(keep) {
        this.showKeepModal = true
        this.chosenKeep = keep
      },
      closemodal() {
        this.showVaultsModal = false
        this.showKeepModal = false
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps;
      },
      user() {
        return this.$store.state.user
      }
    },
    components: {
      Navbar,
      CreateKeep,
      Modal,
      Keep
    }
  };
</script>

<style scoped>
  .welcome {
    color: #facf5a
  }

  .home {
    min-height: 100vh
  }

  .card-icon {
    color: #ff5959
  }

  .fa-plus-square {
    position: fixed;
    bottom: 3%;
    right: 3%;
    color: #facf5a
  }

  .card {
    display: inline-block
  }

  .card-columns {
    max-width: 100%
  }

  @media (min-width: 200px) {
    .card-columns {
      -webkit-column-count: 2;
      -moz-column-count: 2;
      column-count: 2;
    }
  }

  @media (min-width: 34em) {
    .card-columns {
      -webkit-column-count: 2;
      -moz-column-count: 2;
      column-count: 2;
    }
  }

  @media (min-width: 48em) {
    .card-columns {
      -webkit-column-count: 3;
      -moz-column-count: 3;
      column-count: 3;
    }
  }

  @media (min-width: 62em) {
    .card-columns {
      -webkit-column-count: 5;
      -moz-column-count: 5;
      column-count: 5;
    }
  }

  @media (min-width: 75em) {
    .card-columns {
      -webkit-column-count: 5;
      -moz-column-count: 5;
      column-count: 5;
    }
  }

  .modal-enter,
  .modal-leave-active {
    opacity: 0;
  }

  .modal-enter-active,
  .modal-leave-active {
    transition: opacity .45s ease;
  }
</style>