import React, { useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { Modal } from "react-bootstrap";
import Form from "react-validation/build/form";
import Input from "react-validation/build/input";
import Api from "../configs/Api";
import employeeService from "../services/employee.service";

const required = (value) => {
  if (!value) {
    return (
      <p className="text-danger mt-1" role="alert">
        This field is required!
      </p>
    );
  }
};

export default function CreateEmployee() {
  const [message, setMessage] = useState("");
  const [loading, setLoading] = useState(true);
  const [name, setName] = useState("");
  const [nationality, setNationality] = useState("");
  const [designation, setDesignation] = useState("");
  const [mobileNo, setMobileNo] = useState("");
  const [email, setEmail] = useState("");
  const [passportNo, setPassportNo] = useState("");
  const [passportExpireDate, setPassportExpireDate] = useState("");

  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  async function createEmployee(e) {
    let res = await employeeService.create({
      name: name,
      nationality: nationality,
      typeId: 1,
      designation: designation,
      mobileNo: mobileNo,
      email: email,
      passportNo: Number(passportNo),
      passportExpireDate: passportExpireDate,
    });

    setShow(false);
  }

  return (
    <>
      <Button variant="secondary" onClick={handleShow}>
        Create
      </Button>

      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Create Employee</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form onSubmit={createEmployee}>
            <div className="form-group">
              <label htmlFor="name">Name</label>
              <Input
                type="text"
                className="form-control"
                name="name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="password">Nationality</label>
              <Input
                type="text"
                className="form-control"
                name="nationality"
                value={nationality}
                onChange={(e) => setNationality(e.target.value)}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="password">Designation</label>
              <Input
                type="text"
                className="form-control"
                name="nationality"
                value={designation}
                onChange={(e) => setDesignation(e.target.value)}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="password">Mobile No</label>
              <Input
                type="text"
                className="form-control"
                name="mobileNo"
                value={mobileNo}
                onChange={(e) => setMobileNo(e.target.value)}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="password">Email</label>
              <Input
                type="email"
                className="form-control"
                name="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="password">Passport No</label>
              <Input
                type="number"
                className="form-control"
                name="passportNo"
                value={passportNo}
                onChange={(e) => setPassportNo(e.target.value)}
                validations={[required]}
              />
            </div>

            <div className="form-group">
              <label htmlFor="password">Passport Expire Date</label>
              <Input
                type="date"
                className="form-control"
                name="passportExpireDate"
                value={passportExpireDate}
                onChange={(e) => setPassportExpireDate(e.target.value)}
                validations={[required]}
              />
            </div>

            {message && (
              <div className="form-group mt-1">
                <div className="alert alert-danger" role="alert">
                  {message}
                </div>
              </div>
            )}
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="danger" onClick={handleClose}>
            Close
          </Button>
          <Button variant="secondary" onClick={createEmployee}>
            {!loading && (
              <span className="spinner-border spinner-border-sm"></span>
            )}
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}
