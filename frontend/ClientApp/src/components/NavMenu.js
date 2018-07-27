import React, { Component } from 'react';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

export class NavMenu extends Component {
  displayName = NavMenu.name

  render() {
    return (
      <Navbar inverse fixedTop collapseOnSelect>
        <Navbar.Header>
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
                <Glyphicon glyph='sunglasses' /> Clothing
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
