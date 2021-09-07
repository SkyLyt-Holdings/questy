import * as React from 'react';
import LocalStorage from '../../helpers/LocalStorage';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContelognt';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import InputAdornment from '@material-ui/core/InputAdornment';
import {FaHatWizard} from 'react-icons/fa'
import {FiKey} from 'react-icons/fi';
import Button from '@material-ui/core/Button';
import LoginRequest from './models/LoginRequest';
import LoginResponse from "./models/LoginResponse";
import { useState } from 'react';
import { useHistory } from 'react-router';
import { fetchClient } from '../../helpers/fetchClient';
import { Typography } from '@material-ui/core';

const useStyles = makeStyles((theme) => ({
    root: {
        marginTop: "15em"
    },
    content : {
        textAlign: 'center'
    },
    header : {
        margin: 20
    },
    button: {
        margin: 5
    }
  }));

const Login = () => {

    const history = useHistory();
    const classes = useStyles();
    const [loginForm, setLoginForm] = useState<LoginRequest>({
        username: '',
        password: ''
    });
    const [isSubmitting, setIsSubmitting] = useState<boolean>(false);
    const [hasErrors, setHasErrors] = useState<boolean>(false);
    const [errorMessage, setErrorMessage] = useState<string>('');

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
      if (!loginForm.username || !loginForm.password) {
          setHasErrors(true);
          setErrorMessage('Please enter a valid username and password');
      }

      fetchClient.post({endpoint: '/users/login', callback: onLogin, data: loginForm, onError:  onErrorResponse});
    }

    function onLogin(data: LoginResponse) {
        if( data.isAdmin )
        {
            setHasErrors(false);
            LocalStorage.setUsername(data.username);
            LocalStorage.setToken(data.token);
            history.push('/');
        }
        else
        {
            setHasErrors(true);
            setErrorMessage('You do not have admin permissions to log to this site');
        }
    }
 
   return (
        <Grid container direction="row" justify="center" alignItems="center" className={classes.root}> 
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
       </Grid>
   )
}

export default Login;
