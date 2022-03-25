const store = {
  namespaced: true,
  state: {
    show: false,
  },
  mutations: {
    SetShowMutation(state) {
      state.show = !state.show
    }
  },
  actions: {
    SetShow() {
      store.commit('SetShowMutation')
    }
  }
}

export default store