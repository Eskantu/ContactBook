<template>
  <div class="jumbotron-eskantu" fluid fill-height>
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
import btnCrud from '../../components/btnCrud/btnCrud.vue'
export default {
  name: "TipoContacto",
  components: {
    btnCrud
  },
};
</script>


<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
    to bottom right,
    rgba(61, 20, 138, 0.7),
    rgba(112, 29, 40, 0.7)
  );
  background-size: cover;
  height: 100%;
}
</style>