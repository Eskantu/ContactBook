const store = {
    namespaced: true,
    state: { viewSnack: false, textSnack: 'Im a snackbar' },
    mutations: {
        SetSnack(state, text) {
            state.viewSnack = true
            state.textSnack = text
        }
    },
    actions: {
        setShow({ state }, show) {
            state.viewSnack = !show
        }
    }
}

export default store
