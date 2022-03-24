import axios from 'axios'

const store = {
    namespaced: true,
    state: {
        cargando: true,
        userList: [], userSelect: {}, search: '', headers: [
            { text: 'Nombre', value: 'username' },
            { text: 'Activo', value: 'isActive', sortable: false },
            { text: 'Creado por', value: 'createdFor' },
            { text: 'Modulos', value: 'modules' },
            { text: 'Fecha Creacion', value: 'created' },
        ]
    },
    mutations: {
        setUserList(state, items) {
            state.cargando = false
            state.userList = items
        },
    },
    actions: {
        ObtenerUsuarios({ commit }) {
            console.log('sdaksdjhkasbdkadoñsdfñosdf')
            axios.get('/user').then(res => commit("setUserList", res.data)).catch(e => console.log(e))
        },
        SetSearch({ state }, search) {
            state.search = search
        },
        SetLoading({ state }, loading) {
            state.loading = loading
        }
    }
}

export default store