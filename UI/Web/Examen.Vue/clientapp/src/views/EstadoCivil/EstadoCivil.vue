<template>
  <div class="jumbotron-eskantu">
    <v-container>
      <v-card
        color="transparent"
        offset-md="2"
        md="2"
        class="text-md-center elecation-3"
      >
        <btn-crud @clicknew="() => setShowModal(true)"></btn-crud>
      </v-card>
      <popup
        @cancel="() => setShowModal(false)"
        @close="() => setShowModal(false)"
        :show="showModal"
      >
        <template v-slot:body>
        <estado-civil-form></estado-civil-form>
      </template>
      </popup>
    
    </v-container>
  </div>
</template>

<script>
import btnCrud from "../../components/btnCrud/btnCrud.vue";
import { mapActions, mapState, mapMutations, mapGetters } from "vuex";
import popup from "../../components/popup/popup.vue";
import EstadoCivilForm from '../../components/EstadoCivil-Form/EstadoCivil-Form.vue';
export default {
  components: {
    btnCrud,
    popup,
    EstadoCivilForm,
  },
  computed: {
    ...mapState("EstadoCivilStore", [
      "items",
      "selectedItems",
      "search",
      "accion",
      "showModal",
    ]),
  },
  methods: {
    ...mapMutations("EstadoCivilStore", [
      "setSelectedItems",
      "setSearch",
      "setShowModal",
    ]),
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