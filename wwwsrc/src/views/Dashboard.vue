<template>
  <div class="dashboard">
    <navbar></navbar>
  </div>
</template>

<script>
  import Navbar from '@/components/Navbar.vue'
  export default {
    name: "dashboard",
    props: [],
    data() {
      return {}
    },
    computed: {},
    methods: {},
    components: {
      Navbar
    }
  }
</script>