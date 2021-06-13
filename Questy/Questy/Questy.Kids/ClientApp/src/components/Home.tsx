import * as React from 'react';
import { connect } from 'react-redux';
import { HomeJumbotron } from './homejumbotron';


const Home = () => (
    <div>
        <HomeJumbotron/>
  </div>
);

export default connect()(Home);
