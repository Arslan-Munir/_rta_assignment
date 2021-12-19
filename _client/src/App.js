import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import "./App.css";
import Routes from "./Routes";

function App() {
  return (
    <div className="App container py-3">
      <Navbar collapseOnSelect bg="light" expand="md" className="mb-3">
        {/* <LinkContainer to="/"> */}
        <Navbar.Brand className="font-weight-bold text-muted">
          Home
        </Navbar.Brand>
        {/* </LinkContainer> */}
        <Navbar.Toggle />

        <Navbar.Collapse className="justify-content-end">
          <Nav activeKey={window.location.pathname}>
            {/* <LinkContainer to="/signup"> */}
            <Nav.Link href="/signup">Signup</Nav.Link>
            {/* </LinkContainer> */}

            {/* <LinkContainer to="/login"> */}
            <Nav.Link href="/login">Login</Nav.Link>
            {/* </LinkContainer> */}
          </Nav>
        </Navbar.Collapse>
      </Navbar>

      <Routes />
    </div>
  );
}

export default App;
