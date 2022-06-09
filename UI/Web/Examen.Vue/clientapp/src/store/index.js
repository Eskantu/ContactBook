import Vue from "vue";
import Vuex from "vuex";
import UsuarioFormStore from "../components/Usuario-Form/Usuario-Form-Store";
import LoginStore from '../components/Login/LoginStore'
import SnackStore from '../components/Snackbar/SnackStore'
import NewStore from '../views/New/viewStore'
import UserStore from '../views/users/UserStore'
import UploadStore from '../views/uploadFile/UploadStore'
import SlideBarStore from '../components/sliderBar/slidebarStore'
import TipoContactoFormStore from '../components/tipoContacto-Form/tipoContacto-FormStore'
import TipoContactoStore from '../views/TipoContacto/TipoContactoStore'
import AppBarStore from '../components/AppBar/AppBarStore'
import EstadoCivilStore from '../views/EstadoCivil/EstadoCivilStore'
import auth from "../auth/auth";
// import auth from '../auth/auth'
import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(Vuex)
axios.defaults.baseURL = `${window.location.origin}/api/`;
Vue.use(VueAxios, axios)
export default new Vuex.Store({
  state: {
    user: null,
  },
  mutations: {
    setUserProfile(state, user) {
      state.user = user
    },

  },
  actions: {
    getSession() {
      return axios.post('/Authentication/getSession', { token: `${auth.getUserLogged() ? auth.getUserLogged() : ''}` }, 'json')
    }
  },
  getters: {
    ShowNavigationbar(state) {
      return state.user !== null
    },
  },
  modules: { AppBarStore, UsuarioFormStore, SnackStore, LoginStore, NewStore, UserStore, UploadStore, SlideBarStore, TipoContactoFormStore, TipoContactoStore, EstadoCivilStore }
});
