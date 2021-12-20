import axios from "axios";
import authHeader from "./auth-header";
import Api from "../configs/Api";

class EmployeeService {
  async getAll() {
    return await Api.get("employee/all", { headers: authHeader() });
  }
}

export default new EmployeeService();
