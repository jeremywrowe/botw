import React, { Component } from 'react';
import { Glyphicon, Label } from 'react-bootstrap';
import Loader from './Loader';
import Switch from './Switch';
import qs from 'qs';

const EFFECTS = [
  'attack',
  'cold',
  'defense',
  'electric',
  'fireproof',
  'heat',
  'speed',
  'stamina',
  'stealth',
  'temporary ❤'
];

const mapEffect = (effect) => {
  const found = EFFECTS.find(mappedEffect => effect.indexOf(mappedEffect) >= 0);
  return found ? found : null;
};

export class Recipes extends Component {
  displayName = Recipes.name;

  constructor(props) {
    super(props);
    this.state = { recipes: props.recipes || [], loading: !props.recipes, ingredients: [], types: [], effects: [], nested: !props.recipes };
    const query = qs.parse(window.location.search);

    if (props.recipes) {
      return;
    }

    if (query.ingredients) {
      this.state.ingredients = query.ingredients.split(',');
    }

    if (query.types) {
      this.state.types = query.types.split(',');
    }

    if (query.effects) {
      this.state.effects = query.effects.split(',');
    }

    this.loadData();
  }

  componentDidMount = () => window.addEventListener('popstate', this.popState);

  componentWillUnmount = () => window.removeEventListener('popstate', this.popState);

  popState = (event) => {
    this.setState(event.state, this.loadData);
  }

  buildFilterUrl = () => {
    const queryParams = [];

    if (this.state.ingredients.length > 0) {
      queryParams.push(`ingredients=${this.state.ingredients.join(',')}`);
    }

    if (this.state.types.length > 0) {
      queryParams.push(`types=${this.state.types.join(',')}`);
    }

    if (this.state.effects.length > 0) {
      queryParams.push(`effects=${this.state.effects.join(',')}`);
    }

    return queryParams.length > 0 ? `recipes?${queryParams.join('&')}` : 'recipes';
  }

  loadData = () => {
    const filterUrl = this.buildFilterUrl();
    window.history.pushState(this.state, 'Recipe with filters', filterUrl);
    fetch(`api/${filterUrl}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ recipes: data, loading: false });
      });
  }

  addFilter = (key, item) => {
    this.setState({ [key]: [...this.state[key], item], loading: true }, this.loadData);
  }

  removeFilter = (key, item) => {
    const items = this.state[key];
    const index = items.indexOf(item);
    this.setState({ [key]: [...items.slice(0, index), ...items.slice(index + 1)], loading: true }, this.loadData);
  }

  toggleFilter = (key, item) => {
    if (!this.state.nested) {
      return false;
    }

    if (this.state[key].indexOf(item) >= 0) {
      this.removeFilter(key, item);
    } else {
      this.addFilter(key, item);
    }
  }

  renderIngredients = (ingredients, selected) => {
    return (
      ingredients.map(ingredient => (
        <React.Fragment key={ingredient}>
          <Switch label={ingredient} onClick={() => this.toggleFilter('ingredients', ingredient)} selected={selected.indexOf(ingredient) >= 0} />
          {' '}
        </React.Fragment>
      ))
    );
  }

  renderEffects = (effects, selected) => {
    return (
      effects.map(effect => {
        const mappedEffect = mapEffect(effect);
        return (
          <React.Fragment key={mappedEffect}>
            {mappedEffect
              ? <Switch label={mappedEffect} onClick={() => this.toggleFilter('effects', mappedEffect)} selected={selected.indexOf(mappedEffect) >= 0} /> 
              : <Label>{effect}</Label>
            }
            {' '}
          </React.Fragment>
        )
      })
    );
  }

  renderType = (type, selected) => {
    return (
      <Switch label={type} onClick={() => this.toggleFilter('types', type)} selected={selected.indexOf(type) >= 0} />
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

  renderFilters = (types, ingredients, effects) => (
    <div>
      <h4>Filters:</h4>
      <table className='table'>
        <tbody>
          <tr>
            <td>Types</td>
            <td>
              {['generic', 'chill', 'elixir', 'shock', 'energy', 'hearty', 'mighty', 'sneak', 'warmth', 'defense'].sort().map((type) => (
                <React.Fragment key={type}>
                  <Switch selected={types.indexOf(type) >= 0} label={type} onClick={() => this.toggleFilter('types', type)} />
                  &nbsp;
                </React.Fragment>
              ))}
            </td>
          </tr>
          <tr>
            <td>Ingredients</td>
            <td>
              {ingredients.map(ingredient => (
                <React.Fragment key={ingredient}>
                  <Switch label={ingredient} onClick={() => this.toggleFilter('ingredients', ingredient)} selected={true} />
                  {' '}
                </React.Fragment>
              ))}
              {ingredients.length === 0 ? 'None selected' : null}
            </td>
          </tr>
          <tr>
            <td>Effects</td>
            <td>
              {EFFECTS.map(effect => (
                <React.Fragment key={effect}>
                  <Switch label={effect} onClick={() => this.toggleFilter('effects', effect)} selected={effects.indexOf(effect) >= 0} />
                  {' '}
                </React.Fragment>
              ))}
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  )

  renderRecipes = (recipes, types, ingredients, effects) => {
    return (
      <React.Fragment>
        {this.state.renderFilters && this.renderFilters(types, ingredients, effects)}
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
                <td className="fit" data-title="Name">{recipe.name}</td>
                <td data-title="Type">{this.renderType(recipe.type, types)}</td>
                <td className="fit" data-title="Hearts">{this.renderHearts(recipe.hearts)}</td>
                <td data-title="Ingerdients">{this.renderIngredients(recipe.ingredients, ingredients)}</td>
                <td data-title="Effects">{this.renderEffects(recipe.effects, effects)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </React.Fragment>
    );
  }

  render() {
    const { types, ingredients, recipes, effects } = this.state;
    let contents = this.state.loading
      ? <Loader />
      : this.renderRecipes(recipes, types, ingredients, effects);

    return (
      <div>
        {this.state.nested && <h1>Recipes</h1>}
        {contents}
      </div>
    );
  }
}