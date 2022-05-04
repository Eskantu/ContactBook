<template>
  <v-app>
    <Snackbar></Snackbar>
    <NavigationBar :show="shownavigationbar"></NavigationBar>
    <AppBar></AppBar>
    <v-main>
      <router-view />
    </v-main>
    <v-footer dark padless>
      <v-col class="text-center" cols="12">
        {{ new Date().getFullYear() }} — <strong>ContactBook</strong>
      </v-col>
    </v-footer>
  </v-app>
</template>

<script>
import Snackbar from "./components/Snackbar/Snackbar.vue";
import NavigationBar from "./components/sliderBar/SliderBar.vue";
import AppBar from "./components/AppBar/AppBar.vue";

export default {
  name: "App",
  components: { Snackbar, NavigationBar,AppBar },
  data() {
    return {
      shownavigationbar: true,
    };
  },
  methods: {
  },
};
</script>

<style>
html {
  overflow: hidden !important;
}

.v-card {
  display: flex !important;
  flex-direction: column;
}

.v-card__text {
  flex-grow: 1;
  overflow: auto;
}
</style>