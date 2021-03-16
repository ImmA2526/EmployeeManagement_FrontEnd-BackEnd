<template>
  <div id="main">
    <center>
      <div class="col-lg-6 ">
        <table class="table table-bordered table-striped">
          <thead>
            <th
              colspan="5"
              class="text-center bg-info text-light"
              scope="colgroup"
            >
              Personal Details
            </th>
            <th
              colspan="3"
              class="text-center bg-info text-light"
              scope="colgroup"
            >
              Address Detail
            </th>
            <th
              colspan="2"
              class="text-center bg-info text-light"
              scope="colgroup"
            >
              Actions
            </th>
            <tr class="text-center bg-info text-light">
              <th scope="col">EmployeeId</th>
              <th scope="col">First Name</th>
              <th scope="col">Last Name</th>
              <th scope="col">Mobile No.</th>
              <th scope="col">Email Id</th>
              <th scope="col">City</th>
              <th scope="col">State</th>
              <th scope="col">Zip</th>
              <th>Edit</th>
              <th>Delete</th>
            </tr>
          </thead>

          <tbody>
            <tr
              class="text-center"
              v-for="employees in employees"
              :key="employees._id"
            >
              <td>{{ employees.employeeId }}</td>
              <td>{{ employees.firstName }}</td>
              <td>{{ employees.lastName }}</td>
              <td>{{ employees.mobile }}</td>
              <td>{{ employees.email }}</td>
              <td>{{ employees.city }}</td>
              <td>{{ employees.state }}</td>
              <td>{{ employees.zip }}</td>
              <td>
                <a
                  href="#"
                  class="text-success"
                  data-toggle="modal"
                  data-target="#myModal"
                  v-on:click="GetParticularEmployee(employees.employeeId)"
                  ><i class="fa fa-edit"
                /></a>
              </td>
              <td>
                <a
                  href="#"
                  class="text-danger"
                  v-on:click="RemoveParticularEmployee(employees.employeeId)"
                  ><i class="fa fa-trash-alt"
                /></a>
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <!-- MODALS Edit Purpose -->
      <div
        class="modal fade"
        id="myModal"
        tabindex="-1"
        role="dialog"
        aria-labelledby="myModalLabel"
        aria-hidden="true"
        data-backdrop="false"
      >
        <div class="modal-dialog custom-class">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title" id="myModalLabel">Employee Management</h4>

              <button
                type="button"
                class="close"
                data-dismiss="modal"
                aria-hidden="true"
              >
                ×
              </button>
            </div>
            <div class="modal-body">
              <!--Names-->
              <b-input-group id="text" size="sm" class="mb-2">
                <b-input-group-prepend is-text>
                  <b-icon icon="person-fill"></b-icon>
                </b-input-group-prepend>

                <b-form-input
                  id="fname"
                  aria-describedby="input-live-help input-live-feedback"
                  placeholder="First Name"
                  v-model="employees.city"
                  trim
                ></b-form-input>
                <b-form-input
                  id="lname"
                  aria-describedby="input-live-help input-live-feedback"
                  placeholder="Last name"
                  trim
                ></b-form-input>
              </b-input-group>

              <!-- City State Zip -->
              <b-input-group id="text" size="sm" class="mb-2">
                <b-input-group-prepend is-text>
                  <b-icon icon="building"></b-icon>
                </b-input-group-prepend>

                <b-form-input
                  id="city"
                  placeholder="City"
                  v-model="employees.city"
                ></b-form-input>
                <b-form-input id="state" placeholder="State"></b-form-input>
                <b-form-input id="pin" placeholder="Pin"></b-form-input>
              </b-input-group>

              <!-- Mobile -->
              <b-input-group id="text" size="sm" class="mb-2">
                <b-input-group-prepend is-text>
                  <b-icon icon="phone-fill"></b-icon>
                </b-input-group-prepend>

                <b-form-input
                  id="phone"
                  type="number"
                  aria-describedby="input-live-help input-live-feedback"
                ></b-form-input>
              </b-input-group>

              <!-- Email -->
              <b-input-group id="text" size="sm" class="mb-2">
                <b-input-group-prepend is-text>
                  <b-icon icon="envelope"></b-icon>
                </b-input-group-prepend>

                <b-form-input
                  id="email"
                  type="email"
                  aria-describedby="input-live-help input-live-feedback"
                ></b-form-input>
              </b-input-group>
            </div>
            <div class="modal-footer">
              <button type="button" 
              class="btn btn-primary btn-sm">
                Update Changes
              </button>
              <button
                type="button"
                class="btn btn-light btn-sm  "
                data-dismiss="modal"
              >
                Close
              </button>

            </div>
          </div>
        </div>
      </div>
    </center>
  </div>
