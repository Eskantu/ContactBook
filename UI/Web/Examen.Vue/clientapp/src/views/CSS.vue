<template>
  <v-layout justify-center fluid fill-height>
    <v-col>
      <v-card class="">
        <v-card-text>
          <v-tabs
            v-model="tabSelect"
            color="primary"
            dark
            center-active
            slider-color="primary"
          >
            <v-tab v-for="item in titles" :key="item.title">
              {{ item.title }}
            </v-tab>
          </v-tabs>
          <v-tabs-items v-model="tabSelect">
            <v-tab-item v-for="item in titles" :key="item.title">
              <v-card flat>
                <v-card-text>
                  <component v-bind:is="item.view"> </component>
                </v-card-text>
              </v-card>
            </v-tab-item>
          </v-tabs-items>
        </v-card-text>
      </v-card>
    </v-col>
  </v-layout>
</template>

<script>
import Forky from "../components/Forky.vue";
import Registro from "../components/Registro/Registro.vue";
import Proyectos from "../components/Project/Project.vue";
export default {
  name: "CSS",
  props: ["titles"],
  components: { Forky, Registro, Proyectos },
  data() {
    return {
      tabSelect: null,
    };
  },
};
</script>

