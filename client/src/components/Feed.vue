<template>
  <div class="content">
    <v-window class="wind" v-window-item v-window-item--active style="max-height: 424px;">
      <v-card v-card--outlined v-sheet light>
        <v-container class="pa-2" fluid v-for="post in posts" :key="post.title">
          <v-row>
            <v-col>
              <v-card max-width="100%" dark>
                <v-list-item>
                  <v-list-item-avatar>
                    <v-avatar class="ava">
                      <img :src="post.user.image" :alt="post.user.name" />
                    </v-avatar>
                  </v-list-item-avatar>
                  <v-list-item-content>
                    <v-list-item-title class="headline">{{ post.title}}</v-list-item-title>
                    <v-list-item-subtitle>by {{ post.user != null ? post.user.name : "" }} at {{ post.addedAt }}</v-list-item-subtitle>
                  </v-list-item-content>
                </v-list-item>
                <v-card-text>{{ post.content.text }}</v-card-text>
                <v-row align="center" justify="center">
                  <v-img
                    class="grey lighten 2"
                    height="250px"
                    :src="post.content.image"
                    :lazy-src="post.content.lazy"
                    aspect-ratio="1"
                  >
                    <template v-slot:placeholder>
                      <v-container class="fill-height">
                        <v-row class="mx-auto" align="center" justify="center">
                          <v-progress-circular class="load" indeterminate color="grey lighten-5"></v-progress-circular>
                        </v-row>
                      </v-container>
                    </template>
                  </v-img>
                </v-row>
                <v-card-actions>
                  <v-btn text color="purple darken-4">{{ post.likes }} likes</v-btn>
                  <v-btn text color="purple darken-4">{{ post.dislikes }} dislikes</v-btn>
                  <v-spacer />
                  <!-- Comment Section -->
                  <div class="flex-grow-1"></div>
                  <v-btn icon @click="show = !show">
                    Comments
                    <v-icon
                      class="comment"
                      color="purple"
                    >{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
                  </v-btn>
                </v-card-actions>

                <v-expand-transition>
                  <div v-show="show">
                    <v-card-avatar>
                      <v-list-item>
                        <v-list-item-avatar>
                          <v-avatar class="ava">
                            <img :src="post.user.image" :alt="post.user.name" />
                          </v-avatar>
                        </v-list-item-avatar>
                        <v-list-item-content>
                          <v-list-item-title class="comment-name" >{{post.content.name0}}</v-list-item-title>
                        </v-list-item-content>
                      </v-list-item>
                    </v-card-avatar>
                    <v-card-text>{{post.content.answer}}</v-card-text>
                  </div>
                </v-expand-transition>
              </v-card>
            </v-col>
          </v-row>
        </v-container>
      </v-card>
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
  },
  data: () => {
    return {
      show: false
    };
  }
};
</script>

<style>
.content {
  margin-top: 100px;
}
.wind {
  overflow-x: hidden;
  overflow-y: auto;
  max-height: 333px;
  width: 50%;
  margin-right: auto;
  margin-left: auto;
}

.comment {
  margin-right: 45px;
}

.comment-name {
  margin-left: 9px;
}

.ava {
  left: 3px;
  top: 3px;
}

/* width */
::-webkit-scrollbar {
  width: 5px;
}

/* Track */
::-webkit-scrollbar-track {
  box-shadow: inset 0 0 5px grey;
  border-radius: 10px;
}

/* Handle */
::-webkit-scrollbar-thumb {
  background: grey;
  border-radius: 10px;
}

.load {
  vertical-align: middle;
}
</style>