<template>
  <div class="card">
    <form id="card" @submit.stop.prevent>
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
      <b-button id="button" v-on:click="loginPost()">Login</b-button>
      <div id="forgot">
        <b-button id="fbtn">Forgot Password</b-button>
        <b-button id="rbtn">Register</b-button>
      </div>
    </form>
  </div>
</template>

<style lang="scss" scoped>
#password {
  width: 10px;
}
#button {
}
#email {
}

#eye {
  display: inline-flex;
}

#fbtn,
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
  margin-left: 80px;
}

#forgot {
}
//Login Button
#button {
  color: white;
  width: 200px;
  height: 40px;
  font-size: 20px;
  background-color: rgba(0, 140, 255, 0.911);
  margin-top: 20px;
  margin-bottom: 30px;
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

      email: "",
      password: "",
      reg: /^(([^<>()[]\.,;:s@"]+(.[^<>()[]\.,;:s@"]+)*)|(".+"))@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}])|(([a-zA-Z-0-9]+.)+[a-zA-Z]{2,}))$/gim,
    };
  },

  methods: {
    // loginUser
    loginPost() {
      const userData = {
        email: this.email,
        password: this.password,
      };
      userService
        .login(userData)
        .then((response) => {
          localStorage.setItem("AccessToken", response.data.data);
          localStorage.setItem("UserId", response.data.id);
          // setTimeout(() => this.redirect(), 1400);
          // this.$router.push("/Register");
          console.log(response.data.data);
        })
        .catch((error) => {
          console.log(error);
        });
    }, // Login User
  },

  computed: {
    emailState() {
      return this.email ? true : false;
    },
    passState() {
      return this.password.length > 6 ? true : false;
    },
  },
};
</script>
