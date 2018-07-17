import React, { Component } from 'react';
import { Label } from 'react-bootstrap';

export class Items extends Component {
  displayName = Items.name

  constructor(props) {
    super(props);
    this.state = { items: [], loading: true };

    fetch('api/items')
      .then(response => response.json())
      .then(data => {
        this.setState({ items: data, loading: false });
      });
  }

  static renderType(type) {
    if (!type || type === '?') {
      return '';
    }

    let style = 'default';
    style = type === 'sneaky' ? 'success' : style;
    style = type === 'chilly' ? 'info' : style;
    style = type === 'electro' ? 'warning' : style;
    style = type === 'spicy' ? 'danger' : style;

    return <Label bsStyle={style}>{type}</Label>;
  }

  static renderLocations(locations) {
    return (
      locations.map(location => (
        <React.Fragment key={location}>
          <Label bsStyle="default">{location}</Label>
          {' '}
        </React.Fragment>
      ))
    );
  }

  static renderItems(items) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Name</th>
            <th>Type</th>
            <th>HP</th>
            <th>Time</th>
            <th>Locations</th>
          </tr>
        </thead>
        <tbody>
          {items.map(item => (
            <tr key={item.id}>
              <td>{item.name}</td>
              <td>{this.renderType(item.type)}</td>
              <td>{item.hp}</td>
              <td>{item.time}</td>
              <td>{this.renderLocations(item.locations)}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Items.renderItems(this.state.items);

    return (
      <div>
        <h1>Items</h1>
        {contents}
      </div>
    );
  }
}