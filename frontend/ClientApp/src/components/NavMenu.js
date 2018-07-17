import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to={'/items'}>Breath of the Wild</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        <Navbar.Collapse>
          <Nav>
            <LinkContainer to={'/items'}>
              <NavItem>
                <Glyphicon glyph='heart' /> Items
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/clothing'}>
              <NavItem>
                <Glyphicon glyph='user' /> Clothing
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/recipes'}>
              <NavItem>
                <Glyphicon glyph='cutlery' /> Recipes
              </NavItem>
            </LinkContainer>
            <LinkContainer to={'/weapons'}>
              <NavItem>
                <Glyphicon glyph='flash' /> Weapons
              </NavItem>
            </LinkContainer>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}
