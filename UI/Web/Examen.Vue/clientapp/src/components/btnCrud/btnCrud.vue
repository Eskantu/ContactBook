<template>
  <v-card-title>
    <v-btn
      :disabled="disabledNew"
      @click="clickNew"
      class="mr-1"
      dark
      color="teal"
    >
      <v-icon class="mr-3">add_circle</v-icon>
      Nuevo</v-btn
    >
    <v-btn
      :disabled="disabledEdit"
      class="mr-1"
      dark
      color="amber"
      @click="clickEdit"
    >
      <v-icon class="mr-3">edit</v-icon>
      Editar</v-btn
    >
    <v-btn
      :disabled="disabledDelete"
      class=""
      dark
      color="red"
      @click="clickDelete"
    >
      <v-icon class="mr-3">delete</v-icon>
      Eliminar</v-btn
    >
    <v-spacer></v-spacer>
    <v-text-field
    v-if="showSearch"
    @input="search($event)"
      label="buscar"
      single-line
      color="black"
      hide-details
    ></v-text-field>
  </v-card-title>

</template>

<script>
export default {
  name: "btnCrud",
  props: {
    disabledNew: {
      type: Boolean,
      default: false,
    },
    disabledEdit: {
      type: Boolean,
      default: false,
    },
    disabledDelete: {
      type: Boolean,
      default: false,
    },
      showSearch: {
        type: Boolean,
        default: true,
    },
    columTemplates: {
      type: Array,
      default: () => [],
  },
  },
  methods: {
    search(e) {
        this.$emit("search", e);
    },
    clickNew() {
      this.$emit("clicknew");
    },
    clickEdit() {
      this.$emit("clickedit");
    },
    clickDelete() {
      this.$emit("clickdelete");
    },
  },
};
</script>

<style>
</style>