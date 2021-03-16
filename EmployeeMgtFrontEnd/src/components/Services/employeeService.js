import http from "./Http"

class employeeService {

// Retrive Employee all
    getEmployees() {
        console.log("The Employee Details are Calling From Service Service :")
        return http.get(`/Employee`)
    }

// Display Employee By Id
    getEmployee(employeeId) {
        console.log("Retriving Employee From Service ",employeeId);
        return http.get(`/Employee/getBy/`+employeeId)
    }

// Update Employee
    updateEmployee(employeeData) {
        console.log("The Service Calling For Update :",employeeData);
        return http.PUT(`/Employee`,employeeData)
    }

//Remove Employee 
    RemoveEmployee(employeeId) {
        console.log("This is Employee From Service : ",employeeId);
        return http.DELETE(`/Employee/`+employeeId)
    }
}
export default new employeeService