<template>
  <v-form v-model="valid">
    <v-text-field
    v-model="tipoContacto.nombre"
      :rules="rules.required"
      :readonly="readOnly"
      label="Tipo contacto"
      type="text"
    >
    </v-text-field>
  </v-form>
</template>

<script>
import { mapState, mapActions, mapGetters } from "vuex";
export default {
  name: "TipoContactoForm",
  props: {
    action: {
      type: String,
      default: "nuevo",
    },
    readOnly: {
      type: Boolean,
      default: false,
    },
    isValid: {
      type: Function,
      default: () => {},
    },
  },
  data() {
    return {
      valid: false,
    };
  },
  computed: {
    ...mapState("TipoContactoFormStore", ["tipoContacto", "rules"]),
  },
  watch: {
    valid(val) {
      this.isValid(val);
    },
  },
  methods: {
    ...mapActions("TipoContactoFormStore", [
      "CrearTipoContacto",
      "EditarTipoContacto",
      "EliminarTipoContacto",
    ]),
    guardar() {
      if (this.action === "nuevo") {
        this.CrearTipoContacto(this.tipoContacto);
      } else {
        this.EditarTipoContacto(this.tipoContacto);
      }
    },
  },
};
</script>

<style>
</style>