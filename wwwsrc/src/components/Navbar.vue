<template>
  <div class="navbar px-0 py-0 mb-2">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">Keepr</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav"
        aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
          <li class="nav-item active">
            <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" data-toggle="modal" data-target="#mainModal">My Vaults</a>
          </li>

          <!-- <li class="nav-item">
            <a class="nav-link disabled" href="#">Disabled</a>
          </li> -->
        </ul>
      </div>
      <div class="nav-item text-right">
        <a class="nav-link" href="#">Logout</a>
      </div>
    </nav>
    <AllVaultModal></AllVaultModal>
  </div>
</template>

<script>
  import AllVaultModal from '@/components/AllVaultModal.vue'

  export default {
    name: "navbar",
    props: [],
    data() {
      return {

      }
    },
    computed: {

    },
    methods: {},
    components: {
      AllVaultModal
    }
  }
</script>

<style>
  .navbar {
    width: 100%;
    position: static;
  }
</style>