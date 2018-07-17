import React, { Component } from 'react';
import { Label } from 'react-bootstrap';
import Loader from './Loader';

export class Clothing extends Component {
  displayName = Clothing.name

  constructor(props) {
    super(props);
    this.state = { clothing: [], loading: true };

    fetch('api/clothing')
      .then(response => response.json())
      .then(data => {
        this.setState({ clothing: data, loading: false });
      });
  }

  static renderType(type) {
    let style = 'default';
    style = type === 'body' ? 'success' : style;
    style = type === 'leg' ? 'warning' : style;

    return <Label bsStyle={style}>{type}</Label>;
  }

  static renderRatings(ratings) {
    return (
      ratings.map(rating => {
        let style = 'default';
        style = rating.indexOf('heat') >= 0 || rating.indexOf('flame') >= 0 || rating.indexOf('fire') >= 0 ? 'danger' : style;
        style = rating.indexOf('cold') >= 0 ? 'primary' : style;
        style = rating.indexOf('stealth') >= 0 ? 'info' : style;
        style = rating.indexOf('shock') >= 0 || rating.indexOf('lighting') >= 0 ? 'warning' : style;
        style = rating.indexOf('speed') >= 0 ? 'success' : style;

        return (
          <React.Fragment key={rating}>
            <Label bsStyle={style}>{rating}</Label>
            {' '}
          </React.Fragment>
        );
      })
    );
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

  static renderClothing(clothing) {
    return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Name</th>
            <th>Type</th>
            <th>Defense</th>
            <th>Ratings</th>
            <th>Locations</th>
          </tr>
        </thead>
        <tbody>
          {clothing.map(item => (
            <tr key={item.name}>
              <td data-title="Name">{item.name}</td>
              <td data-title="Type">{this.renderType(item.type)}</td>
              <td data-title="Defense">{item.defense}</td>
              <td data-title="Ratings">{this.renderRatings(item.ratings)}</td>
              <td data-title="Locations">{this.renderLocations(item.locations)}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <Loader />
      : Clothing.renderClothing(this.state.clothing);

    return (
      <div>
        <h1>Clothing</h1>
        {contents}
      </div>
    );
  }
}