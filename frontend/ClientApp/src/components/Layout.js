import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
  displayName = Layout.name

  render() {
    return (
      <React.Fragment>
        <div>
          <NavMenu />
        </div>
        <div className="container">
          {this.props.children}
        </div>
      </React.Fragment>
    );
  }
}
