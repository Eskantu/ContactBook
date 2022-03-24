<template>
  <v-snackbar v-model="show">
    {{ textSnack }}
    <template v-slot:action="{ attrs }">
      <v-btn color="pink" text v-bind="attrs" @click.native="setShow(show)">
        Close
      </v-btn>
    </template>
  </v-snackbar>
</template>

<script>
import { mapState, mapActions } from "vuex";
export default {
  name: "Snackbar",
  methods: {
    ...mapActions("SnackStore", ["setShow"]),
  },
  computed: {
    ...mapState("SnackStore", ["viewSnack", "textSnack"]),
    show: {
      get() {
        return this.$store.state.SnackStore.viewSnack;
      },
      set(show) {
        this.setShow(show);
      },
    },
  },
};
</script>