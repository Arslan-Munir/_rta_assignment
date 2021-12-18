import Navbar from "react-bootstrap/Navbar";
import { Route } from "react-router-dom";
import "./App.css";
import Routes from "./Routes";

function App() {
  return (
    <div className="App container py-3">
      <Navbar collapseOnSelect bg="light" expand="md" className="mb-3">
        <Navbar.Brand className="font-weight-bold text-muted">
          Home
        </Navbar.Brand>
        <Navbar.Toggle />
      </Navbar>

      <Routes />
    </div>
  );
}

export default App;
