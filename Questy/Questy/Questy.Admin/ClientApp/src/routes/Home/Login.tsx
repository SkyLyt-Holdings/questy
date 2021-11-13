import * as React from 'react';
import LocalStorage from '../../helpers/LocalStorage';
import makeStyles from '@mui/styles/makeStyles';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import TextField from '@mui/material/TextField';
import Grid from '@mui/material/Grid';
import InputAdornment from '@mui/material/InputAdornment';
import {FaHatWizard} from 'react-icons/fa'
import {FiKey} from 'react-icons/fi';
import Button from '@mui/material/Button';
import LoginRequest from './models/LoginRequest';
import LoginResponse from "./models/LoginResponse";
import { useState } from 'react';
import { useNavigate } from 'react-router';
import { fetchClient } from '../../helpers/fetchClient';
import Typography from '@mui/material/Typography';
import { Theme } from '@mui/material/styles';
import { createTheme } from '@mui/material/styles';


const Login = () => {
    const theme = createTheme();
    const navigation = useNavigate();
    const [loginForm, setLoginForm] = useState<LoginRequest>({
        username: '',
        password: ''
    });
    const [isSubmitting, setIsSubmitting] = useState<boolean>(false);
    const [hasErrors, setHasErrors] = useState<boolean>(false);
    const [errorMessage, setErrorMessage] = useState<string>('');

    const useStyles = makeStyles((theme:Theme) => ({
        root: {
            marginTop: "15em"
        },
        content : {
            textAlign: 'center'
        },
        header : {
            margin: "20px"
        },
        button: {
            margin: "5px"
        }
      }));
    
      const classes = useStyles();


    function handleInputChange(event: React.ChangeEvent<HTMLInputElement>) {
        setLoginForm({
            ...loginForm,
            [event.target.name]: event.target.value
        });
    }

    function onErrorResponse(error: any) {
        setIsSubmitting(false);
        setHasErrors(true);
        setErrorMessage('Incorrect username and/or password');
    }

    function handleSubmit() {
        setHasErrors(false);
        if (!loginForm.username || !loginForm.password) {
            setHasErrors(true);
            setErrorMessage('Please enter a valid username and password');
        }
        else {
            fetchClient.post({endpoint: '/users/login', callback: onLogin, data: loginForm, onError:  onErrorResponse});
        }
    }

    function onLogin(data: LoginResponse) {
        if( data.isAdmin )
        {
            setHasErrors(false);
            LocalStorage.setUsername(data.username);
            LocalStorage.setToken(data.token);
            navigation('/');
        }
        else
        {
            setHasErrors(true);
            setErrorMessage('You do not have admin permissions to log to this site');
        }
    }
 
   return (
        <Grid container className={classes.root}>
            <Grid item md={4}></Grid> 
            <Grid item md={4}>
                    <Card variant="outlined">
                        <CardContent className={classes.content}>
                            <Typography className={classes.header} variant="h5">
                                <strong>Here Be Dragons...</strong>
                            </Typography>
                            <Grid>
                                <Grid item md={12}>
                                <TextField   
                                    className={classes.header}  
                                    name="username"
                                    error={hasErrors}
                                    onChange={handleInputChange}                             
                                    InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                        <FaHatWizard size={20} />
                                        </InputAdornment>
                                    ),
                                    }}
                                />
                                </Grid>
                                <Grid item md={12}>
                                <TextField      
                                    className={classes.header}
                                    name="password"
                                    type="password"
                                    error={hasErrors}
                                    onChange={handleInputChange}                                                        
                                    InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                        <FiKey size={20} />
                                        </InputAdornment>
                                    ),
                                    }}
                                />
                                </Grid>
                                <Grid item md={12}>
                                    <Button className={classes.button} variant="contained" color="primary">Forgot Password</Button>
                                    <Button onClick={handleSubmit} className={classes.button} variant="contained" color="secondary" disabled={isSubmitting}>Log In</Button>
                                </Grid>
                                {hasErrors && <Grid item md={12}>
                                    <span className="text-danger">
                                        <strong>{errorMessage}</strong>
                                    </span>
                                </Grid>}
                            </Grid>
                        </CardContent>
                        <CardActions>
                        </CardActions>
                    </Card>
            </Grid>
            <Grid item md={4}></Grid> 
       </Grid>
   )
}

export default Login;
