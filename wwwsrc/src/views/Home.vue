<template>
  <div class="home">
    <CreateKeep></CreateKeep>
    <navbar></navbar>
    <div class="container-fluid">
      <h1>Welcome Home</h1>
      <div class="row">
        <div v-for="keep in keeps" class="card col-6 col-sm-4 col-md-2 my-3 py-2">
          <img class="card-img-top" :src="keep.img" alt="Card image cap">
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
          </div>
        </div>
      </div>
      <i class="fas fa-4x fa-plus-square" data-toggle="modal" data-target="#mainModal"></i>
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
      }
    },
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
      this.$store.dispatch('getKeeps')
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
</style>