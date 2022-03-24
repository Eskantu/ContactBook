<template>
  <v-dialog width="450" @click:outside="Close()" v-model="show">
    <v-card dark>
      <v-card-title>
        <v-text-field
          :v-model="busqueda"
          dense
          clearable
          :disabled="search"
          append-outer-icon="search"
          @click:append-outer="BuscarProyecto"
          :loading="search"
          single-line
          placeholder="Ingrese el nombre del proyecto"
        >
        </v-text-field>
      </v-card-title>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: "Search",
  props: ["show"],
  data() {
    return {
      search: false,
      busqueda: "",
    };
  },
  methods: {
    BuscarProyecto() {
      this.search = true;
      setTimeout(() => {
        this.Close("Search");
      }, 6000);
    },
    Close(e) {
      this.search = false;
      this.$emit("CloseDialog", e);
    },
  },
};
</script>