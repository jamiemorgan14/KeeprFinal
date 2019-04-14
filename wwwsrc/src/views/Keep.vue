<template>
  <div class="ViewKeep">
    <navbar></navbar>
    <div class="card text-center mx-5 mt-5" v-if="currentKeep">
      <div class="card-header">
        Header
      </div>
      <div class="card-body">
        <h5 class="card-title">{{currentKeep.name}}</h5>
        <p class="card-text">{{currentKeep.description}}</p>
        <img :src="currentKeep.img" alt="">
      </div>
      <div class="card-footer text-muted">
        2 days ago
      </div>
    </div>
  </div>
</template>

<script>
  import Navbar from '@/components/Navbar.vue'
  export default {
    name: "ViewKeep",
    props: [],
    created() {
      this.$store.dispatch('getKeeps')
    },
    data() {
      return {}
    },
    computed: {
      currentKeep() {
        return this.$store.state.keeps.find(k => k.id == this.$route.params.keepId)
      }
    },
    methods: {},
    components: {
      Navbar
    }
  }
</script>

<style scoped>
  img {
    max-width: 70%;
    height: auto
  }
</style>