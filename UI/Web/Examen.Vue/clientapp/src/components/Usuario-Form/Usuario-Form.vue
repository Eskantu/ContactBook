<template>
  <v-form ref="form" lazy-validation v-model="valid">
    <v-row no-gutters>
      <v-col>
        <v-text-field
        :readonly='readOnly'
          :rules="rules.required"
          v-model="usuario.nombre"
          label="nombre"
          type="text"
        ></v-text-field>
      </v-col>
    </v-row>
    <v-row no-gutters>
      <v-col cols="5">
        <v-text-field
        :readonly='readOnly'
          :rules="rules.required"
          v-model="usuario.apellidoPaterno"
          label="apellido paterno"
          type="text"
        ></v-text-field>
      </v-col>
      <v-col cols="2"></v-col>
      <v-col cols="5">
        <v-text-field
        :readonly='readOnly'
          :rules="rules.required"
          v-model="usuario.apellidoMaterno"
          label="apellido materno"
          type="text"
        ></v-text-field>
      </v-col>
    </v-row>
    <v-text-field
    :readonly='readOnly'
      :rules="rules.required"
      v-model="usuario.userName"
      label="username"
      type="text"
    ></v-text-field>
    <v-text-field
    :readonly='readOnly'
      :rules="[...rules.required, ...rules.email]"
      v-model="usuario.email"
      label="email"
      type="text"
    ></v-text-field>
    <v-text-field
    v-if="!readOnly"
      :rules="[...rules.required, ...rules.min, ...rules.isSecuriryPassword]"
      v-model="usuario.contrasenia"
      label="password"
      type="password"
    ></v-text-field>
    <v-text-field
      v-if="action == 'nuevo' || action == 'details'"
      :rules="action == 'nuevo' || action == 'details' ? [...rules.required, ...rules.same] : []"
      label="repeat password"
      type="password"
    ></v-text-field>
    <v-switch
    :readonly='readOnly'
      v-if="showIsActive"
      :color="`${usuario.isActive ? 'success' : 'red'}`"
      v-model="usuario.isActive"
      inset
      :label="`Usuario ${usuario.isActive ? 'Activo' : 'Inactivo'}`"
    ></v-switch>
  </v-form>
</template>

<script>
import { mapActions, mapState } from "vuex";
import Rules from "../../utils/validators"
export default {
  name: "Usuario-Form",
  props: {
    action: {
      type: String,
      default: "nuevo",
    },
    showIsActive: { type: Boolean, default: false },
    readOnly:{ type: Boolean, default: false },
  },
  data() {
    return {
      snackbar: true,
      valid: false,
      rules: Rules
    };
  },
  methods: {
    ...mapActions("UsuarioFormStore", [
      "ObtenerUsuario",
      "CrearUsuario",
      "EditarUsuario",
    ]),
    submitform() {
      if (this.$refs.form.validate()) {
        this.usuario.isActive=this.usuario.isActive?1:0;
        if (this.action === "nuevo") {
          this.CrearUsuario(this.usuario);
          return true;
        }
        if (this.action === "editar") {
          this.EditarUsuario(this.usuario);
          return true;
        }
      } else {
        return false;
      }
    },
  },
  computed: { ...mapState("UsuarioFormStore", ["usuario"]) },
};
</script>
