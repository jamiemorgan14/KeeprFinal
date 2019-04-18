import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    userKeeps: [],
    activeKeep: {},
    vaults: [],
    activeVault: {},
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
    },
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },
    setActiveKeep(state, activeKeep) {
      state.activeKeep = activeKeep
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    setActiveVault(state, activeVault) {
      state.activeVault = activeVault;
    },
    setVaultKeeps(state, vaultKeeps) {
      state.vaultKeeps = vaultKeeps;
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },

    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
        })
        .catch(e => {
          router.push({ name: 'home' })
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', '')
          router.push({ name: 'home' })
        })
    },
    getKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    getKeepsByUser({ commit, dispatch }) {
      api.get('keeps/dashboard')
        .then(res => {
          commit('setUserKeeps', res.data)
        })
    },
    getActiveKeep({ commit, dispatch }, id) {
      api.get('keeps/' + id)
        .then(res => {
          commit('setActiveKeep', res.data)
        })
    },
    createKeep({ commit, dispatch }, newKeep) {
      api.post('keeps', newKeep)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    editKeep({ commit, dispatch }, editedKeep) {
      api.put('keeps/' + editedKeep.id, editedKeep)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    deleteKeep({ commit, dispatch }, id) {
      api.delete('keeps/' + id)
        .then(res => {
        })
    },
    getVaults({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    getActiveVault({ commit, dispatch }, id) {
      api.get('vaults/' + id)
        .then(res => {
          commit('setActiveVault', res.data)
        })
    },
    createVault({ commit, dispatch }, newVault) {
      api.post('vaults', newVault)
        .then(res => {
          dispatch('getVaults')
        })
    },
    deleteVault({ commit, dispatch }, id) {
      api.delete('vaults/' + id)
        .then(res => {
          dispatch('getVaults')
        })
    },
    createVaultKeep({ commit, dispatch }, vaultKeep) {
      api.post('vaults/' + 'vaultKeep.vaultId', vaultKeep)
        .then(res => {
          dispatch('getVaultKeeps', vaultKeep.vaultId)
        })
    },
    getVaultKeeps({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId + '/keeps')
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },

  }
})
