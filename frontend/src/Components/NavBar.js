import React from "react";
import { Nav, Navbar } from "react-bootstrap";
import { DiTerminal } from "react-icons/di";

const NavBar = () => {
  return (
    <React.Fragment>
      <Navbar bg="primary" variant="dark">
        <Navbar.Brand href="/">
          <DiTerminal />
        </Navbar.Brand>
        <Nav className="mr-auto">
          <Nav.Link href="/">Requisicion</Nav.Link>
          <Nav.Link href="/movimientos">Movimientos</Nav.Link>
          <Nav.Link href="/revert">Revertir</Nav.Link>
        </Nav>
      </Navbar>
    </React.Fragment>
  );
};

export default NavBar;
