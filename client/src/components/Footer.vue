<template>
  <v-footer dark height="auto">
    <v-card class="flex" flat tile >
      <v-card-title class="purple darken-4 pa-1" color="#774AAD"> 
        <v-layout justify-center>
          <Player class="play"> </Player>
        </v-layout>
      </v-card-title>

      <v-card-actions class="grey darken-3 justify-center green--text text--lighten-3" >
        
      &copy;2019 — Radio.G (c) Наверное лучшее радио... И точка.
      </v-card-actions>
    </v-card>
  </v-footer>
</template>

<script>

import Player from "./Player.vue";

export default {
  components: {
    Player
  },
  data() {
    return {
      icons: [
        "fab fa-facebook",
        "fab fa-twitter",
        "fab fa-google-plus",
        "fab fa-linkedin",
        "fab fa-instagram"
      ]
    };
  }
};

</script>



