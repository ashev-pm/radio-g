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
        text: "Some funny text about that cat bellow. Or... how do you wright this word. Some funny text about that cat bellow. Or... how do you wright this word. Some funny text about that cat bellow. Or... how do you wright this word.",
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
      title: "post",
      content: {
        text: "There we will have a facinating text. When we will invite a facinating text wrighter.There we will have a facinating text. When we will invite a facinating text wrighter. ",
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
      title: "post",
      content: {
        text: "Am I a joke to you?!.",
        image:"https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/439031.jpg",
        animation:""
      },
      likes: 0,
      dislikes: 0,
      addedAt:"25/10/2019 20:10:03",
      user: {
        name:"Jony",
        image: "../../assets/ragio-g-small.png"
      }}]
  },
  mutations: {},
  actions: {}
}