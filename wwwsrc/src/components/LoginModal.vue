<template>
  <div class="login-modal">
    <modal @closemodal="$emit('closemodal')">
      <span slot="header">Login!</span>
      <span slot="content">
        <form v-if="loginForm" @submit.prevent="loginUser">
          <input type="email" v-model="creds.email" placeholder="email">
          <input type="password" v-model="creds.password" placeholder="password">
          <button type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register">
          <input type="text" v-model="newUser.username" placeholder="name">
          <input type="email" v-model="newUser.email" placeholder="email">
          <input type="password" v-model="newUser.password" placeholder="password">
          <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm">
          <p v-if="loginForm">No account Click to Register</p>
          <p v-else>Already have an account click to Login</p>
        </div>

      </span>
    </modal>
  </div>
</template>

<script>
  import Modal from '@/components/Modal.vue'

  export default {
    name: "login",
    mounted() {

    },
    data() {
      return {
        loginForm: true,
        creds: {
          email: "",
          password: ""
        },
        newUser: {
          email: "",
          password: "",
          username: ""
        }
      };
    },
    methods: {
      register() {
        this.$store.dispatch("register", this.newUser);
        this.$emit('closemodal')
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);
        this.$emit('closemodal')
      }
    },
    components: {
      Modal
    }
  };
</script>