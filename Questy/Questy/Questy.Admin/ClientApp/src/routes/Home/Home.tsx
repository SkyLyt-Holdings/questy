import * as React from 'react';
import { useHistory } from 'react-router';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import { makeStyles } from '@material-ui/core/styles';
import LocalStorage from '../../helpers/LocalStorage';

const Home = () => {
    const history = useHistory();

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
          color: theme.palette.text.secondary,
        },
      })); 

      const classes = useStyles();

return (
    
    <div>
          <Grid container spacing={3}>     
              <Grid item xs={12}>
                    <Paper className={classes.paper}>
                        <h1 className="text-black">Dashboard</h1>
                    </Paper>
                </Grid>
          </Grid>
    </div>
    )
}

export default Home;