<template>
  <v-dialog :value="show" persistent max-width="600">
    <v-card>
      <v-toolbar dark style="backround: #3a4657">
        <v-container fluid>
          <v-row align="center" justify="space-between">
            <v-col cols="11" class="text-center">
              <h4>{{ title }}</h4>
            </v-col>
            <v-spacer></v-spacer>
            <v-col cols="1" class="text-right">
              <v-btn color="white" text small icon>
                <v-icon @click="close">close</v-icon>
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </v-toolbar>
      <v-card-text>
        <component v-bind:is="component"></component>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script>
import Forky from "../Forky.vue";
import Project from "../Project/Project.vue";
export default {
  name: "popup",
  components: { Forky,Project },
  props: {
    title: { type: String},
    component: { type: String},
    show: { type: Boolean, default: false },
  },
  data() {
    return {};
  },
  methods: {
    close() {
      this.$emit("close");
    },
  },
};
</script>