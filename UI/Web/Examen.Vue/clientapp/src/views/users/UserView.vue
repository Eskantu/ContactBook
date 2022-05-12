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
          @clickdelete="eliminarUsuario(selected[0])"
          @clickedit="showEdit({ show: true, usuario: selected[0] })"
          @clicknew="showNew(true)"
          :disabledEdit="DisabledButtonEditDelete.edit"
          :disabledDelete="DisabledButtonEditDelete.delete"
          @search="searchEvent"
        ></btn-crud>
        <v-card-text>
          <data-table
            :keyItem="'idUsuario'"
            :headers="headers"
            :items="userList"
            :customColumns="customColumns"
            :showSelect="true"
            :emitItemSelect="selectedItem"
            :search="_Search"

          >
            <template v-slot:isActive="item">
              <v-icon v-if="item.isActive" color="success">done</v-icon>
              <v-icon v-else color="error">close</v-icon>
            </template>
            <template v-slot:fechaCreacion="item">
              {{ item.fechaCreacion | formatDate }}
            </template>
            <template v-slot:detalles>
              <v-btn color="withe" icon>
                <v-icon>visibility</v-icon>
              </v-btn>
            </template>
            <template v-slot:nombre="item">
              {{ item.nombre }} {{ item.apellidoPaterno }}
              {{ item.apellidoMaterno }}
              <br />
              <div class="text-md-caption blue-grey--text">
                {{ item.userName }}
              </div>
            </template>
          </data-table>
        </v-card-text>
      </v-card>
      <popup
        v-on:success="guardar('editar')"
        v-on:cancel="showEdit({ show: false, usuario: {} })"
        v-on:close="showEdit({ show: false, usuario: {} })"
        :show="Edit"
        :title="'Editar usuario'"
      >
        <template v-slot:body>
          <UserForm
            :showIsActive="true"
            :action="'editar'"
            ref="userformEdit"
          ></UserForm>
        </template>
      </popup>
      <!-- <popup
          v-on:close="showDelete(false)"
          :show="Delete"
          :title="'Projects'"
        >
          <template v-slot:body>
            <UserForm ref="userform"></UserForm>
          </template>
        </popup> -->
      <popup
        v-on:close="showNew(false)"
        v-on:success="guardar('nuevo')"
        v-on:cancel="showNew(false)"
        :show="New"
        :title="'Nuevo usuario'"
      >
        <template v-slot:body>
          <UserForm
            :showIsActive="true"
            :action="'nuevo'"
            ref="userformNew"
          ></UserForm>
        </template>
      </popup>
    </v-container>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";
import popup from "../../components/popup/popup.vue";
import UserForm from "../../components/Usuario-Form/Usuario-Form.vue";
import btnCrud from "../../components/btnCrud/btnCrud.vue";
import dataTable from "../../components/dataTable/dataTable.vue";
export default {
  components: { popup, UserForm, btnCrud, dataTable },

  data() {
    return {
      selected: [],
      customColumns: ["fechaCreacion", "isActive", "detalles", "nombre"],
    };
  },
  created() {
    this._cargando = true;
    this.ObtenerUsuarios();
  },
  methods: {
    selectedItem(item) {
      console.log(this.selected.includes(item));
      if (this.selected.includes(item)) {
        this.selected = this.selected.filter((i) => i !== item);
      } else {
        this.selected.push(item);
      }
    },
    ...mapActions("UserStore", [
      "ObtenerUsuarios",
      "SetSearch",
      "SetLoading",
      "showNew",
      "showEdit",
      "showDelete",
      "success",
      "cancel",
      "guardarUser",
      "eliminarUsuario",
    ]),
    ...mapState("UsuarioFormStore", ["SetUsuario"]),
    guardar(action) {
      if (action == "nuevo") {
        this.guardarUser({ form: this.$refs.userformNew, action: action });
      } else if (action == "editar") {
        this.guardarUser({ form: this.$refs.userformEdit, action: action });
      }
      this.selected = [];
    },
    searchEvent(s) {
      this.SetSearch(s);
    },
  },
  computed: {
    ...mapState("UserStore", ["headers", "userList", "search", "cargando"]),
    ...mapState("UserStore", {
      Edit: (state) => state.Edit,
      Delete: (state) => state.Delete,
      New: (state) => state.New,
    }),
    _Search: {
      get() {
        return this.search;
      },
      set(_Search) {
        this.SetSearch(_Search);
      },
    },
    _cargando: {
      get() {
        return this.cargando;
      },
      set(_cargando) {
        this.SetLoading(_cargando);
      },
    },
    DisabledButtonEditDelete() {
      if (this.selected.length == 0) {
        return { edit: true, delete: true };
      } else if (this.selected.length == 1) {
        return { edit: false, delete: false };
      } else if (this.selected.length > 1) {
        return { edit: true, delete: false };
      } else {
        return { edit: false, delete: true };
      }
    },
  },
};
</script>

<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
    to bottom right,
    rgba(81, 20, 138, 0.7),
    rgba(29, 112, 54, 0.7)
  );
  background-size: cover;
  height: 100%;
}
</style>

