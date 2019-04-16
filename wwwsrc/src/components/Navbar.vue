<template>
  <div class="navbar px-0 py-0 mb-2">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">Keepr</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav"
        aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
          <li class="nav-item active">
            <a class="nav-link" href="home">Home <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" @click="showModal">My Vaults</a>
          </li>

          <!-- <li class="nav-item">
            <a class="nav-link disabled" href="#">Disabled</a>
          </li> -->
          <li class="nav-item">
            <a class="nav-link" href="#">Logout</a>
          </li>
        </ul>
      </div>
    </nav>

    <transition name="modal">
      <AllVaultModal v-if="isModalVisible" @closemodal="closemodal"></AllVaultModal>
    </transition>
  </div>
</template>

<script>
  import AllVaultModal from '@/components/AllVaultModal.vue'
  import Modal from '@/components/Modal.vue'

  export default {
    name: "navbar",
    props: [],
    data() {
      return {
        isModalVisible: false
      }
    },
    computed: {

    },
    methods: {
      showModal() {
        this.isModalVisible = true
      },
      closemodal() {
        this.isModalVisible = false
      }
    },
    components: {
      AllVaultModal,
      Modal
    }
  }
</script>

<style scoped>
  .navbar {
    width: 100%;
    position: static;
  }

  .modal-enter,
  .modal-leave-active {
    opacity: 0;
    z-index: 5
  }

  .modal-enter-active,
  .modal-leave-active {
    transition: opacity .45s ease;
    z-index: 5;
  }
</style>