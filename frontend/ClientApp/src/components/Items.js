import React, { Component } from 'react';
import { Label } from 'react-bootstrap';
import Loader from './Loader';
import Switch from './Switch';
import { Recipes } from './Recipes';

export class Items extends Component {
  displayName = Items.name;

  constructor(props) {
    super(props);
    this.state = { items: [], loading: true, expanded: [] };

    fetch('api/items')
      .then(response => response.json())
      .then(data => {
        this.setState({ items: data, loading: false });
      });
  }

  expand = (item) => {
    const index = this.state.expanded.indexOf(item);
    if (index >= 0) {
      this.setState({ expanded: [...this.state.expanded.slice(0, index), ...this.state.expanded.slice(index + 1)] });
    } else {
      this.setState({ expanded: [...this.state.expanded, item] });
    }
  }

  renderType = (type) => {
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

  renderLocations = (locations) => {
    return (
      locations.map(location => (
        <React.Fragment key={location}>
          <Label bsStyle="default">{location}</Label>
          {' '}
        </React.Fragment>
      ))
    );
  }

  renderItems = (items) => {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Name</th>
            <th>Type</th>
            <th>HP</th>
            <th>Time</th>
            <th>Locations</th>
            <th>Recipes</th>
          </tr>
        </thead>
        <tbody>
          {items.map(item => (
            <React.Fragment key={item.id}>
              <tr>
                <td data-title="Name">
                  {item.name}
                </td>
                <td data-title="Type">{this.renderType(item.type)}</td>
                <td data-title="HP">{item.hp}</td>
                <td data-title="Time">{item.time}</td>
                <td data-title="Locations">{this.renderLocations(item.locations)}</td>
                <td data-title="Recipes">
                  {item.recipes.length > 0 ? (
                    <Switch
                      label={this.state.expanded.indexOf(item) >= 0 ? 'hide' : 'show'}
                      onClick={() => this.expand(item)}
                      selected={this.state.expanded.indexOf(item) >= 0}
                    />
                  ) : ''}
                </td>
              </tr>
              {
                item.recipes.length > 0 && this.state.expanded.indexOf(item) >= 0 && (
                  <tr>
                    <td className="nested-table" colspan={6}><Recipes recipes={item.recipes} /></td>
                  </tr>
                )
              }
            </React.Fragment>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <Loader />
      : this.renderItems(this.state.items);

    return (
      <div>
        <h1>Items</h1>
        {contents}
      </div>
    );
  }
}