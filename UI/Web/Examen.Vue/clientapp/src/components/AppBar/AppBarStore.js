
const store = {
  namespaced: true,
  state: {
    showAppbar: false,
  },
  mutations: {
    setShowAppbar(state) {
      console.log('setShowAppbar')
      state.showAppbar = !state.showAppbar;
    },
  },
};

export default store