import * as React from 'react';
import { useHistory } from 'react-router';
import { Paper, Grid, Typography } from '@mui/material';
import { createTheme } from '@mui/material/styles';
import { makeStyles } from '@mui/styles';
import LocalStorage from '../../helpers/LocalStorage';
import Loading from '../../shared/Loading';

const Home = () => {
    const history = useHistory();
    const theme = createTheme();
    const [isLoading, setIsLoading] = React.useState(true);

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
          height: 900
        }
      })); 

      const classes = useStyles();

return (
    
    <div>
          <Grid container spacing={3}>     
              <Grid item xs={12}>
                    <Paper className={classes.paper}>
                      {isLoading && <Loading fullscreen={true} message={"Loading dashboard, please wait..."}/>}
                      {!isLoading && <div>
                        <Typography variant="h3">
                          Dashboard
                        </Typography>
                        </div>}
                    </Paper>
                </Grid>
          </Grid>
    </div>
    )
}

export default Home;