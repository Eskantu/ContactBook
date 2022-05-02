
const store = {
  namespaced: true,
  state: {
    showAppbar: false,
  },
  mutations: {
    setShowAppbar(state, value) {
      state.showAppbar = value;
    },
  },
};

export default store