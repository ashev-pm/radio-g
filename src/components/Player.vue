<template>
  <v-card style="text-align: center">
    <v-card-text>
      <v-btn
        outline
        icon
        class="teal--text"
        @click.native="play"
      >
        <v-icon v-if="!isPlayed">play_arrow</v-icon>
        <v-icon v-else>pause</v-icon>
      </v-btn>
      <v-btn outline icon class="teal--text" @click.native="mute()">
        <v-icon v-if="!isMuted">volume_up</v-icon>
        <v-icon v-else>volume_off</v-icon>
      </v-btn>
    </v-card-text>
    <audio id="player" ref="player" :src="file"></audio>
  </v-card>
</template>
<script>

import {
  mapState,
  mapMutations
} from "vuex"

export default {
  computed: {
    ...mapState({
        isPlayed: state => state.isPlayed,
        file: state => state.file
    })
  },
  data() {
    return {
      isMuted: false,
      audio: undefined
    };
  },
  watch: {
    isPlayed: function(newValue) {
      if(newValue ){
        this.audio.play();
      }
      else {
       this.audio.pause();
      }
    }
  },
  methods: {
    ...mapMutations([
      'setPlayerActivity',
      'play'
    ]),  
    mute() {
      this.isMuted = !this.isMuted;
      this.audio.muted = this.isMuted;
      this.volumeValue = this.isMuted ? 0 : 75;
    },
  },
  mounted() {
    this.audio = this.$refs.player;
  },
};
</script>