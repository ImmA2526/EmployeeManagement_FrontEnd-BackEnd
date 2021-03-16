<template>
  <div class="card">
    <form id="card" @submit.stop.prevent>
<center>
<h4>Employee Management</h4>
<h5>Registration</h5>
</center>
      <!--Names-->
      <b-input-group id="text" size="sm" class="mb-2">
        <b-input-group-prepend is-text>
          <b-icon icon="person-fill"></b-icon>
        </b-input-group-prepend>

        <b-form-input id="fname" 
          v-model="fname"
          :state="nameState"
          aria-describedby="input-live-help input-live-feedback"
         placeholder="First Name"
         trim></b-form-input>
        <b-form-input id="lname" 
           v-model="lname"
          :state="namesState"
          aria-describedby="input-live-help input-live-feedback"
        placeholder="Last name"
        trim></b-form-input>

        <b-form-invalid-feedback id="input-live-feedback">
          Enter Valid Name
        </b-form-invalid-feedback>
      </b-input-group>

      <!-- City State Zip -->
      <b-input-group id="text" size="sm" class="mb-2">
        <b-input-group-prepend is-text>
          <b-icon icon="building"></b-icon>
        </b-input-group-prepend>

        <b-form-input id="city" 
        placeholder="City"
        v-model="city"></b-form-input>
        <b-form-input id="state" 
        placeholder="State"
        v-model="state"></b-form-input>
        <b-form-input id="pin" 
        placeholder="Pin"
        v-model="pin"></b-form-input>

        <b-form-invalid-feedback id="input-live-feedback">
          Enter Valid Address Detail
        </b-form-invalid-feedback>
      </b-input-group>

      <!-- Mobile -->
      <b-input-group id="text" size="sm" class="mb-2">
        <b-input-group-prepend is-text>
          <b-icon icon="phone-fill"></b-icon>
        </b-input-group-prepend>

        <b-form-input
          id="phone"
          type="number"
          v-model="phone"
          :state="phoneState"
          aria-describedby="input-live-help input-live-feedback"
        ></b-form-input>

        <b-form-invalid-feedback id="input-live-feedback">
          Enter Valid Mobile Number
        </b-form-invalid-feedback>
        </b-input-group>

      <!-- Email -->
      <b-input-group id="text" size="sm" class="mb-2">
        <b-input-group-prepend is-text>
          <b-icon icon="envelope"></b-icon>
        </b-input-group-prepend>

        <b-form-input
          id="email"
          type="email"
          v-model="email"
          :state="emailState"
          aria-describedby="input-live-help input-live-feedback"
        ></b-form-input>

        <b-form-invalid-feedback id="input-live-feedback">
          Enter Valid Email
        </b-form-invalid-feedback>
        </b-input-group>

      <!-- //Password -->
      <b-input-group id="text1" size="sm" class="mb-2">
        <b-form-input
          v-model="password"
          :state="passState"
          v-bind:type="showPassword ? 'text' : 'password'"
          class="form-control"
          aria-describedby="input-live-help input-live-feedback"
          placeholder="Password"
        />

        <div class="input-group-append">
          <span
            id="eye"
            class="input-group-text"
            @click="showPassword = !showPassword"
          >
            <i
              id="eye"
              class="fa fa-eye"
              :class="[showPassword ? 'fa-eye' : 'fa-eye-slash']"
              aria-hidden="true"
            ></i>
          </span>
        </div>

        <b-form-invalid-feedback id="input-live-feedback">
          Enter Valid Password its Greater than 6
        </b-form-invalid-feedback>
      </b-input-group>

      <!-- Button -->
    <div id="buttons">
        <b-button id="rbtn" to="./Login">Login Instead</b-button>
      <b-button id="button" v-on:click="RegisterPost()">Register</b-button>
      <!-- <div id="forgot"> -->
      </div>
    </form>
  </div>
</template>

<style lang="scss" scoped>

#button {
}

//NAme
#lname {
  margin-left: 10px;
}

//City State Pin
#city{
  width: 40px;
}

#state{
  margin-left: 10px;
width: 40px;
}

#pin
{
  margin-left: 10px;
  width: 10px;  
}

//Login Instead 

#rbtn {
  background: none !important;
  border: none !important;
  padding: 0 !important;
  font-family: arial, sans-serif;
  color: blue;
  border-style: none;
  cursor: pointer;
  margin-bottom: 16px;
  border-color: white;
}

#rbtn {
  margin-left: 26px;
  margin-right: 40px;
}

//Login Button
#button {
  color: white;
  width: 160px;
  height: 40px;
  font-size: 18px;
  background-color: rgba(0, 140, 255, 0.911);
  margin-top: 20px;
  font-family: 'Times New Roman', Times, serif;
  margin-bottom: 30px;
  margin-left: 60px;
}
// Form
.md-layout {
  display: flex;
  justify-content: center;
  width: 46px;
  height: 84px;
  margin: auto;
}

//Whole Card
.card {
  display: flex;
  justify-content: center;
  margin-top: 12%;
  margin-left: 30%;
  width: 400px;
  border: solid 2px lightgray;
}

//Input Fields
#text {
  width: 360px;
  margin-left: 22px;
  margin-top: 20px;
}
#text1 {
  width: 360px;
  margin-left: 20px;
}
</style>

<script>
import userService from "../Services/userService";
export default {
  data() {
    return {
      showPassword: false,
      fname: '',
      lname: '',
      city: "",
      state: "",
      pin: "",
      phone: "",
      email: "",
      password: "",
      reg: /^(([^<>()[]\.,;:s@"]+(.[^<>()[]\.,;:s@"]+)*)|(".+"))@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}])|(([a-zA-Z-0-9]+.)+[a-zA-Z]{2,}))$/gim,
    };
  },

  methods: {
    // Register Employee //Adding Employee
    RegisterPost() {
      const userData = {
        firstName:this.fname,
        lastName:this.lname,
        mobile:this.phone,
        city:this.city,
        state:this.state,
        zip:this.pin,
        email: this.email,
        password: this.password,

      };
      userService
        .registration(userData)
        .then((response) => {
          setTimeout(() => this.redirect(), 1400);
          // this.$router.push("/Register");
          console.log(response.data.data);
        })
        .catch((error) => {
          console.log(error);
        });
    }, // Register
  },

  computed: {
    emailState() {
      return this.email ? true : false;
    },
    passState() {
      return this.password.length > 6 ? true : false;
    },
    phoneState(){
      return this.phone.length ==10 ? true : false;
    },
    addressState(){
      return this.pin.length ==6 ? true : false;      
    },
    nameState(){
      return this.fname > 5 ? true : false;
    },
    namesState(){
    return this.lname >5 ? true : false;  
    }
    
  },
};
</script>
