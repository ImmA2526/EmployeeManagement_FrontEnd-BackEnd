import Vue from "vue";
import VueRouter from "vue-router";

import Home from "../components/Pages/HomePage"
import Login from "../components/Pages/Login"

import AddEmployee from "../components/Pages/AddEmployee"
import Crud from "../components/Pages/Table"


Vue.use(VueRouter);

// Router Guard

const routes = [

  {
    path: "/",
    name: "login",
    component: Login,
  },

  {
    path: "/add",
    name: "addEmployee",
    component: AddEmployee,
  },

  {
    path: "/crud",
    name: "Crud",
    component: Crud,
  },

  {
    path: "/home",
    name: "home",
    component: Home,
  },


];

const router = new VueRouter({
  mode: "history",
  routes

});

export default router;
