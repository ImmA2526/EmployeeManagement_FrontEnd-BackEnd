<template>
  <div id="app">
    <!-- <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/> -->
  <!-- <Login/> -->
  <!-- <AddEmployee/> -->
  <Table/>
  </div>
</template>

<script>
import Table from './components/Pages/Table'
// import AddEmployee from './components/Pages/AddEmployee.vue'
// import HelloWorld from './components/HelloWorld.vue'
// import Login from './components/Pages/Login'
export default {
  name: 'App',
  components: {
    // HelloWorld,
    // Login,
    Table
    // AddEmployee,
  }
}
</script>

<st
    AddEmployeeyle>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
