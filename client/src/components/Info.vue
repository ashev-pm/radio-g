<template>
  <v-container>
    <v-card class="slider">
      <v-carousel height="auto" hide-controls="true">
        <v-carousel-item v-for="(item,i) in items" :key="i" :src="item.src"></v-carousel-item>
      </v-carousel>
    </v-card>
  </v-container>
</template>



<script>
export default {
  data() {
    return {
      items: [
        {
          src:
            "https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/sucess.png"
        },
        {
          src:
            "https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/positive.png"
        },
        {
          src:
            "https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/luck.png"
        },
        {
          src:
            "https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/blago.png"
        }
      ]
    };
  }
};
</script>

<style scoped>
.slider {
  max-width: 100%;
  margin-top: -210px;
  margin-bottom: -84px;
  position: relative;
  z-index: 1000;
}
</style>

