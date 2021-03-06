import Vue from "vue";
import VueRouter from "vue-router";
import StorePrincipal from '../store/index'
Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/Home.vue"),
    meta: { requiresAuth: true }
  },
  {
    path: "/New",
    name: "New",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/New/New.vue"),
    meta: { requiresAuth: true }
  },
  {
    path: "/Login",
    name: "Login",
    component: () =>
      import(/* webpackChunkName: "login" */ "../components/Login/Login.vue"),
  },
  {
    path: "/Registro",
    name: "Registro",
    component: () =>
      import(
        /* webpackChunkName: "registro" */ "../components/Registro/Registro.vue"
      ),
  },
  {
    path: "/Projects",
    name: "Projects",
    component: () =>
      import(
        /* webpackChunkName: "registro" */ "../components/Project/Project.vue"
      ),
    meta: { requiresAuth: true }
  },
  {
    path: "/about",
    name: "About",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue"),
    meta: { requiresAuth: true }
  },
  {
    path: "/users",
    name: "Users",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/users/UserView.vue"),
    meta: { requiresAuth: true }
  },
  {
    path: "/CSS",
    name: "CSS",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/CSSView.vue"),
    meta: { requiresAuth: true }
  },
  {
    path: "/FILE",
    name: "FILE",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/uploadFile/uploadFile.vue"),
    meta: { requiresAuth: true }
  },
  {
    path: "/TipoContacto",
    name: "TipoContacto",
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/TipoContacto/TipoContacto.vue"),
    meta: { requiresAuth: true }
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  const rutaAuth = to.matched.some(record => record.meta.requiresAuth)
  const pathWithoutAuth = '/Login /Logout /Registro'.split(' ')
  if (pathWithoutAuth.includes(to.path)) {
    StorePrincipal.commit('AppBarStore/setShowAppbar', false)
    StorePrincipal.dispatch('SlideBarStore/SetShow', false)
    next()
  } else {
    if (rutaAuth===true) {
      StorePrincipal.dispatch('getSession').then(res => {
        StorePrincipal.commit('setUserProfile', res.data)
        StorePrincipal.commit('SlideBarStore/setUserInfo', res.data)
        StorePrincipal.commit('SlideBarStore/SetShowMutation', true)
        StorePrincipal.commit('AppBarStore/setShowAppbar', true)
        next()
      }).catch((err) => {
        StorePrincipal.commit("SnackStore/SetSnack", err.response.data)
        StorePrincipal.commit('AppBarStore/setShowAppbar', false)
        next({ name: 'Login' })
      })
    } else {
      next()
    }
  }
})

export default router;
