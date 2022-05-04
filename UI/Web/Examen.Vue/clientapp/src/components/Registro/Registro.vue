<template>
    <v-layout class="jumbo" align-center fill-height justify-center>
    <v-flex xs12 sm8 md4>
      <v-card class="elevation-12">
        <v-toolbar dark color="purple">
          <v-toolbar-title><h3>SIGN IN</h3></v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <UserForm ref="userform"></UserForm>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn @click="Submit" color="success">Sign in</v-btn>
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
import UserForm from "../Usuario-Form/Usuario-Form.vue"
export default {
  components: { UserForm },
  methods: {
    Submit() {
      this.$refs.userform.submitform();
    },
  
  },
}
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