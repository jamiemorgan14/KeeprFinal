<template>
  <div class="navbar px-0 py-0 mb-2">
    <nav class="navbar navbar-expand-lg">
      <h2 class="my-brand" @click="goHome">Keepr</h2>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav"
        aria-expanded="false" aria-label="Toggle navigation">
        <i class="fas fa-hamburger fa-2x"></i>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
          <li class="nav-item active">
            <a class="nav-link" @click="goHome">Home<span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" @click="showModal">My Vaults</a>
          </li>
          <li class="nav-item" v-if="user.id">
            <a class="nav-link" @click="goToDash">Dashboard</a>
          </li>

          <!-- <li class="nav-item">
            <a class="nav-link disabled" href="#">Disabled</a>
          </li> -->
          <li class="nav-item">
            <a v-if="user.id" class="nav-link" @click="logout">Logout</a>
            <a v-if="!user.id" class="nav-link" @click="login">Login</a>
          </li>
        </ul>
      </div>
    </nav>

    <transition name="modal">
      <AllVaultModal v-if="isModalVisible" @closemodal="closemodal"></AllVaultModal>
    </transition>
    <transition name="modal">
      <LoginModal v-if="userLogin" @closemodal="closemodal"></LoginModal>
    </transition>

  </div>
</template>

<script>
  import AllVaultModal from '@/components/AllVaultModal.vue'
  import Modal from '@/components/Modal.vue'
  import LoginModal from '@/components/LoginModal.vue'

  export default {
    name: "navbar",
    props: [],
    mounted() {
      //checks for valid session
      this.$store.dispatch("authenticate");
    },
    data() {
      return {
        isModalVisible: false,
        userLogin: false
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      showModal() {
        if (this.user.id) {
          this.isModalVisible = true
        } else {
          alert('sign in to create and view vaults')
        }
      },
      closemodal() {
        this.isModalVisible = false
        this.userLogin = false
      },
      goToDash() {
        this.$router.push({ name: 'dashboard' })
      },
      logout() {
        this.$store.state.userKeeps = []
        this.$store.state.vaults = []
        this.$store.state.activeKeep = {}
        this.$store.state.activeVault = {}
        this.$store.state.vaultKeeps = []
        this.$store.dispatch('logout')
      },
      login() {
        this.userLogin = true;
      },
      goHome() {
        this.$router.push({ name: 'home' })
      }
    },
    components: {
      AllVaultModal,
      Modal,
      LoginModal
    }
  }
</script>

<style scoped>
  .navbar {
    width: 100%;
    position: static;
    background-color: #ff5959
  }

  .fa-hamburger {
    color: #facf5a
  }

  .nav-item {
    color: #233142;
    text-shadow: .5px .5px rgba(255, 255, 255, 0.582)
  }

  .my-brand {
    color: #facf5a;
    margin-right: 5px;
    display: inline-block;
    text-shadow: .5px .5px rgba(255, 255, 255, 0.589)
  }

  .modal-enter,
  .modal-leave-active {
    opacity: 0;
    z-index: 500
  }

  .modal-enter-active,
  .modal-leave-active {
    transition: opacity .45s ease;
    z-index: 500
  }
</style>