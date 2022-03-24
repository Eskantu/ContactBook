<template>
  <v-container wrap class="jumbotron-eskantu" fluid>
    <v-row>
      <v-col class="text-md-center">
        <v-card id="titulo" class="mt-5">
          <v-card-title><h2>About this platform</h2></v-card-title>
        </v-card>
      </v-col>
    </v-row>
    <v-row class="ml-6 mr-6">
      <v-col md="4" class="text-md-center">
        <v-card :shaped="true" height="450" id="text" class="mt-5">
          <v-card-title><h4>Purpose</h4></v-card-title>
          <v-card-text class="pa-5"
            ><p>
              El proposito de esta plataforma es el poder explorar y comprender
              el funcionamiento de vue, axios, vuex y vuetify, para asi poder
              crear componentes de forma profesional haciendo uso de buenas
              practias.
            </p></v-card-text
          >
        </v-card>
      </v-col>
      <v-col md="4">
        <v-card :shaped="true" height="450" id="text" class="mt-5">
          <v-card-title><h4>Technologies</h4></v-card-title>
          <v-card-text class="pa-5">
            <v-list>
              <v-list-item v-for="item in technologies" :key="item.name">
                <v-list-item-icon>
                  <v-icon>{{ item.icon }}</v-icon>
                </v-list-item-icon>
                <v-list-item-content>
                  <v-list-item-title
                    ><strong>{{ item.name }}</strong></v-list-item-title
                  >
                </v-list-item-content>
              </v-list-item>
            </v-list>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col md="4" class="text-md-center">
        <v-card :shaped="true" height="450" id="text" class="mt-5">
          <v-card-title><h4>@Eskantu</h4></v-card-title>
          <v-card-text class="pa-5"
            ><p>
              Ing. en sistemas computacionales con dos años de experiencia en
              <strong>.Net</strong>, creacion de
              <strong>Web serivces</strong> RestFull y soap, manejo de control
              de versiones con <strong>Git</strong>.
            </p></v-card-text
          >
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
export default {
  data() {
    return {
      technologies: [
        { name: "Vue", icon: "construction" },
        { name: "Vuetify", icon: "brush" },
        { name: "Vuex", icon: "inventory" },
        { name: "Axios", icon: "public" },
        { name: "SCCS", icon: "format_paint" },
        { name: "JavaScript", icon: "bolt" },
      ],
    };
  },
};
</script>

<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
    to top left,
    rgba(75, 80, 32, 0.7),
    rgba(57, 129, 119, 0.7)
  );
  background-size: cover;
  height: 100%;
  #titulo {
    color: white;
    background-color: transparent;
    .v-card__title {
      h2,
      h4 {
        margin: 0px auto;
      }
    }
  }
  #text {
    color: white;
    .v-card__title {
      background-color: rgba($color: #2725255b, $alpha: 1);
      h2,
      h4 {
        margin: 0px auto;
      }
    }
  }
}
</style>