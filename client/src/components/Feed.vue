<template>
  <div>
      <v-card v-for="post in posts" :key="post.title">
           <v-img
        class="white--text"
        height="50px"
        :src="post.content.image"
      >
      </v-img>
          <v-card-title>{{ post.title }}</v-card-title>
          <v-card-text>{{ post.content.text }}</v-card-text>
          <v-card-actions> {{ post.likes }} likes</v-card-actions>
          <v-card-actions> {{ post.dislikes }} dislikes</v-card-actions>
          <v-card-text> by {{ post.user != null ? post.user.name : "" }} at {{ post.addedAt }}</v-card-text>
      </v-card>
  </div>
</template>

<script>

import {
  mapState
} from "vuex"

export default {
    computed: {
    ...mapState({
      posts: state => state.feed.posts
    })
  }
}
</script>

<style>

</style>