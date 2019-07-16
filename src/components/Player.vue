<template>
  <v-layout row justify-space-between>
    
      <v-btn
        outline
        icon
        class="green--text text--lighten-3"
        @click.native="play"
      >
        <v-icon v-if="!isPlayed">play_arrow</v-icon>
        <v-icon v-else>pause</v-icon>
      </v-btn>

      <v-card flat color="purple darken-4">
        <v-card-text class="green--text text--lighten-3">{{trackName}}</v-card-text>
      </v-card>
      
      <v-btn outline icon class="green--text text--lighten-3" @click.native="mute()">
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
} from "vuex";
import io from 'socket.io-client';
const server = 'http://35.224.48.39:3000';
const socket = io(server);

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
      audio: undefined,
      trackName: ""
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
    updateTrackName(name) {
      this.trackName = name;
    }
  },
  mounted() {
    this.audio = this.$refs.player;
    socket.on('trackName', this.updateTrackName);
  },
};
</script>