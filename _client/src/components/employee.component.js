import React, { Component } from "react";
import authService from "../services/auth-service";
import employeeService from "../services/employee.service";
import CreateEmployee from "./create-employee.component";

export default class Employee extends Component {
  employees = [];

  constructor(props) {
    super(props);

    this.state = {
      currentUser: authService.getCurrentUser(),
      data: null,
    };
  }

  async componentDidMount() {
    let res = await employeeService.getAll();
    this.setState({ data: res.data });
  }

  async create() {}

  render() {
    const { data } = this.state;

    if (!data) {
      return <div>Loading...</div>;
    }

    const headings = Object.keys(data[0]);

    return (
      <div className="container">
        <header className="jumbotron">
          <h3>Employees</h3>

          <CreateEmployee></CreateEmployee>
        </header>

        <table className="table">
          <thead>
            <tr>
              <th scope="col">Id</th>
              <th scope="col">Name</th>
              <th scope="col">Phone Number</th>
              <th scope="col">Email</th>
              <th scope="col">Photo</th>
              <th scope="col">Designation</th>
              <th scope="col">Nationality</th>
              <th scope="col">Passport No</th>
              <th scope="col">Passport Expire Date</th>
            </tr>
          </thead>
          <tbody>
            {data.map((row) => (
              <tr>
                {headings.map((heading) => (
                  <td>{row[heading]}</td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}
