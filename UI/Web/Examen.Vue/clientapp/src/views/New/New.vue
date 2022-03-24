<template>
  <div class="jumbotron-eskantu" fluid fill-height>
    <v-col offset-md="2" md="8" class="text-md-center">
      <v-card id="v-card" dark class="elevation-3">
        <v-card-title><h2>New project</h2> </v-card-title>
      </v-card>
      <v-col>
        <v-container>
          <v-card
            :shaped="true"
            id="v-card-form"
            offset-md="2"
            md="8"
            class="elevation-3"
          >
            <v-card-text>
              <v-form>
                <v-text-field
                  :disabled="loading"
                  color="withe"
                  prepend-icon="folder"
                  counter
                  label="Name"
                ></v-text-field>
                <v-textarea
                  :disabled="loading"
                  color="withe"
                  outlined
                  prepend-icon="description"
                  counter
                  label="Description"
                ></v-textarea>
                <v-combobox
                  :disabled="loading"
                  color="withe"
                  v-model="chips"
                  :items="items"
                  chips
                  clearable
                  multiple
                  label="your hobbies"
                  prepend-icon="filter_list"
                >
                  <template
                    v-slot:selection="{ attrs, item, select, selected }"
                  >
                    <v-chip
                      v-bind="attrs"
                      :input-value="selected"
                      close
                      @click="select"
                      @click:close="remove(item)"
                    >
                      <strong>{{ item }}</strong>
                      <span>(category)</span>
                    </v-chip>
                  </template>
                </v-combobox>
                <v-row>
                  <v-spacer></v-spacer>
                  <v-btn :disabled="loading" class="mt-4" color="error"
                    >Cancelar</v-btn
                  >
                  <v-btn
                    class="ma-4"
                    :disabled="loading"
                    :loading="loading"
                    @click="loading = true"
                    dark
                    color="green"
                    >Create</v-btn
                  >
                </v-row>
              </v-form>
            </v-card-text>
          </v-card>
        </v-container>
      </v-col>
    </v-col>
  </div>
</template>

<script>
import { mapActions } from "vuex";
export default {
  data: () => ({
    chips: ["Personal", "enterprise", "Learn", "Game"],
    items: ["Streaming", "Eating"],
    loading: false,
    search: "",
    selected: [],
  }),

  computed: {
    allSelected() {
      return this.selected.length === this.items.length;
    },
    categories() {
      const search = this.search.toLowerCase();

      if (!search) return this.items;

      return this.items.filter((item) => {
        const text = item.text.toLowerCase();

        return text.indexOf(search) > -1;
      });
    },
    selections() {
      const selections = [];

      for (const selection of this.selected) {
        selections.push(selection);
      }

      return selections;
    },
  },

  watch: {
    selected() {
      this.search = "";
    },
    loading() {
      setTimeout(() => {
        this.loading = false;
        this.CreateProject();
      }, 6000);
    },
  },

  methods: {
    ...mapActions("NewStore", ["CreateProject"]),
    remove(item) {
      this.chips.splice(this.chips.indexOf(item), 1);
      this.chips = [...this.chips];
    },
  },
};
</script>

<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
    to top right,
    rgba(71, 51, 41, 0.7),
    rgba(65, 94, 86, 0.7)
  );
  background-size: cover;
  height: 100%;
  #v-card {
    background-color: transparent;
    .v-card__title {
      h2 {
        margin: 0px auto;
      }
    }
  }
  #v-card-form {
    background-color: rgba(185, 185, 185, 0.322);
    .v-card__text {
      p {
        margin: 0px auto;
      }
    }
  }
}
</style>