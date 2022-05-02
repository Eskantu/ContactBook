const store = {
  namespaced: true,
  state: {
    show: false,
    userInfo: {}
  },
  mutations: {
    SetShowMutation(state, value) {
      state.show = value;
    },
    setUserInfo(state, userInfo) {
      state.userInfo = userInfo
    }
  },
  actions: {
    SetShow( {commit }, value) {
      commit('SetShowMutation',value)
    }
  }
}

export default store