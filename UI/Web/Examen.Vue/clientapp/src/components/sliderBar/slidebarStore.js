const store = {
  namespaced: true,
  state: {
    show: false,
    userInfo: {}
  },
  mutations: {
    SetShowMutation(state) {
      state.show = !state.show
    },
    setUserInfo(state, userInfo) {
      state.userInfo = userInfo
    }
  },
  actions: {
    SetShow() {
      store.commit('SetShowMutation')
    }
  }
}

export default store