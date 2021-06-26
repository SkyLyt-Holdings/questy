import * as React from 'react';
import { useHistory } from 'react-router';
import {Paper, Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import LocalStorage from '../../helpers/LocalStorage';
import { useTheme } from '@material-ui/core/styles';

const Home = () => {
    const history = useHistory();
    const theme = useTheme();

    React.useEffect(() => {
        const token = LocalStorage.getToken();
        if(token === null && window.location) history.push("/login");
    }, [])

    const useStyles = makeStyles((theme) => ({
        root: {
          flexGrow: 1,
        },
        paper: {
          padding: theme.spacing(2),
          textAlign: 'center',
        }
      })); 

      const classes = useStyles();

return (
    
    <div>
          <Grid container spacing={3}>     
              <Grid item xs={12}>
                    <Paper className={classes.paper}>
                      <Typography variant="h3">
                        Dashboard
                      </Typography>
                    </Paper>
                </Grid>
          </Grid>
    </div>
    )
}

export default Home;