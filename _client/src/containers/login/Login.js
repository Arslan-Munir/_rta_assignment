import React, { useState } from "react";
import { Button, Form } from "react-bootstrap";
import "./Login.css";

export default function Login() {
  const [userName, setUsername] = useState("");
  const [password, setPassword] = useState("");

  function validateForm() {
    return userName.length > 0 && password.length > 0;
  }

  function handleSubmit(event) {
    console.log(userName, password);
    event.preventDefault();
  }

  return (
    <div className="Login">
      <Form onSubmit={handleSubmit}>
        <Form.Group size="lg">
          <Form.Label className="font-weight-bold text-muted">
            Username
          </Form.Label>
          <Form.Control
            autoFocus
            type="text"
            value={userName}
            onChange={(e) => setUsername(e.target.value)}
          />
        </Form.Group>

        <Form.Group size="lg">
          <Form.Label className="font-weight-bold text-muted">
            Password
          </Form.Label>
          <Form.Control
            autoFocus
            type="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Group>

        <Button block size="lg" type="submit" disabled={!validateForm()}>
          Login
        </Button>
      </Form>
    </div>
  );
}
