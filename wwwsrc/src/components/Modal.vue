<template>

  <div class="my-modal-backdrop">
    <div class="my-modal">
      <header class="my-modal-header">
        <slot name="header">
          This is the default tile!

        </slot>
      </header>
      <section class="my-modal-body">
        <slot name="content">
          I'm the default body!
        </slot>
      </section>
      <footer class="my-modal-footer">
        <button type="button" class="my-btn-green" @click="close">
          Close me!
        </button>
      </footer>
    </div>
  </div>

</template>

<script>
  export default {
    name: "Modal",
    props: [],
    data() {
      return {}
    },
    computed: {},
    methods: {
      close() {
        this.$emit('closemodal')
      }
    },
    components: {

    }
  }
</script>

<style scoped>
  .my-modal-backdrop {
    position: fixed;
    z-index: 200;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.3);
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .my-modal {
    background: #fff;
    box-shadow: 2px 2px 20px 1px;
    overflow-x: auto;
    display: flex;
    flex-direction: column;
    width: 70%;
    max-height: 95%
  }

  .my-modal-header,
  .my-modal-footer {
    padding: 15px;
    display: flex;
  }

  .my-modal-header {
    justify-content: center;
    color: #facf5a;
    font-size: 2.5em;
    border-bottom: 1px solid #ff5959
  }

  .my-modal-footer {
    border-top: 1px solid #facf5a;
    justify-content: flex-end;
  }

  .my-modal-body {
    position: relative;
    padding: 20px 10px;
  }

  .my-btn-close {
    border: none;
    font-size: 20px;
    padding: 20px;
    cursor: pointer;
    font-weight: bold;
    color: #ff5959;
    background: transparent;
  }

  .my-btn-green {
    color: white;
    background: #ff5959;
    border: 1px solid #facf5a;
    border-radius: 2px;
  }
</style>