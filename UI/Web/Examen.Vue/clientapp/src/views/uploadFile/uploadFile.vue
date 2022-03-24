import { mapActions, mapState } from 'vuex';
<template>
  <v-container fill-height fluid class="jumbotron-eskantu">
    <v-col wrap offset-md="1" md="5">
      <v-card id="v-card-form" offset-md="2" md="8" class="elevation-3">
        <v-card-title>
          <h4>Subir archivos</h4>
        </v-card-title>
        <v-card-text>
          <p>
            <v-form>
              <v-file-input
                color="black"
                counter
                label="Select file"
                multiple
                prepend-icon="portrait"
                outlined
                @change="handleFileUpload"
                :show-size="1000"
              >
              </v-file-input>
            </v-form>
          </p>
        </v-card-text>
      </v-card>
    </v-col>
    <v-col offset-md="0" md="6">
      <v-card
        id="v-card-form"
        height="400"
        offset-md="2"
        md="8"
        class="elevation-3"
      >
        <v-card-title>
          <v-row>
          <v-col>
            <h4>Archivos</h4>
          </v-col>
          <v-radio-group v-model="typeFileShow" row>
            <v-radio :key="1" :value="1" color="withe" label="Por subir"></v-radio>
            <v-radio :key="2" :value="2" color="withe" label="Subidos"></v-radio>
          </v-radio-group>
          <v-col>
              <v-btn :disabled="typeFileShow==1 && fileSelect.length==0"  color="teal" dark>Descargar archivos</v-btn>
            </v-col>
          </v-row>
          
        </v-card-title>
        <v-card-text>
          <v-data-table
          :value="fileSelect"
            :headers="headers"
            :items="fileNotUploaded"
            show-select
            item-key="name"
            height="200"
            dark
            no-data-text="No hay archivos pendientes por subir"
          ></v-data-table>
        </v-card-text>
        <v-card-actions>
          <v-btn color="green" :loading="isUploading" dark width="100%" @click="upload(fileNotUploaded)"
            >Subir</v-btn
          >
        </v-card-actions>
      </v-card>
    </v-col>
  </v-container>
</template>

<script>
import { mapActions, mapState } from "vuex";
export default {
  data() {
    return {
      typeFileShow: 1,
    };
  },
  computed: {
    // ...mapState("UploadStore", ["filesUploaded", "fileNotUploaded", "headers","fileSelect"]),
    ...mapState({
      filesUploaded: state => state.UploadStore.filesUploaded,
      fileNotUploaded: state => state.UploadStore.fileNotUploaded,
      headers: state => state.UploadStore.headers,
      fileSelect: state => state.UploadStore.fileSelect,
      isUploading: state => state.UploadStore.isUploading,
    })
  },
  methods: {
    ...mapActions("UploadStore", ["upload", "handleFileUpload"]),
  },
};
</script>

<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
    to top left,
    rgba(76, 32, 80, 0.7),
    rgba(128, 129, 57, 0.7)
  );
  overflow-y: hidden;
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
 ::-webkit-scrollbar {
  width: 10px;
  height: 10px;
}
::-webkit-scrollbar-track {
  background-color: transparent;
  border-radius: 10px;
}
::-webkit-scrollbar-thumb {
  background-color: rgba(0, 0, 0, 0.4);
  border-radius: 10px;
}
}
</style>