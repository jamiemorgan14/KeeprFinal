<template>
  <div class="allVaultModal">
    <modal v-if="!showEditForm" @closemodal="$emit('closemodal')">
      <span slot="header">Your Vaults</span>
      <span slot="content">
        <allVaults></allVaults>
      </span>
      <span slot="icon">
        <i class="fas fa-plus-square fa-3x" @click="showEditForm = true"></i>
      </span>
    </modal>

  </div>
</template>

<script>
  import AllVaults from '@/components/AllVaults.vue'
  import Modal from '@/components/Modal.vue'

  export default {
    name: "allVaultModal",
    props: [],
    data() {
      return {
        showEditForm: false,
      }
    },
    updated() {
    },
    computed: {},
    methods: {

    },
    components: {
      AllVaults,
      Modal
    }
  }
</script>

<style>
</style>