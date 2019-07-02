<template>
  <v-app>
    <Header/>
    <v-parallax
      dark
      height="700"
      src="https://images.wallpaperscraft.com/image/earth_moon_space_galaxy_118437_1920x1080.jpg"
    >
      <v-content>
        <HelloWorld/>
      </v-content>
    </v-parallax>
    <v-spacer></v-spacer>
    <v-layout>
    <info></info>
    </v-layout>
    <v-parallax
      dark
      height="700"
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
import Info from "./components/Info.vue";

export default {
  name: "App",
  components: {
    HelloWorld,
    Header,
    Footer,
    Info
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
</style>

