import Vue from "vue";
import Vuex from "vuex";
import App from "./App.vue";
import BootstrapVue from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import router from "./router/index";
import { store } from "./store/index";

Vue.use(BootstrapVue);
Vue.use(Vuex);

Vue.config.productionTip = false;

new Vue({
  store,
  router,
  render: (h) => h(App),
}).$mount("#app");
