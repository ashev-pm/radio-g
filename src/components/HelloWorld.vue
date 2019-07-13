<template>
  <v-container>
    <v-layout text-xs-center wrap>
      <v-flex xs12>        
        <v-img @click="play()" :style="rotate"
        :src="require('../assets/ragio-g.png')" 
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

const settings = {
  minRotate: 0,
  maxRotate: 360,
  speed: 8400
}

export default {
  data() {
    return {
      currentRotate: settings.minRotate,
      currentTween: null
    }
  },
  computed: {
    ...mapState({
      isPlayed: state => state.isPlayed
    }),
    rotate() {
      return `transform: rotate(${this.currentRotate}deg);`
    }
  },
  watch: {
    currentRotate: function (newValue) {
      if (newValue >= settings.maxRotate) {
        this.currentRotate = settings.minRotate; 
        this.tween();
      }
    },
    //TODO: neew to think how can avoid watch
    isPlayed: function (newValue) {       
        if (!newValue) {
          TWEEN.removeAll()          
        } else {
          this.tween();
        }      
    }
  },
  methods: {
    ...mapMutations([
      'play'
    ]),
    tween: function () {
      let vm = this
      let currentSpeed = (settings.speed / settings.maxRotate) * (settings.maxRotate - vm.currentRotate);
      console.log(currentSpeed);

      function animate() {
        if (TWEEN.update()) {
          vm.animationFrameId = requestAnimationFrame(animate)
        }
      }

      vm.currentTween = new TWEEN.Tween({
          tweeningValue: vm.currentRotate
        })
        .to({
          tweeningValue: settings.maxRotate
        },currentSpeed )
        .onUpdate(function () {
          vm.currentRotate = this._object.tweeningValue.toFixed(0);
        })
        .start()
      animate()
    }
  }
}
</script>
