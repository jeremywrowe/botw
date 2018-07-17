import React, { Component } from 'react';
import { Label } from 'react-bootstrap';

export class Weapons extends Component {
  displayName = Weapons.name

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
      <table className='table'>
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
              <td>{weapon.name}</td>
              <td>{this.renderType(weapon.type)}</td>
              <td>{weapon.parry}</td>
              <td>{this.renderTags(weapon.powers)}</td>
              <td>{this.renderTags(weapon.locations)}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Weapons.renderWeapons(this.state.weapons);

    return (
      <div>
        <h1>Weapons</h1>
        {contents}
      </div>
    );
  }
}