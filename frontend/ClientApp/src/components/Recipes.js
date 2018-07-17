import React, { Component } from 'react';
import { Glyphicon, Label } from 'react-bootstrap';

export class Recipes extends Component {
  displayName = Recipes.name

  constructor(props) {
    super(props);
    this.state = { recipes: [], loading: true };

    fetch('api/recipes')
      .then(response => response.json())
      .then(data => {
        this.setState({ recipes: data, loading: false });
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

  static renderIngredients(ingredients) {
    return (
      ingredients.map(ingredient => (
        <React.Fragment key={ingredient}>
          <Label bsStyle="default">{ingredient}</Label>
          {' '}
        </React.Fragment>
      ))
    );
  }

  static renderHearts(hearts)
  {
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

  static renderRecipes(recipes) {
    return (
      <table className='table table-striped table-responsive-lg'>
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
              <td>{recipe.name}</td>
              <td>{recipe.type}</td>
              <td>{this.renderHearts(recipe.hearts)}</td>
              <td>{this.renderIngredients(recipe.ingredients)}</td>
              <td>{this.renderIngredients(recipe.effects)}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : Recipes.renderRecipes(this.state.recipes);

    return (
      <div>
        <h1>Recipes</h1>
        {contents}
      </div>
    );
  }
}