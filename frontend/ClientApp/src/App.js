import React, { Component } from 'react';
import { Route, Redirect } from 'react-router';
import { Layout } from './components/Layout';
import { Items } from './components/Items';
import { Clothing } from './components/Clothing';
import { Recipes } from './components/Recipes';
import { Weapons } from './components/Weapons';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route path='/items' component={Items} />
        <Route path='/clothing' component={Clothing} />
        <Route path='/recipes' component={Recipes} />
        <Route path='/weapons' component={Weapons} />
        <Route exact path='/' render={() => <Redirect to='/items' />} />
      </Layout>
    );
  }
}
