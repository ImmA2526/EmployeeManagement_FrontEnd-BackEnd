import http from './Http'
class UserRegister {

    registration(userData) {
        return http.post('/Employee', userData)
    }

    login(userData) {
        return http.post(`/Employee/Login`, userData)
    }

    forgot(email) {
        console.log(email);
        return http.get(`/Employee/` + email, null)
    }

    reset(userData) {
        return http.PUT(`/Employee`, userData)
    }

}

export default new UserRegister