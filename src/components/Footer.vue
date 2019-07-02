<template>
  <v-footer dark height="auto">
    <v-card class="flex" flat tile>
      <v-card-title class="indigo" color="#774AAD">
        <v-layout justify-center>
          <Player/>
        </v-layout>
      </v-card-title>

      <v-card-actions class="grey darken-3 justify-center">
        &copy;2019 —
        <strong>Radio.G (c) Все наладится... И точка.</strong>
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
      //
    };
  }
};
</script>