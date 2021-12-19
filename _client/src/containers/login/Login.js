import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";
import "./Login.css";
import Image from "react-bootstrap/Image";
import Api from "../../configs/Api";

export default function Login() {
  const [userName, setUsername] = useState("");
  const [password, setPassword] = useState("");

  function validateForm() {
    return userName.length > 0 && password.length > 0;
  }

  function handleSubmit(event) {
    Api.post("auth", {
      username: "arslan-munir",
      password: "fakePass-123",
    }).then((res) => {
      console.log(res.data);
    });

    event.preventDefault();
  }

  return (
    <div className="container">
      <div className="d-flex flex-row align-items-center justify-content-center">
        <div className="card col col-sm col-lg-5 col-md-8">
          <Form onSubmit={handleSubmit}>
            <Image
              className="m-3 img-responsive rounded-circle mx-auto d-block"
              src="https://bulma.io/images/placeholders/128x128.png"
            />
            <Form.Group size="lg">
              <Form.Control
                placeholder="Username"
                autoFocus
                type="text"
                value={userName}
                onChange={(e) => setUsername(e.target.value)}
              />
              <Form.Text className="text-muted" size="sm">
                Registered user: arslan-munir
              </Form.Text>
            </Form.Group>

            <Form.Group size="lg">
              <Form.Control
                placeholder="Password"
                autoFocus
                type="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
              <Form.Text className="text-muted" size="sm">
                Password: fakePass-123
              </Form.Text>
            </Form.Group>

            <div className="text-center">
              <Button
                className="btn btn-secondary m-2"
                type="submit"
                disabled={!validateForm()}
              >
                Login
              </Button>
            </div>
          </Form>
        </div>
      </div>
    </div>
  );
}
