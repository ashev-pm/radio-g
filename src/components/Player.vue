<template>
  <div>
    <VueAudio :file="url"/>
  </div>
</template>

<script>
import VueAudio from "vue-audio";

export default {
  components: {
    VueAudio
  },
  data() {
    return {
      url: "http://35.224.48.39:8000/basic-radio.ogg"
    };
  },
  mounted() {}
};
</script>