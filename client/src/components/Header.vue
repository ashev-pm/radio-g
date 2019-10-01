
<template>
  <div>
    <v-toolbar class="purple darken-4" height="84px" fixed>
      <v-layout justify-center style="margin-left: 54px">
        <v-img
          class="tool"
          src="https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/logo-white.png"
          max-width="333"
        ></v-img>
      </v-layout>
 <Rotator/>     
    </v-toolbar>
   
  </div>
</template>

<script>

import Rotator from "./Rotator";

export default {
  name: "App",
  components: {
    Rotator
  }
};

</script>
<style>

.tool {
  align-content: center;
}

</style>