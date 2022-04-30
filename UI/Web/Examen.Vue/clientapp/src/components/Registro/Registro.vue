<template>
  <v-layout class="jumbo" align-center fill-height justify-center>
    <v-flex xs12 sm8 md4>
      <v-card class="elevation-12">
        <v-toolbar dark color="purple">
          <v-toolbar-title><h3>SIGN IN</h3></v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <v-form>
            <v-row no-gutters >
              <v-col>
                <v-text-field
                v-model="usuario.nombre"
                  label="nombre"
                  type="text"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row no-gutters >
              <v-col cols="5">
                <v-text-field
                v-model="usuario.apellidoPaterno"
                  label="apellido paterno"
                  type="text"
                ></v-text-field>
              </v-col>
              <v-col cols="2"></v-col>
              <v-col cols="5">
                <v-text-field
                v-model="usuario.apellidoMaterno"
                  label="apellido materno"
                  type="text"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-text-field
              v-model="usuario.username"
              label="username"
              type="text"
            ></v-text-field>
            <v-text-field
              v-model="usuario.email"
              label="email"
              type="text"
            ></v-text-field>
            <v-text-field
              v-model="usuario.contrasenia"
              label="password"
              type="password"
            ></v-text-field>
            <v-text-field
              label="repeat password"
              type="password"
            ></v-text-field>
          </v-form>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn @click="CrearUsuario(usuario)" color="success">Sign in</v-btn>
          </v-card-actions>
        </v-card-text>
      </v-card>
      <v-btn class="mt-5" color="error" block :to="{ name: 'Login' }"
        >Login</v-btn
      >
    </v-flex>
  </v-layout>
</template>

<script>
import { mapActions, mapState } from "vuex";
export default {
  data() {
    return {
      snackbar: true,
    };
  },
  name: "Registro",
  methods: {
    ...mapActions("RegistroStore", ["ObtenerUsuario", "CrearUsuario"]),
  },
  computed: { ...mapState("RegistroStore", ["usuario"]) },
};
</script>

<style lang="scss" scoped>
.jumbo {
  background: linear-gradient(
    to top right,
    rgba(71, 50, 41, 0.7),
    rgba(87, 59, 100, 0.7)
  );
}
</style>
