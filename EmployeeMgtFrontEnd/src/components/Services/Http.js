import axios from 'axios'
const baseUrl = "https://localhost:5001/api"

export default
    {
        // Add Data 

        post(requestUrl, data) {
            return axios({
                method: 'post',
                url: `${baseUrl}${requestUrl}`,
                data: data,
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': localStorage.getItem("AccessToken")
                }
            })
        },
        // Get Data 

        get(requestUrl) {
            return axios({
                method: 'get',
                url: `${baseUrl}${requestUrl}`,
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': localStorage.getItem("AccessToken")
                }
            })
        },
        // Edit Method 

        PUT(requestUrl) {
            return axios({
                method: 'put',
                url: `${baseUrl}${requestUrl}`,
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': localStorage.getItem("AccessToken")
                }
            })
        },
        // Delete Method 

        DELETE(requestUrl) {
            return axios({
                method: 'DELETE',
                url: `${baseUrl}${requestUrl}`,
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': localStorage.getItem("AccessToken")
                }
            })
        }
    }