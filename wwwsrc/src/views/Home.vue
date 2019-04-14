<template>
  <div class="home">
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
    </div>
  </div>
</template>

<script>
  import Navbar from '@/components/Navbar.vue'

  export default {
    name: "home",
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
      Navbar
    }
  };
</script>

<style>
</style>