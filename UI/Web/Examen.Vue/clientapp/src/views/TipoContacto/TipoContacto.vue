<template>
  <div class="jumbotron-eskantu" fluid fill-height>
    <v-container>
      <v-card
        color="transparent"
        offset-md="2"
        md="2"
        class="text-md-center elecation-3"
      >
        <btn-crud
          :disabledDelete="DisabledButtonEditDelete.delete"
          :disabledEdit="DisabledButtonEditDelete.edit"
          @search="(e) => setSearch(e)"
          @clicknew="nuevo()"
          @clickedit="editar()"
          @clickdelete="()=>EliminarTipoContacto(selectedItems[0])"
        ></btn-crud>
        <v-card-text>
          <data-table
            :emitItemSelect="(e) => setSelectedItems(e)"
            :headers="headers"
            :items="items"
            :keyItem="keyItem"
            :search="search"
            :showSelect="true"
          ></data-table>
        </v-card-text>
      </v-card>
      <popup
        @success="guardar(accion)"
        @close="showNew = false"
        @cancel="showNew = false"
        :disableSuccess="isValidForm"
        :show="showNew"
        :title="'Nuevo tipo contacto'"
      >
        <template v-slot:body>
          <TipoContactoForm
            :action="accion"
            ref="tipoContactoForm"
            :isValid="
              (e) => {
                isValidForm = !e;
              }
            "
          ></TipoContactoForm>
        </template>
      </popup>
    </v-container>
  </div>
</template>

<script>
import btnCrud from "../../components/btnCrud/btnCrud.vue";
import dataTable from "../../components/dataTable/dataTable.vue";
import popup from "../../components/popup/popup.vue";
import TipoContactoForm from "../../components/tipoContacto-Form/tipoContacto-Form.vue";
import { mapActions, mapState, mapMutations, mapGetters } from "vuex";
export default {
  name: "TipoContacto",
  components: {
    btnCrud,
    dataTable,
    popup,
    TipoContactoForm,
  },
  data() {
    return {
      isValidForm: true,
      showNew: false,
    };
  },
  computed: {
    ...mapState("TipoContactoStore", [
      "items",
      "selectedItems",
      "headers",
      "keyItem",
      "search",
      "accion",
    ]),
    ...mapGetters("TipoContactoStore", ["DisabledButtonEditDelete"]),
  },
  methods: {
    ...mapActions("TipoContactoStore", [
      "ObtenerTipoContacto",
      "EditarContacto",
      "EliminarTipoContacto",
    ]),
    ...mapMutations("TipoContactoStore", ["setSearch", "setSelectedItems","setAccion"]),
    guardar() {
      this.$refs.tipoContactoForm.guardar();
      this.showNew = false;
      this.ObtenerTipoContacto();
    },
    editar(){
      this.setAccion("editar")
       this.EditarContacto(this.selectedItems[0]);
      this.showNew = true;
    
    },
    nuevo() {
      this.setAccion("nuevo")
      this.showNew = true;
    },
  },
  created() {
    // this._cargando = true;
    this.ObtenerTipoContacto();
  },
};
</script>


<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
    to bottom right,
    rgba(20, 22, 138, 0.7),
    rgba(39, 112, 29, 0.7)
  );
  background-size: cover;
  height: 100%;
}
</style>