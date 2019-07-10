<template>
  <v-app>
    <Header/>
    <v-parallax
      class="par"    
      dark
      height="900"
      src="https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/439031.jpg"
    >
      <v-content>
        <HelloWorld/>
      </v-content>
    </v-parallax>
    <v-spacer></v-spacer>
    <Footer class="footer"></Footer>/>
  </v-app>
</template>

<script>
import HelloWorld from "./components/HelloWorld";
import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";

export default {
  name: "App",
  components: {
    HelloWorld,
    Header,
    Footer
  }
};
</script>

<style>
.footer {
  position: fixed;
  left: 0;
  bottom: 0;
  width: 100%;
  text-align: center;
}

.par {
  height: auto
}

@media screen and (max-width: 540px) {
 .v-card__title {
    padding: 0px 0px 25px 0px;
}
}

</style>

