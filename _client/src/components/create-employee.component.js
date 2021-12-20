import React, { useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { Modal } from "react-bootstrap";
import Form from "react-validation/build/form";
import Input from "react-validation/build/input";
import CheckButton from "react-validation/build/button";

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
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  function createEmployee(e) {
    e.preventDefault();

    console.log(username);
    console.log(password);
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
              <label htmlFor="username">Username</label>
              <Input
                type="text"
                className="form-control"
                name="username"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                validations={[required]}
              />
              <small className="text-muted">
                Registered user: arslan-munir
              </small>
            </div>

            <div className="form-group">
              <label htmlFor="password">Password</label>
              <Input
                type="password"
                className="form-control"
                name="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                validations={[required]}
              />
              <small className="text-muted">Password: fakePass-123</small>
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
          <Button variant="secondary" onClick={handleClose}>
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
