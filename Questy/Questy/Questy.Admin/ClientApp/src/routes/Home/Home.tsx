import * as React from 'react';
import { useNavigate } from 'react-router';
import { Theme } from '@mui/material/styles';
import { Paper, Grid, Typography } from '@mui/material';
import { createTheme } from '@mui/material/styles';
import makeStyles from '@mui/styles/makeStyles';
import LocalStorage from '../../helpers/LocalStorage';
import Loading from '../../shared/Loading';

const Home = () => {
    const navigate = useNavigate();
    const [isLoading, setIsLoading] = React.useState(true);

    React.useEffect(() => {
        const token = LocalStorage.getToken();
        if(token === null && window.location) navigate("/login");
    }, [])

    const useStyles = makeStyles((theme:Theme) => ({
        paper: {
          padding: theme.spacing(2),
          textAlign: 'center',
          height: 850,
          marginTop: 80,
          margin: 20
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