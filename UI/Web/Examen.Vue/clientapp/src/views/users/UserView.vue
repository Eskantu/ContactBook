<template>
  <div class="jumbotron-eskantu" fluid fill-height>
    <v-col>
      <v-container>
        <v-card
          color="transparent"
          offset-md="2"
          md="2"
          class="text-md-center elecation-3"
        >
          <v-card-title>
            <v-btn @click="showNew(true)" class="mr-1" dark color="teal">
              <v-icon class="mr-3">add_circle</v-icon>
              Nuevo</v-btn
            >
            <v-btn
              :disabled="DisabledButtonEditDelete.edit"
              class="mr-1"
              dark
              color="amber"
              @click="showEdit(true)"
            >
              <v-icon class="mr-3">edit</v-icon>
              Editar</v-btn
            >
            <v-btn
              :disabled="DisabledButtonEditDelete.delete"
              class=""
              dark
              color="red"
              @click="showDelete(true)"
            >
              <v-icon class="mr-3">delete</v-icon>
              Eliminar</v-btn
            >
            <v-spacer></v-spacer>
            <v-text-field
              v-model="_Search"
              label="buscar"
              single-line
              color="black"
              hide-details
            ></v-text-field>
          </v-card-title>
          <v-card-text>
            <v-data-table
              v-model="selected"
              dark
              show-select
              item-key="idUsuario"
              :headers="headers"
              :items="userList"
              :search="_Search"
              :loading="_cargando"
              class="elevation-1"
              loading-text="Cargando... por favor espere"
              :footer-props="{
                'items-per-page': 5,
                'items-per-page-text': 'Registros por pagina',
                'items-per-page-all-text': 'Todos',
                'show-current-page': true,
              }"
            >
              <template v-slot:[`item.isActive`]="{ item }">
                <tr>
                  <td>
                    <v-icon v-if="item.isActive" color="success">done</v-icon>
                    <v-icon v-else color="error">close</v-icon>
                  </td>
                </tr>
              </template>
              <template v-slot:[`item.nombre`]="{ item }">
                <tr>
                  <td>
                    {{ item.nombre }} {{ item.apellidoPaterno }}
                    {{ item.apellidoMaterno }}
                    <br />
                    <div class="text-md-caption blue-grey--text">
                      {{ item.userName }}
                    </div>
                  </td>
                </tr>
              </template>
              <template v-slot:[`item.fechaCreacion`]="{ item }">
                <tr>
                  <td>
                    {{ item.fechaCreacion | formatDate }}
                  </td>
                </tr>
              </template>
            </v-data-table>
          </v-card-text>
        </v-card>
        <popup
          v-on:success="success('edit')"
          v-on:cancel="cancel('edit')"
          v-on:close="showEdit(false)"
          :show="Edit"
          :title="'Editar usuario'"
        >
          <template v-slot:body>
            <UserForm ref="userform"></UserForm>
          </template>
        </popup>
        <popup
          v-on:close="showDelete(false)"
          :show="Delete"
          :title="'Projects'"
        >
          <template v-slot:body>
            <UserForm ref="userform"></UserForm>
          </template>
        </popup>
        <popup v-on:close="showNew(false)" :show="New" :title="'Nuevo usuario'">
          <template v-slot:body>
            <UserForm ref="userform"></UserForm>
          </template>
        </popup>
      </v-container>
    </v-col>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";
import popup from "../../components/popup/popup.vue";
import UserForm from "../../components/Usuario-Form/Usuario-Form.vue";
export default {
  components: { popup, UserForm },

  data() {
    return {
      selected: [],
    };
  },
  created() {
    this._cargando = true;
    this.ObtenerUsuarios();
  },
  methods: {
    ...mapActions("UserStore", [
      "ObtenerUsuarios",
      "SetSearch",
      "SetLoading",
      "showNew",
      "showEdit",
      "showDelete",
      "success",
      "cancel",
    ]),
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

