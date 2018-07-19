import React, { Component } from 'react';
import { Button, Glyphicon, Label } from 'react-bootstrap';
import Loader from './Loader';

export class Recipes extends Component {
  displayName = Recipes.name

  constructor(props) {
    super(props);
    this.state = { recipes: [], loading: true, ingredients: [], types: [] };
    this.loadData();
  }

  loadData = () => {
    fetch(`api/recipes?ingredients=${this.state.ingredients.join(',')}&types=${this.state.types.join(',')}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ recipes: data, loading: false });
      });
  }

  addIngredient = (ingredient) => {
    this.setState({ ingredients: [...this.state.ingredients, ingredient], loading: true }, this.loadData);
  }

  removeIngredient = (ingredient) => {
    const { ingredients } = this.state;
    const index = ingredients.indexOf(ingredient);
    this.setState({ ingredients: [...ingredients.slice(0, index), ...ingredients.slice(index + 1)], loading: true }, this.loadData);
  }

  renderIngredients = (ingredients, selected) => {
    return (
      ingredients.map(ingredient => (
        <React.Fragment key={ingredient}>
          <Button
            bsSize="xsmall"
            bsStyle={selected.indexOf(ingredient) >= 0 ? 'success' : 'default'}
            onClick={() => this.addIngredient(ingredient)}
          >
            {ingredient}
          </Button>
          {' '}
        </React.Fragment>
      ))
    );
  }

  toggleType = (type) => {
    if (this.state.types.indexOf(type) >= 0) {
      this.removeType(type);
    } else {
      this.addType(type);
    }
  }

  addType = (type) => {
    this.setState({ types: [...this.state.types, type], loading: true }, this.loadData);
  }

  removeType = (type) => {
    const { types } = this.state;
    const index = types.indexOf(type);
    this.setState({ types: [...types.slice(0, index), ...types.slice(index + 1)], loading: true }, this.loadData);
  }

  renderType = (type, selected) => {
    return (
      <Button
        bsSize="xsmall"
        bsStyle={selected.indexOf(type) >= 0 ? 'success' : 'default'}
        onClick={() => this.toggleType(type)}
      >
        {type}
      </Button>
    );
  }

  renderHearts = (hearts) => {
    return (
      <React.Fragment>
        <Glyphicon glyph={hearts > 0 ? 'heart' : 'heart-empty'} />
        <Glyphicon glyph={hearts > 1 ? 'heart' : 'heart-empty'} />
        <Glyphicon glyph={hearts > 2 ? 'heart' : 'heart-empty'} />
        <Glyphicon glyph={hearts > 3 ? 'heart' : 'heart-empty'} />
        <Glyphicon glyph={hearts > 4 ? 'heart' : 'heart-empty'} />
        <Glyphicon glyph={hearts > 5 ? 'heart' : 'heart-empty'} />
        <Glyphicon glyph={hearts > 6 ? 'heart' : 'heart-empty'} />
        <Glyphicon glyph={hearts > 7 ? 'heart' : 'heart-empty'} />
      </React.Fragment>
    )
  }

  renderRecipes = (recipes, types, ingredients) => {
    return (
      <React.Fragment>
        <div>
          <h4>Filters:</h4>
          <table className='table'>
            <tbody>
              <tr>
                <td>Types</td>
                <td>
                  {['generic', 'chill', 'elixir', 'shock', 'energy', 'hearty', 'mighty', 'sneak', 'warmth', 'defense'].map(type => (
                    <React.Fragment key={type}>
                      <Button bsStyle={ types.indexOf(type) >= 0 ? 'danger' : 'success' } bsSize="xsmall" onClick={() => this.toggleType(type)}>
                        {type}{ ' ' }
                        <Glyphicon glyph="remove-sign" />
                      </Button>
                      {' '}
                    </React.Fragment>
                  ))}
                </td>
              </tr>
              <tr>
                <td>Ingredients</td>
                <td>
                  {ingredients.map(ingredient => (
                    <React.Fragment key={ingredient}>
                      <Button bsStyle="success" bsSize="xsmall" onClick={() => this.removeIngredient(ingredient)}>
                        {ingredient}{ ' ' }
                        <Glyphicon glyph="remove-sign" />
                      </Button>
                      {' '}
                    </React.Fragment>
                  ))}
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <table className='table table-striped'>
          <thead>
            <tr>
              <th>Name</th>
              <th>Type</th>
              <th>Hearts</th>
              <th>Ingredients</th>
              <th>Effects</th>
            </tr>
          </thead>
          <tbody>
            {recipes.map(recipe => (
              <tr key={recipe.name}>
                <td data-title="Name">{recipe.name}</td>
                <td data-title="Type">{this.renderType(recipe.type, types)}</td>
                <td data-title="Hearts">{this.renderHearts(recipe.hearts)}</td>
                <td data-title="Ingerdients">{this.renderIngredients(recipe.ingredients, ingredients)}</td>
                <td data-title="Effects">{this.renderIngredients(recipe.effects, [])}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </React.Fragment>
    );
  }

  render() {
    const { types, ingredients, recipes } = this.state;
    let contents = this.state.loading
      ? <Loader />
      : this.renderRecipes(recipes, types, ingredients);

    return (
      <div>
        <h1>Recipes</h1>
        {contents}
      </div>
    );
  }
}