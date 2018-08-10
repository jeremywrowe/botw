import React, { Component } from 'react';
import { Label } from 'react-bootstrap';
import Loader from './Loader';

export class Weapons extends Component {
  displayName = Weapons.name;

  constructor(props) {
    super(props);
    this.state = { weapons: [], loading: true };

    fetch('api/weapons')
      .then(response => response.json())
      .then(data => {
        this.setState({ weapons: data, loading: false });
      });
  }

  static renderType(type) {
    let style = 'default';
    style = type === 'sword' ? 'primary' : style;
    style = type === 'club' ? 'info' : style;
    style = type === 'shield' ? 'success' : style;
    style = type === 'bow' ? 'warning' : style;
    style = type === 'spear' ? 'danger' : style;
    return <Label bsStyle={style}>{type}</Label>;
  }

  static renderTags(locations) {
    return (
      locations.map(location => (
        <React.Fragment key={location}>
          <Label bsStyle="default">{location}</Label>
          {' '}
        </React.Fragment>
      ))
    );
  }

  static renderWeapons(weapons) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Name</th>
            <th>Type</th>
            <th>Parry</th>
            <th>Powers</th>
            <th>Locations</th>
          </tr>
        </thead>
        <tbody>
          {weapons.map(weapon => (
            <tr key={weapon.id}>
              <td data-title="Name">{weapon.name}</td>
              <td data-title="Type">{this.renderType(weapon.type)}</td>
              <td data-title="Parry">{weapon.parry}</td>
              <td data-title="Powers">{this.renderTags(weapon.powers)}</td>
              <td data-title="Locations">{this.renderTags(weapon.locations)}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <Loader />
      : Weapons.renderWeapons(this.state.weapons);

    return (
      <div>
        <h1>Weapons</h1>
        {contents}
      </div>
    );
  }
}