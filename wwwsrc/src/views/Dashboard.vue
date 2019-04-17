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
            <div v-for="keep in keeps" class="card col-4">
              <i class="fas fa-times mb-2" @click.stop="deleteKeep(keep.id)"></i>
              <img class="card-img-top" :src="keep.img" alt="Card image cap">
              <div class="card-body">
                <h5 class="card-title">{{keep.name}}</h5>
                <p class="card-text">{{keep.description}}</p>
                <i class="fas fa-user-secret" v-if="keep.isPrivate"></i>
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
  </div>
</template>

<script>
  import Navbar from '@/components/Navbar.vue'
  import AllVaults from '@/components/AllVaults.vue'
  export default {
    name: "dashboard",
    props: [],
    data() {
      return {

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
    },
    components: {
      Navbar,
      AllVaults
    }
  }
</script>