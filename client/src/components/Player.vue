<template>
  <v-layout row justify-space-between>
    <div class="butt">
      <v-btn outline icon class="green--text text--lighten-3" @click.native="play">
        <v-icon v-if="!isPlayed">play_arrow</v-icon>
        <v-icon v-else>pause</v-icon>
      </v-btn>
    </div>
    <v-card flat color="purple darken-4">
      <v-card-text class="green--text text--lighten-3"><strong> {{track}} </strong></v-card-text>
    </v-card>
    <div class="butt">
      <v-btn outline icon class="green--text text--lighten-3" @click.native="mute()">
        <v-icon v-if="!isMuted">volume_up</v-icon>
        <v-icon v-else>volume_off</v-icon>
      </v-btn>
    </div>
    <audio id="player" ref="player" :src="file"></audio>
  </v-layout>
</template>

<script>

import {
  mapState,
  mapMutations
} from "vuex";
import io from 'socket.io-client';

export default {
  computed: {
    ...mapState({
      isPlayed: state => state.isPlayed,
      file: state => state.file
    }),
    track() {
      return this.trackArtist ? `${this.trackArtist} - ${this.trackTitle}` : this.trackTitle;
    }
  },
  data() {
    return {
      isMuted: false,
      audio: undefined,
      trackTitle: "",
      trackArtist: null
    };
  },
  watch: {
    isPlayed: function (playing) {
      if (playing) {
        this.audio.play();
      } else {
        this.audio.pause();
      }
    }
  },
  methods: {
    ...mapMutations([
      'play'
    ]),
    mute() {
      this.isMuted = !this.isMuted;
      this.audio.muted = this.isMuted;
      this.volumeValue = this.isMuted ? 0 : 75;
    },
    updateTrackName({
      title,
      artist
    }) {
      this.trackTitle = title;
      this.trackArtist = artist;
    },
  },
  //TODO: move 'trackName' to separate constant
  mounted() {
    const socket = io(this.appConfig.streamProxyUrl);
    this.audio = this.$refs.player;
    socket.on('trackName', this.updateTrackName);
  },
};

</script>

<style>

@media only screen and (max-width: 600px) {
  .butt {
    margin-top: 11px;
  }
}

</style>