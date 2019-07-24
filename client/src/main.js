import Vue from 'vue';
import './plugins/vuetify';
import App from './App.vue';
import store from './store';
import { config } from './config';

Vue.config.productionTip = false;
Vue.prototype.appConfig = config;

new Vue({
  store,
  render: h => h(App)
}).$mount('#app');


