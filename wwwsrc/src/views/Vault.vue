<template>
  <div class="Vault">
    <h1 v-if="currentVault">You're in {{currentVault.name}}</h1>
  </div>
</template>

<script>
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
    components: {}
  }
</script>