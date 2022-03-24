<template>
  <v-app>
    <Snackbar></Snackbar>
    <NavigationBar v-if="user"></NavigationBar>
    <v-main>
      <router-view />
    </v-main>
    <v-footer dark padless>
      <v-col class="text-center" cols="12">
        {{ new Date().getFullYear() }} — <strong>PIoT</strong>
      </v-col>
    </v-footer>
  </v-app>
</template>

<script>
import Snackbar from "./components/Snackbar/Snackbar.vue";
// import StorePrincipal from "./store/index";
import NavigationBar from "./components/sliderBar/SliderBar.vue";
export default {
  name: "App",
  components: { Snackbar, NavigationBar },
  data() {
    return {};
  },
  computed: {
    user: function () {
      return this.$store.state.user != null;
    },
  },
};
</script>
