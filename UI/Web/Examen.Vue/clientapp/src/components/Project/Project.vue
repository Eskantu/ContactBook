<template>
  <v-container class="jumbotron-eskantu" fluid fill-height>
    <v-col dense fixed offset-md="2" md="8" class="text-md-center">
      <v-card id="v-card" dark class="elevation-3">
        <v-card-title><h2>Projects</h2> </v-card-title>
      </v-card>
    </v-col>
    <v-col v-for="item in items" :key="item.id" md="3">
      <v-card dark link class="elevation-5">
        <v-card-title>
          <v-img :src="item.img" height="200px">
            <h3 class="text-md-center mt-5">{{ item.title }}</h3>
          </v-img>
        </v-card-title>
        <v-card-subtitle class="mt-1">
          <em> {{ item.id }} </em>
        </v-card-subtitle>
        <v-card-text>
          <p>{{ item.description }}</p></v-card-text
        >
        <v-divider></v-divider>
        <v-card-actions>
          <v-btn @click="show = !show" block color="error"
            ><v-icon>delete</v-icon></v-btn
          >
        </v-card-actions>
      </v-card>
    </v-col>
    <v-btn
      :to="{ name: 'New' }"
      fab
      dark
      large
      color="primary"
      fixed
      right
      bottom
    >
      <v-icon dark>add</v-icon>
    </v-btn>
    <v-dialog max-width="400" v-model="show">
      <v-card>
        <v-card-title
          >¿Seguro que desea eliminar el proyecto seleccionado?</v-card-title
        >
        <v-card-text color="red">
          <v-alert :value="true" outlined color="error" icon="warning"
            >Al eliminar el proyecto no se podran recuperar los datos</v-alert
          ></v-card-text
        >
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="error">Cancelar </v-btn>
          <v-btn color="success"> Aceptar </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      show: false,
      items: [
        {
          title: "Smart Forest",
          id: "6148ff2e90b3691a33fc7588",
          description:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ipsam voluptatum a omnis enim velit, ea aliquid laudantium voluptatibus aliquam nobis, inventore earum rem ab nisi tenetur in eius tempore id.",
          img: "https://cdn.pixabay.com/photo/2015/09/09/16/05/forest-931706_960_720.jpg",
        },
        {
          title: "Drive is fun",
          id: "6160948ef93cf461ea4e8040",
          description:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ipsam voluptatum a omnis enim velit, ea aliquid laudantium voluptatibus aliquam nobis, inventore earum rem ab nisi tenetur in eius tempore id.",
          img: "https://cdn.pixabay.com/photo/2016/01/19/17/57/car-1149997_960_720.jpg",
        },
        {
          title: "Light for all world",
          id: "616094cdf93cf461ea4e8044",
          description:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ipsam voluptatum a omnis enim velit, ea aliquid laudantium voluptatibus aliquam nobis, inventore earum rem ab nisi tenetur in eius tempore id.",
          img: "https://cdn.pixabay.com/photo/2016/01/19/17/29/earth-1149733_960_720.jpg",
        },
        {
          title: "Small steps",
          id: "61609599f93cf461ea4e8048",
          description:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ipsam voluptatum a omnis enim velit, ea aliquid laudantium voluptatibus aliquam nobis, inventore earum rem ab nisi tenetur in eius tempore id.",
          img: "https://cdn.pixabay.com/photo/2015/06/19/21/24/avenue-815297_960_720.jpg",
        },
        {
          title: "Sky is blue",
          id: "6160ba77f4a8beb5cd968d0a",
          description:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ipsam voluptatum a omnis enim velit, ea aliquid laudantium voluptatibus aliquam nobis, inventore earum rem ab nisi tenetur in eius tempore id.",
          img: "https://cdn.pixabay.com/photo/2015/10/12/15/01/mountain-984083_960_720.jpg",
        },
        {
          title: "Night Night",
          id: "6160badaf4a8beb5cd968d0e",
          description:
            "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Ipsam voluptatum a omnis enim velit, ea aliquid laudantium voluptatibus aliquam nobis, inventore earum rem ab nisi tenetur in eius tempore id.",
          img: "https://cdn.pixabay.com/photo/2015/10/12/14/59/milky-way-984050_960_720.jpg",
        },
      ],
    };
  },
};
</script>

<style lang="scss" scoped>
.jumbotron-eskantu {
  background: linear-gradient(
    to top right,
    rgba(80, 32, 32, 0.7),
    rgba(68, 57, 129, 0.7)
  );
  background-size: cover;
  height: 100%;
  #v-card {
    .v-card__title {
      h2 {
        margin: 0px auto;
      }
    }
  }
}
</style>