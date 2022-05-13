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
::-webkit-scrollbar {
  width: 8px;
  color: transparent;
}

/* Track */
::-webkit-scrollbar-track {
  background: #f1f1f100;
}

/* Handle */
::-webkit-scrollbar-thumb {
  background: #999;
  border-radius: 10px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #888;
}
html {
  overflow-y: scroll;
  mask-position: left bottom;
  transition: mask-position 0.3s, -webkit-mask-position 0.3s;
}
</style>
