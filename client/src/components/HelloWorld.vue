<template>
  <v-container>
    <v-layout text-xs-center wrap>
      <v-flex xs12>        
        <v-img @click="play()" :style="rotate"
        :src="require('../assets/ragio-g-small.png')" 
        class="my-5" 
        contain height="420">
        </v-img>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>

import {
  mapState,
  mapMutations
} from "vuex"
import TWEEN from "@tweenjs/tween.js"

export default {
  data() {
    return {
      currentRotate: 0,
      currentTween: null,
      settings: {}
    }
  },
  computed: {
    ...mapState({
      isPlayed: state => state.isPlayed
    }),
    rotate() {
      return `transform: rotate(${this.currentRotate}deg);`
    },
    currentSpeed() {
      return (this.settings.speed / this.settings.maxRotate) * (this.settings.maxRotate - this.currentRotate);
    }
  },
  watch: {
    currentRotate: function (newRotation) {
      if (newRotation >= this.settings.maxRotate) {
        this.currentRotate = this.settings.minRotate;
        this.tween();
      }
    },
    //TODO: neew to think how can avoid watch
    isPlayed: function (playing) {
      if (playing) {
        this.tween();
      } else {
        TWEEN.removeAll();
      }
    }
  },
  methods: {
    ...mapMutations([
      'play'
    ]),
    tween: function () {
      let vm = this;

      function animate() {
        if (TWEEN.update()) {
          vm.animationFrameId = requestAnimationFrame(animate)
        }
      }

      this.currentTween = new TWEEN.Tween({
          tweeningValue: vm.currentRotate
        })
        .to({
          tweeningValue: this.settings.maxRotate
        }, vm.currentSpeed)
        .onUpdate(function () {
          vm.currentRotate = this._object.tweeningValue.toFixed(0);
        })
        .start();

      animate();
    }
  },
  mounted() {
    this.settings = this.appConfig.circularSettings;
    this.currentRotate = this.appConfig.circularSettings.minRotate;
  }
}

</script>
