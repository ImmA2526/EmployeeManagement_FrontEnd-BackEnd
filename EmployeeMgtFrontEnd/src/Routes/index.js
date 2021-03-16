import Vue from "vue";
import VueRouter from "vue-router";
import Login from "../Pages/Login"
Vue.use(VueRouter);

// Router Guard


const routes = [

  {
    path: "/",
    name: "login",
    component: Login,
  },
];

const router = new VueRouter({
  mode: "history",
  routes

});

export default router;
