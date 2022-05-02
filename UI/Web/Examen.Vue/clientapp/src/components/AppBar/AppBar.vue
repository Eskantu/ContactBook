<template>
  <v-app-bar v-if="show" app dark clipped-left clipped-right>
    <v-toolbar>
      <v-btn @click="showNavigation(!showNavigationBar)" dark icon>
        <v-icon>menu</v-icon>
      </v-btn>
    </v-toolbar>
  </v-app-bar>
</template>

<script>
import { mapMutations, mapState } from "vuex";
export default {
  name: "AppBar",
  components: {},
  data() {
    return {
    };
  },
  methods: {
        ...mapMutations("SlideBarStore", {
      showNavigation: "SetShowMutation",
    }),
  },
  computed: {
    ...mapState("AppBarStore", {
      show: "showAppbar",
    }),
    ...mapState("SlideBarStore", {
      showNavigationBar: "show",
    }),
  },
};
</script>