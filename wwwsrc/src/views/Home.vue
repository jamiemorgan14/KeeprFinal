<template>
  <div class="home">
    <navbar></navbar>
    <CreateKeep v-if="showModal"></CreateKeep>
    <div class="container-fluid">
      <h1>Welcome Home</h1>
      <div class="row">
        <div @click="viewKeep(keep.id)" v-for="keep in keeps" class="card col-6 col-sm-4 col-md-2 my-3 py-2">
          <i class="fas fa-times mb-2" @click="deleteKeep(keep.id)"></i>
          <img class="card-img-top" :src="keep.img" alt="Card image cap">
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
          </div>
        </div>
      </div>
      <i class="fas fa-4x fa-plus-square" @click="showModal = true"></i>
    </div>
  </div>
</template>

<script>
  import CreateKeep from '@/components/CreateKeepModal.vue'
  import Navbar from '@/components/Navbar.vue'

  export default {
    name: "home",
    data() {
      return {
        showModal: false
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
      closeModal() {
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
      CreateKeep
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
</style>