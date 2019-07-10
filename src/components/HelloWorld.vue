<template>
  <v-container>
    <v-layout text-xs-center wrap>
      <v-flex xs12>
        <v-img @click="play()" :style="rotate"
        :src="require('../assets/ragio-g.png')" 
        class="my-5" 
        contain height="420">
        </v-img>
        <audio :src="file" ref="player"></audio>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      file: "http://35.224.48.39:8000/basic-radio.ogg",
      isPlayed: false,
      rotate: "transform: rotate(3600deg);",
      currentRotate: 0
    }
  },
  methods: {
    play() {
      if(this.isPlayed) {
        this.$refs.player.pause()    
      }
      else {
        this.$refs.player.play()
      }
      this.isPlayed = !this.isPlayed;
    },
    _handlePlayingUI: function() {
      if(this.currentRotate > 350)
        this.currentRotate = 0;
      this.currentRotate += 5;
      this.rotate = `transform: rotate(${this.currentRotate}deg);`
    }
  },
  mounted() {
    this.$refs.player.addEventListener("timeupdate", this._handlePlayingUI);
  },
  beforeDestroy() {
    this.$refs.player.removeEventListener("timeupdate", this._handlePlayingUI);    
  }
}
</script>
