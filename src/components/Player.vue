<template>
  <v-layout row justify-space-between>
    
      <v-btn
        outline
        icon
        class="white--text"
        @click.native="play"
      >
        <v-icon v-if="!isPlayed">play_arrow</v-icon>
        <v-icon v-else>pause</v-icon>
      </v-btn>
      
      <v-btn outline icon class="white--text" @click.native="mute()">
        <v-icon v-if="!isMuted">volume_up</v-icon>
        <v-icon v-else>volume_off</v-icon>
      </v-btn>
  
    <audio id="player" ref="player" :src="file"></audio>
  </v-layout>
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