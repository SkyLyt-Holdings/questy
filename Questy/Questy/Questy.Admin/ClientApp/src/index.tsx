import 'bootstrap/dist/css/bootstrap.css';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import registerServiceWorker from './registerServiceWorker';
import Home from '../src/routes/Home/Home';
import Login from '../src/routes/Home/Login';
import Nav from './shared/Nav';
import QuestDashboard from '../src/routes/Quest/QuestDashboard';
import { ThemeProvider } from '@mui/material/styles';
import Theme from './shared/Theme';
import CssBaseline from '@mui/material/CssBaseline';
import {
    BrowserRouter as Router,
    Switch,
    Route
} from 'react-router-dom'

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href') as string;

const App = () => {
    return(        
        <ThemeProvider theme={Theme}>
            <CssBaseline />
            <Router basename={baseUrl !== null ? baseUrl : ''}>
                <Switch>
                    <Route path='/login'>
                        <Login/>
                    </Route>
                    <Nav>
                        <Route path='/quests'>
                            <QuestDashboard/>
                        </Route>           
                        <Route exact path='/'>
                            <Home />
                        </Route>
                    </Nav>
                </Switch>
            </Router>
        </ThemeProvider>
    )
}
ReactDOM.render(
    <App />,
    document.getElementById('root')
);

registerServiceWorker();
