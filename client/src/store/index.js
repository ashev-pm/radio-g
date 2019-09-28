import Vue from 'vue'
import Vuex from 'vuex'
import {config} from '../config'
import feedModule from "./module/feed"

Vue.use(Vuex)

export default new Vuex.Store({
  modules:{
    feed: feedModule
  },
  state: {
    file: config.streamUrl,
    isPlayed: false
  },
  mutations: {
    play(state) { //TODO: rename tis mutation
      if (state.isPlayed === true) {
        state.isPlayed = false;
      } else {
        state.isPlayed = true;
      }
    }
  },
  actions: {

  }
})