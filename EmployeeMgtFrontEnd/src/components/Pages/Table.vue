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
                  v-on:click="
                    SelectedEmployee(employees);
                  "
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
      <form  @submit.stop.prevent>
        <div
          card
          class="modal fade "
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
                <h4 class="modal-title" id="myModalLabel">
                  Employee Management
                </h4>

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
                    type="number"
                    v-model="currentEmployee.employeeId"
                    id="id"
                    aria-describedby="input-live-help input-live-feedback"
                    disabled
                    trim
                  ></b-form-input>

                  <b-form-input
                    id="fname"
                    v-model="currentEmployee.firstName"
                    aria-describedby="input-live-help input-live-feedback"
                    placeholder="First Name"
                  ></b-form-input>

                  <b-form-input
                    id="lname"
                    v-model="currentEmployee.lastName"
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
                    v-model="currentEmployee.city"
                  ></b-form-input>
                  
                  <b-form-input
                    id="state"
                    v-model="currentEmployee.state"
                  ></b-form-input>
                  
                  <b-form-input
                    id="pin"
                    v-model="currentEmployee.zip"
                  ></b-form-input>
                </b-input-group>

                <!-- Mobile -->
                <b-input-group id="text" size="sm" class="mb-2">
                  <b-input-group-prepend is-text>
                    <b-icon icon="phone-fill"></b-icon>
                  </b-input-group-prepend>

                  <b-form-input
                    id="phone"
                    type="number"
                    v-model="currentEmployee.mobile"
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
                    v-model="currentEmployee.email"
                    aria-describedby="input-live-help input-live-feedback"
                  ></b-form-input>
                </b-input-group>
              </div>
              <div class="modal-footer">
                <button type="button" 
                  data-dismiss="modal"
                v-on:click="UpdateEmployee(employees)"
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
      </form> <!-- MODALS -->
    </center>
  </div>
</template>

<script>
import employeeService from "../Services/employeeService";
export default {
  data() {
    return {
      employees: [],
      currentEmployee: {},
    };
  },

  mounted: function() {
    this.GetAllEmployee();
  },

  methods: {
    GetAllEmployee() {
      employeeService
        .getEmployees()
        .then((response) => {
          this.employees = response.data.data;
          console.log(response.data.data);
          console.log("the Data is Employee");
        })
        .catch((error) => {
          console.log(error);
        });
    }, //Get Employee
    
//Update Employee 
    UpdateEmployee(employees) {
      console.log("All Employee for Update ",employees);
      const employeeData = {
       employeeId:this.currentEmployee.employeeId,
        firstName: this.currentEmployee.firstName,
        lastName: this.currentEmployee.lastName,
        mobile: this.currentEmployee.mobile,
        city: this.currentEmployee.city,
        state: this.currentEmployee.state,
        zip: this.currentEmployee.zip,
        email: this.currentEmployee.email,
        password: this.currentEmployee.password,
      };
       console.log("Employe data for update is ",employeeData);
      employeeService
        .updateEmployee(employeeData,this.currentEmployee)
        .then((response) => {
          console.log("The Data is :",response.data.data);
          alert("Employee Record Updated Succesfully...");
          this.GetAllEmployee();
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
          console.log("The Response Data is: ",response);
          alert("Employee Remove Sussefully...");
          this.GetAllEmployee();
        })
        .catch((error) => {
          console.log(error);
        });
    }, //Remove Method

    SelectedEmployee(employees) {
      console.log("This is Employee Data ", employees);
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

//NAme
#lname {
  margin-left: 10px;
}

//City State Pin
#city {
  width: 40px;
}

#state {
  margin-left: 10px;
  width: 40px;
}

#pin {
  margin-left: 10px;
  width: 10px;
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
#id {
  margin-left: 2px;

  margin-right: 20px;
  width: 2px;
}
</style>
