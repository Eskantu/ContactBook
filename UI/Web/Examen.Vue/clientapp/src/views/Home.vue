<template>
  <v-container class="jumbotron-eskantu" fluid fill-height>
    <v-row align="center">
      <v-col offset-md="2" md="8" class="text-md-center">
        <Search v-on:CloseDialog="Close" :show="show"></Search>
        <v-card>
          <v-card-title class="white--text">
            <h2>Bienvenido a PIoT</h2>
          </v-card-title>
        </v-card>
        <v-btn :to="{ name: 'New' }" dark color="transparent" class="mt-10">
          <v-icon color="green">add_circle</v-icon>
          New project
        </v-btn>
        <v-btn @click="show = true" dark color="transparent" class="mt-10 ml-5">
          Search project
          <v-icon color="green">search</v-icon>
        </v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Search from "./Search.vue";
import router from "../router";
export default {
  name: "Home",
  data() {
    return {
      show: false,
    };
  },
  methods: {
    Close(e) {
      this.show = false;
      if (e) {
        router.push({ name: "Projects" });
      }
    },
  },

  components: { Search }
};
</script>

<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
      to top right,
      rgba(71, 51, 41, 0.7),
      rgba(65, 94, 86, 0.7)
    ),
    url("../assets/bk1.jpg");
  background-size: cover;
  height: 100%;
  .row {
    height: 100% !important;
  }
  .v-card {
    background-color: rgba(255, 255, 255, 0.4) !important;
  }
  .v-card__title {
    word-break: break-word;

    h2 {
      margin: 0px auto;
    }
  }
}
</style>
