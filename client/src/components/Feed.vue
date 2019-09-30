<template>
  <div class="content">
    <v-window class="mx-auto" v-window-item v-window-item--active style="max-height: 500px;">
    <v-card  v-card--outlined v-sheet light width="667" overflow-x:hidden overflow-y:auto>
        <v-container class="pa-2" fluid v-for="post in posts" :key="post.title">
          <v-row>
            <v-col>
              <v-card max-width="100%" class="mx-auto" dark>
                <v-list-item>
                  <v-list-item-avatar color="grey"></v-list-item-avatar>
                  <v-list-item-content>
                    <v-list-item-title class="headline">{{ post.content.text }}</v-list-item-title>
                    <v-list-item-subtitle>by {{ post.user != null ? post.user.name : "" }} at {{ post.addedAt }}</v-list-item-subtitle>
                  </v-list-item-content>
                </v-list-item>

                <v-img class="white--text" height="250px" :src="post.content.image"></v-img>

                <v-card-actions>
                  <v-btn text color="purple darken-4">{{ post.likes }} likes</v-btn>

                  <v-btn text color="purple darken-4">{{ post.dislikes }} dislikes</v-btn>
                  <div class="flex-grow-1"></div>
                  <v-btn icon>
                    <v-icon>mdi-heart</v-icon>
                  </v-btn>
                  <v-btn icon>
                    <v-icon>mdi-share-variant</v-icon>
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-col>
          </v-row>
        </v-container>
    </v-card>

    <!-- <v-card v-for="post in posts" :key="post.title">
      <v-img class="white--text" height="150px" :src="post.content.image"></v-img>
      <v-card-title>{{ post.title }}</v-card-title>
      <v-card-text>{{ post.content.text }}</v-card-text>
      <v-card-actions>{{ post.likes }} likes</v-card-actions>
      <v-card-actions>{{ post.dislikes }} dislikes</v-card-actions>
      <v-card-text>by {{ post.user != null ? post.user.name : "" }} at {{ post.addedAt }}</v-card-text>
    </v-card>-->
  </v-window>
  </div>
</template>

<script>
import { mapState } from "vuex";

export default {
  computed: {
    ...mapState({
      posts: state => state.feed.posts
    })
  }
};
</script>

<style>
.content {
margin-top: 100px;
}
</style>