import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AddStock } from './components/AddStock';
import { DeleteStock } from './components/DeleteStock';
import { UpdateStock } from './components/UpdateStock';


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/add' component={AddStock} />
        <Route path='/delete' component={DeleteStock} />
        <Route path='/update' component={UpdateStock} />
      </Layout>
    );
  }
}
