import 'bootstrap/dist/css/bootstrap.css';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import registerServiceWorker from './registerServiceWorker';
import Home from '../src/routes/Home/Home';
import Login from '../src/routes/Home/Login';
import Nav from './shared/Nav';
import QuestDashboard from '../src/routes/Quest/QuestDashboard';
import Quest from '../src/routes/Quest/Quest';
import { ThemeProvider } from '@mui/material/styles';
import Theme from './shared/Theme';
import CssBaseline from '@mui/material/CssBaseline';
import AdapterDateFns from '@mui/lab/AdapterDateFns';
import LocalizationProvider from '@mui/lab/LocalizationProvider';
import {
    BrowserRouter as Router,
    Routes,
    Route
} from 'react-router-dom'

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href') as string;

const App = () => {
    return(        
        <ThemeProvider theme={Theme}>
            <CssBaseline />
            <LocalizationProvider dateAdapter={AdapterDateFns}>
                <Router basename={baseUrl !== null ? baseUrl : ''}>
                    <Routes>
                        <Route path='login' element={<Login/>} />
                        <Route element={<Nav/>}>
                            <Route path='/' element={<Home/>}/>
                            <Route path='quests' element={<QuestDashboard/>} />
                            <Route path='quest' element={<Quest/>} />                                                     
                        </Route>
                    </Routes>
                </Router>
            </LocalizationProvider>
        </ThemeProvider>
    )
}
ReactDOM.render(
    <App />,
    document.getElementById('root')
);

registerServiceWorker();
