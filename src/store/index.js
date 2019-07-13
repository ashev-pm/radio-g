import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    file: "http://35.224.48.39:8000/basic-radio.ogg",
    isPlayed: false
  },
  mutations: {
    play(state) { //TODO: rename tis mutation
      if (state.isPlayed === true) {
        state.isPlayed = false;
      } else {
        state.isPlayed = true;
      }
    },
    setPlayerActivity(state, isPlayed) {
      state.isPlayed = isPlayed;
    }
  },
  actions: {

  }
})