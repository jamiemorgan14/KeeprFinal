<template>
  <div class="Keep">
    <modal @closemodal="$emit('closemodal')" v-if="currentKeep">
      <span slot="header">{{currentKeep.name}}</span>
      <span slot="content">
        <div class="card text-center mx-5 mt-5">
          <div class="card-header">
            {{currentKeep.description}}
          </div>
          <div class="card-body">
            <p class="card-text">Current</p>
            <img :src="currentKeep.img" alt="">
          </div>
          <div class="card-footer text-muted">
            <div class="d-flex justify-content-around">
              <i class="fas fa-plus-square"></i>
              <i class="far fa-trash-alt"></i>
            </div>
          </div>
        </div>
      </span>
      <span slot="icon">icon</span>
    </modal>
  </div>
</template>

<script>
  import Modal from '@/components/Modal.vue'
  export default {
    name: "Keep",
    props: ["chosenKeepId"],
    data() {
      return {}
    },
    created() {
      this.$store.dispatch('getActiveKeep', this.chosenKeepId)
    },
    destroyed() {
      this.$store.dispatch('getActiveKeep', '')
    },
    computed: {
      currentKeep() {
        return this.$store.state.activeKeep
      }
    },
    methods: {},
    components: {
      Modal
    }
  }
</script>
<style scoped>
  img {
    max-width: 70%;
    max-height: 500px
  }
</style>