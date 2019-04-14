<template>
  <div class="Vault">
    <navbar></navbar>
    <h1 v-if="currentVault">You're in {{currentVault.name}}</h1>
    <h4 v-if="currentVault">{{currentVault.description}}</h4>
  </div>
</template>

<script>
  import Navbar from '@/components/Navbar.vue'
  export default {
    name: "Vault",
    props: [],
    created() {
      this.$store.dispatch('getVaults')
    },
    data() {
      return {}
    },
    computed: {
      currentVault() {
        return this.$store.state.vaults.find(v => v.id == this.$route.params.vaultId)
      }
    },
    methods: {},
    components: {
      Navbar
    }
  }
</script>