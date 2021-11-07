import * as React from 'react';
import CircularProgress from '@mui/material/CircularProgress';
import Typography from '@mui/material/Typography';
import makeStyles from '@mui/styles/makeStyles';
import { Theme } from '@mui/material/styles';


const Loading = (props: { fullscreen: boolean; message?: string | React.ReactChild | React.ReactFragment | React.ReactPortal; }) => {
    
    const useStyles = makeStyles((theme: Theme) => ({
        root: {
            marginTop: "20em"
        },
        text: {
            marginTop: theme.spacing(3)
        }
      })); 

      const classes = useStyles();
    
    if (props.fullscreen) {
        return (
            <div className={classes.root}>
                <CircularProgress size={60} />
                <Typography variant="h4" className={classes.text}>
                 {props.message}
                </Typography>
            </div>
        )
    };
    return (
        <div>
            <CircularProgress />
        </div>
    )
};

export default Loading