import axios from "axios";

const API_URL = "https://localhost:5001/api/v1/";

class AuthService {
  login(username, password) {
    return axios
      .post(API_URL + "auth", {
        username,
        password,
      })
      .then((response) => {
        if (response.data.token) {
          localStorage.setItem("user", JSON.stringify(response.data.token));
        }

        return response.data;
      });
  }

  logout() {
    localStorage.removeItem("user");
  }

  register(username, email, password) {
    return axios.post(API_URL + "signup", {
      username,
      email,
      password,
    });
  }

  getCurrentUser() {
    return JSON.parse(localStorage.getItem("user"));
  }
}

export default new AuthService();
