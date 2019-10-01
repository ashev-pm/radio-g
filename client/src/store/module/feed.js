import {
  config
} from '../../config'
const url = config.feedUrl;

export default {
  state: {
    feed: url,
    posts: [{
      title: " This magnificent post ",
      content: {
        text: "Some funny text about that cat bellow. Or... how do you wright this word. Some funny text about that cat bellow. Or... how do you wright this word. Some funny text about that cat bellow. Or... how do you wright this word.",
        image:"https://images.wallpaperscraft.com/image/goose_bird_beak_113286_3840x2400.jpg",
        lazy:"https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/images.jpg",
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
      title: " Oh yeah! The the post! ",
      content: {
        text: "There we will have a facinating text. When we will invite a facinating text wrighter.There we will have a facinating text. When we will invite a facinating text wrighter. ",
        image:"https://bad.src/not/valid",
        lazy:"https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/%D0%91%D0%B5%D0%B7%20%D0%BD%D0%B0%D0%B7%D0%B2%D0%B0%D0%BD%D0%B8%D1%8F.jpg",
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
      title: " Nobody reads this anyway ",
      content: {
        text: "Am I a joke to you?!.",
        image:"https://raw.githubusercontent.com/ashev-pm/pre-velikolepie/master/439031.jpg",
        lazy: "https://github.com/ashev-pm/pre-velikolepie/blob/master/439031s.jpg",
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