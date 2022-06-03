<template>
  <div class="jumbotron-eskantu">
    <v-container>
      <v-card
        color="transparent"
        offset-md="2"
        md="2"
        class="text-md-center elecation-3"
      >
        <btn-crud></btn-crud>
      </v-card>
    </v-container>
  </div>
</template>

<script>
import btnCrud from "../../components/btnCrud/btnCrud.vue";
export default {
  components: {
    btnCrud,
  },
};
</script>

<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
    to bottom left,
    rgba(134, 20, 138, 0.7),
    rgba(29, 102, 112, 0.7)
  );
  background-size: cover;
  height: 100%;
}
</style>