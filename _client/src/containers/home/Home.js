import React from "react";
import Login from "../login/Login";
import "./Home.css";

export default function Home() {
  return (
    <div className="Home">
      <div className="lander">
        <Login />
      </div>
    </div>
  );
}
