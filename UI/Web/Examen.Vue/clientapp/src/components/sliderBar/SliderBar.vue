<template>
  <v-navigation-drawer
    clipped
    stateless
    hide-overlay
    :value="show"
    :mini-variant-width="80"
    :width="300"
    :dark="true"
    class="drawer-sidebar"
    :style="'overflow-y:auto'"
    app
  >
    <v-list>
      <v-list-item>
        <v-list-item-content class="ocular">
          <v-list-item-title class="text-h6"
            >{{ user.nombre }} {{ user.apellidos }}</v-list-item-title
          >
          <v-list-item-subtitle>
            {{ user.userName }}
          </v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>
    </v-list>
    <v-divider></v-divider>
    <v-list dense nav>
      <template v-for="item in Menu">
        <v-list-group
          :value="false"
          no-action
          v-if="item.items"
          :key="item.title"
        >
          <template v-slot:activator>
            <v-list-item>
              <v-list-item-icon>
                <v-icon>{{ item.icon }}</v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>{{ item.title }}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </template>
          <v-list-item link v-for="sub in item.items" :key="sub.title">
            <v-list-item-icon>
              <v-icon v-text="sub.icon"></v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title v-text="sub.title"></v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list-group>

        <v-list v-else :key="item.title">
          <v-list-item link :to="item.to">
            <v-list-item-icon>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title>{{ item.title }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </template>
    </v-list>

    <template v-slot:append>
      <div class="pa-2">
        <v-list dense nav>
          <v-list-item link>
            <v-list-item-icon>
              <v-icon>settings</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title>configuracion</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
          <v-list-item :to="'/logout'" @click="Salir" link>
            <v-list-item-icon>
              <v-icon>logout</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title>salir</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </div>
    </template>
  </v-navigation-drawer>
</template>
<script>
import router from "../../router/index";
import auth from "../../auth/auth";
import { mapState } from "vuex";
import Menu from "../../menu";
export default {
  name: "SliderBar",
  data() {
    return {
      Menu,
    };
  },
  computed: {
    ...mapState("SlideBarStore", {
      show: (state) => state.show,
      user: (state) => state.userInfo,
    }),
  },
  methods: {
    Salir() {
      auth.deleteUserLogged();
      router.push({ name: "Login" });
    },
  },
};
</script>


<style lang="scss">
// .v-navigation-drawer:hover {
//   .ocular {
//     opacity: 1;
//     // transform: rotate(0deg);
//     animation-name: in;
//     animation-duration: 0.5s;
//     transition-timing-function: ease-in;
//     transition-delay: 300ms;
//   }
// }
// .v-navigation-drawer {
//   .ocular {
//     opacity: 0;
//     // transform: rotate(90deg);
//     // transition: opacity, transform 0.5s;
//     transition-timing-function: ease-out;
//     transition-delay: 300ms;
//     animation-name: out;
//     animation-duration: 0.5s;
//     animation-fill-mode: forwards;
//   }
// }

// @keyframes in {
//   from {
//     opacity: 0;
//     transform: rotate(90deg);
//   }
//   to {
//     opacity: 1;
//     transform: rotate(0deg);
//   }
// }

// @keyframes out {
//   from {
//     opacity: 1;
//     transform: rotate(0deg);
//   }
//   to {
//     opacity: 0;
//     transform: rotate(90deg);
//   }
// }

.drawer-sidebar {
  ::-webkit-scrollbar {
    width: 8px;
    color: transparent;
  }

  /* Track */
  ::-webkit-scrollbar-track {
    background: #f1f1f100;
  }

  /* Handle */
  ::-webkit-scrollbar-thumb {
    background: #999;
    border-radius: 10px;
  }

  /* Handle on hover */
  ::-webkit-scrollbar-thumb:hover {
    background: #888;
  }
  overflow-y: scroll;
  mask-position: left bottom;
  transition: mask-position 0.3s, -webkit-mask-position 0.3s;
}
</style>