</template>

<script>
import employeeService from "../Services/employeeService";
export default {
  data() {
    return {
      modalShown: false,
      employees: [],
      currentEmployee: [],
    };
  },

  mounted: function() {
    this.GetAllEmployee();
  },

  methods: {
    GetAllEmployee() {
      // this.Loadding = true;
      employeeService
        .getEmployees()
        .then((response) => {
          this.employees = response.data.data;
          console.log(response.data.data);
          // this.Loadding = false;
          console.log("the Data is Employee");
        })
        .catch((error) => {
          console.log(error);
        });
    }, //Get Employee

    //Edit Employee By Id

    GetParticularEmployee(employeeId) {
      // this.Loadding = true;
      employeeService
        .getEmployee(employeeId)
        .then((response) => {
          this.employees = response.data.data;
          console.log(response.data.data);
          // this.Loadding = false;
          console.log("the Data is Employee");
        })
        .catch((error) => {
          console.log(error);
        });
    }, //Get Employee

    UpdateEmployee() {
      const employeeData = {
        firstName: this.fname,
        lastName: this.lname,
        mobile: this.phone,
        city: this.city,
        state: this.state,
        zip: this.pin,
        email: this.email,
        password: this.password,
      };
      employeeService
        .getEmployee(employeeData)
        .then((response) => {
          // localStorage.setItem("AccessToken", response.data.data);
          // localStorage.setItem("UserId", response.data.id);
          setTimeout(() => this.redirect(), 1400);
          // this.$router.push("/Register");
          console.log(response.data.data);
        })
        .catch((error) => {
          console.log(error);
        });
    }, // Update Employee

    ///Remove Employee
    RemoveParticularEmployee(employeeId) {
      console.log(employeeId);
      employeeService
        .RemoveEmployee(employeeId)
        .then((response) => {
          alert("Employee Remove Sussefully...");
          this.GetAllEmployee();
          //  setTimeout(()=>1000   ,this.GetAllEmployee());
          console.log(response);
        })
        .catch((error) => {
          console.log(error);
        });
    }, //Remove Method

    SelectedEmployee(employees) {
      this.currentEmployee = employees;
    },
  },
};
</script>

<style lang="scss" scoped>
.modal {
  position: fixed;
  top: 124px;
  left: 220px;
  z-index: 1050;
  display: none;
  width: 100%;
  height: 100%;
  overflow: hidden;
  outline: 0;
  background-color: transparent;
  overflow: visible;
}

div.modal-content {
  -webkit-box-shadow: none;
  -moz-box-shadow: none;
  -o-box-shadow: none;
  box-shadow: none;
}

.modal-footer {
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    justify-content: flex-end;
    border-top: 1px solid #dee2e6;
    border-bottom-right-radius: calc(0.3rem - 1px);
    border-bottom-left-radius: calc(0.3rem - 1px);
    background-color: #00ff1f57;
}

.modal-header {
    display: flex;
    align-items: flex-start;
    justify-content: space-between;
    border-bottom: 1px solid #dee2e6;
    border-top-left-radius: calc(0.3rem - 1px);
    border-top-right-radius: calc(0.3rem - 1px);
    background-color: #00ff1f57;

}
</style>



