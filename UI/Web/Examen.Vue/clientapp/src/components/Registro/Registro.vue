<template>
  <v-layout class="jumbo" align-center fill-height justify-center>
    <v-flex xs12 sm8 md4>
      <v-card class="elevation-12">
        <v-toolbar dark color="purple">
          <v-toolbar-title><h3>SIGN IN</h3></v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <v-form>
            <v-text-field
              v-model="usuario.username"
              prepend-icon="person"
              label="username"
              type="text"
              counter
            ></v-text-field>
            <v-text-field
              v-model="usuario.email"
              prepend-icon="email"
              label="email"
              type="text"
            ></v-text-field>
            <v-text-field
              v-model="usuario.password"
              prepend-icon="lock"
              label="password"
              type="password"
            ></v-text-field>
            <v-text-field
              v-model="usuario.password2"
              prepend-icon="lock"
              label="repeat password"
              type="password"
            ></v-text-field>
          </v-form>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn @click="CrearUsuario" color="success">Sign in</v-btn>
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
