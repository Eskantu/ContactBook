<template>
  <v-app-bar v-show="show" app dark clipped-left clipped-right>
    <v-toolbar>
      <v-btn @click="showNavigation" dark icon>
        <v-icon>menu</v-icon>
      </v-btn>
    </v-toolbar>
  </v-app-bar>
</template>

<script>
import { mapMutations } from "vuex";
export default {
  name: "AppBar",
  components: {},
  data() {
    return {};
  },
  methods: {
    ...mapMutations("SlideBarStore", {
      showNavigation: "SetShowMutation",
      show:'showAppbar'
    }),
  },
}

</script>