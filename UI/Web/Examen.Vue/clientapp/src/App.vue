<template>
  <v-app>
    <v-app-bar
      app
      dark
      clipped-left
      clipped-right
      elevate-on-scroll
      scroll-target="#scrolling-techniques-7"
      @click="drawer = !drawer"
    >
      <v-app-bar-nav-icon></v-app-bar-nav-icon>

      <v-toolbar-title>Contact Book</v-toolbar-title>
    </v-app-bar>
    <v-navigation-drawer
      v-model="drawer"
      clipped
      stateless
      hide-overlay
      :width="300"
      dark
      app
    >
      <v-list dense>
        <v-list-item-group>
          <v-list-item link  :to="{ name: 'Home' }">
            <v-list-item-icon>
              <v-icon>mdi-home</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item>

                    <v-list-item>
            <v-list-item-icon>
              <v-icon>contact_page</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Contactos</v-list-item-title>
          </v-list-item>

          <v-list-item>
            <v-list-item-icon>
              <v-icon>format_list_bulleted</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Tipo contacto</v-list-item-title>
          </v-list-item>

          <v-list-item>
            <v-list-item-icon>
              <v-icon>favorite</v-icon>
            </v-list-item-icon>
            <v-list-item-title>Estado civil</v-list-item-title>
          </v-list-item>
          <v-list-item link :to="{ name: 'About' }">
            <v-list-item-icon>
              <v-icon>question_mark</v-icon>
            </v-list-item-icon>
            <v-list-item-title>About</v-list-item-title>
          </v-list-item>
        </v-list-item-group>
      </v-list>
       <template v-slot:append>
        <div class="pa-2">
          <v-btn color='deep-purple accent-4' block>
            Salir
          </v-btn>
        </div>
      </template>
    </v-navigation-drawer>
    <v-main>
      <router-view />
    </v-main>
    <v-footer padless dark>
      <v-col class="text-center" cols="12">
        {{ new Date().getFullYear() }} — <strong>Contact-Book</strong>
      </v-col>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: "App",

  data: () => ({
    drawer: false,
  }),
};
</script>
