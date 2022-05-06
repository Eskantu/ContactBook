<template>
  <v-form ref="form" lazy-validation v-model="valid">
    <v-row no-gutters>
      <v-col>
        <v-text-field
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
          :rules="rules.required"
          v-model="usuario.apellidoPaterno"
          label="apellido paterno"
          type="text"
        ></v-text-field>
      </v-col>
      <v-col cols="2"></v-col>
      <v-col cols="5">
        <v-text-field
          :rules="rules.required"
          v-model="usuario.apellidoMaterno"
          label="apellido materno"
          type="text"
        ></v-text-field>
      </v-col>
    </v-row>
    <v-text-field
      :rules="rules.required"
      v-model="usuario.userName"
      label="username"
      type="text"
    ></v-text-field>
    <v-text-field
      :rules="[...rules.required, ...rules.email]"
      v-model="usuario.email"
      label="email"
      type="text"
    ></v-text-field>
    <v-text-field
      :rules="[...rules.required, ...rules.min, ...rules.isSecuriryPassword]"
      v-model="usuario.contrasenia"
      label="password"
      type="password"
    ></v-text-field>
    <v-text-field
      v-if="action == 'nuevo'"
      :rules="action == 'nuevo' ? [...rules.required, ...rules.same] : []"
      label="repeat password"
      type="password"
    ></v-text-field>
  </v-form>
</template>

<script>
import { mapActions, mapState } from "vuex";
export default {
  name: "Usuario-Form",
  props: {
    action: {
      type: String,
      default: "nuevo",
    },
  },
  data() {
    return {
      snackbar: true,
      valid: false,
      rules: {
        required: [(v) => !!v || "requerido"],
        min: [(v) => (!!v && v.length >= 8) || "minimo 8 caracteres"],
        max: [(v) => (!!v && v.length <= 12) || "maximo 12 caracteres"],
        email: [
          (v) =>
            /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) ||
            "email invalido",
        ],
        isSecuriryPassword: [
          (v) =>
            /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!.%*?&])[A-Za-z\d$@$!.%*?&]{8,}/.test(
              v
            ) || "contraseña no segura",
        ],
        same: [
          (v) => v === this.usuario.contrasenia || "contraseñas no coinciden",
        ],
      },
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
