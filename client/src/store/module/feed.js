import {
  config
} from '../../config'
const url = config.feedUrl;

export default {
  state: {
    feed: url,
    posts: [{
      title: "post",
      content: {
        text: "text",
        image:"https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/439031.jpg",
        animation:""
      },
      likes: 0,
      dislikes: 0,
      addedAt:"25/10/2019 20:10:03",
      user: {
        name:"Jony",
        image: "../../assets/ragio-g-small.png"
      }
    },{
      title: "post1",
      content: {
        text: "text"
      },
      likes: 0,
      dislikes: 0
    },{
      title: "post2",
      content: {
        text: "text"
      },
      likes: 0,
      dislikes: 0
    }]
  },
  mutations: {},
  actions: {}
}