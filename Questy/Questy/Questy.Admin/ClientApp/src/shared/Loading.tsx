import * as React from 'react';
import CircularProgress from '@material-ui/core/CircularProgress';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';


const Loading = (props: { fullscreen: boolean; message?: string | React.ReactChild | React.ReactFragment | React.ReactPortal; }) => {
    
    const useStyles = makeStyles((theme) => ({
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