import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vault from './views/Vault.vue'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/vaults/:vaultId',
      name: 'vault',
      component: Vault,
      props: true
    },
    {
      path: '/dashboard',
      name: 'dashboard',
      component: Dashboard,
      props: true
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    }
  ]
})
