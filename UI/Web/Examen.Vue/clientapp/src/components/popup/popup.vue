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
      <v-card-text class="mt-5">
        <slot name="body"></slot>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="cancel" color="error">{{ cancelText }}</v-btn>
        <v-btn @click="success" color="success">{{ successText }}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: "popup",
  props: {
    title: { type: String },
    successText: { type: String, default: "Guardar" },
    cancelText: { type: String, default: "Cancelar" },
    show: { type: Boolean, default: false },
  },
  data() {
    return {};
  },
  methods: {
    close() {
      this.$emit("close");
    },
    cancel() {
      this.$emit("cancel");
    },
    success() {
      this.$emit("success");
    },
  },
};
</script>