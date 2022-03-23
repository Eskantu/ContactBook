<template>
  <v-container class="jumbotron-eskantu" fluid fill-height>
    <v-row align="center">
      <v-col offset-md="2" md="8" class="text-md-center">
        <v-card>
          <v-card-title class="white--text">
            <h2>Bienvenido a Contact - Book</h2>
          </v-card-title>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "Home",
  components: {},
};
</script>


<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
      to top right,
      rgba(71, 51, 41, 0.7),
      rgba(65, 94, 86, 0.7)
    );
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