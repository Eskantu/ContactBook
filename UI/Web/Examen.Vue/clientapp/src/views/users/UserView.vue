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
            <v-btn class="mr-1" dark color="teal">
              <v-icon class="mr-3">add_circle</v-icon>
              Nuevo</v-btn
            >
            <v-btn
              :disabled="DisabledButtonEditDelete.edit"
              class="mr-1"
              dark
              color="amber"
            >
              <v-icon class="mr-3">edit</v-icon>
              Editar</v-btn
            >
            <v-btn
              :disabled="DisabledButtonEditDelete.delete"
              class=""
              dark
              color="red"
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
              item-key="_id"
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
              <!-- <template v-slot:loading>
                <v-progress-linear
                  indeterminate
                  color="green"
                ></v-progress-linear>
                <div>Cargando...</div>
              </template> -->
              <template v-slot:[`item.isActive`]="{ item }">
                <tr>
                  <td>
                    <v-icon v-if="item.isActive" color="success">done</v-icon>
                    <v-icon v-else color="error">close</v-icon>
                  </td>
                </tr>
              </template>
              <template v-slot:[`item.username`]="{ item }">
                <tr>
                  <td>
                    {{ item.username }} <br />
                    <div class="text-md-caption blue-grey--text">
                      {{ item._id }}
                    </div>
                  </td>
                </tr>
              </template>
              <template v-slot:[`item.created`]="{ item }">
                <tr>
                  <td>
                    {{ item.created | formatDate }}
                  </td>
                </tr>
              </template>
            </v-data-table>
          </v-card-text>
        </v-card>
      </v-container>
    </v-col>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";
export default {
  data() {
    return {
      selected: [],
    };
  },
  created() {
    this._cargando = true;
    setTimeout(() => {
      this.ObtenerUsuarios();
    }, 6000);
  },
  methods: {
    ...mapActions("UserStore", ["ObtenerUsuarios", "SetSearch", "SetLoading"]),
  },
  computed: {
    ...mapState("UserStore", ["headers", "userList", "search", "cargando"]),
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

