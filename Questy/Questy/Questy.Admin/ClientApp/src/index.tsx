import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import registerServiceWorker from './registerServiceWorker';
import Home from '../src/routes/Home/Home';
import Login from '../src/routes/Home/Login';
import Nav from './shared/Nav';
import {
    BrowserRouter as Router,
    Switch,
    Route
} from 'react-router-dom'
import './custom.css'

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href') as string;

const App = () => {
    return(
        <Router basename={baseUrl !== null ? baseUrl : ''}>
            <Switch>
                <Route path='/login'>
                    <Login/>
                </Route>
                <Nav>           
                    <Route path='/'>
                        <Home />
                    </Route>
                </Nav>
            </Switch>
        </Router>
    )
}
ReactDOM.render(
    <App />,
    document.getElementById('root')
);

registerServiceWorker();
