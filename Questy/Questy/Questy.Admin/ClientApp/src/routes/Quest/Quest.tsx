import * as React from 'react';
import { createTheme } from '@mui/material/styles';
import makeStyles from '@mui/styles/makeStyles';
import {Paper, Grid, Typography, TextField } from '@mui/material';
import Theme from '../../shared/Theme';
import IQuest from '../Quest/models/IQuest';
import DateTimePicker from '@mui/lab/DateTimePicker';

const Quest = () => {
    const theme = createTheme();
    const data = {
        id: null,
        title: "",
        description: "",
        startDate: new Date(),
        endDate: new Date() 
    } as IQuest;
    const [isNewQuest, setIsNewQuest] = React.useState(true);
    const [titleText, setTitleText] = React.useState("Create New Quest");
    const [quest, setQuest] = React.useState(data);
    const useStyles = makeStyles((theme: typeof Theme) => ({
        paper: {
            padding: theme.spacing(2),
            textAlign: 'center',
            marginTop: 80,
            margin: 20
          }
      })); 
    const classes = useStyles();
return (   
    <Paper className={classes.paper}>
        <Grid container spacing={3}> 
            <Grid item xs={12}>
            <Typography id="lblTitle" variant="h3" gutterBottom>
                {titleText}
            </Typography>
            </Grid>    
            <Grid item xs={12}>
                <TextField
                    InputLabelProps={{style : {color : theme.palette.secondary.main} }}
                    required
                    id="txtQuestTitle"
                    label="Quest Title"
                    defaultValue={quest.title}
                    fullWidth
                    size="small"
                    variant="outlined"
                    />
            </Grid>
            <Grid item xs={12}>
                <TextField
                id="txtQuestDescription"
                InputLabelProps={{style : {color : theme.palette.secondary.main} }}
                label="Quest Description"
                multiline
                required
                rows={4}
                fullWidth
                defaultValue={quest.description}
                size="small"
                variant="outlined"
                />
            </Grid>
            <Grid item xs={6}>
            <DateTimePicker
                renderInput={(props) => <TextField {...props} />}
                label="DateTimePicker"
                value={quest.startDate}
                // onChange={(newValue) => {
                // setQuest(...quest, startDate: newValue);
                // }}
            />
            </Grid>
            <Grid item xs={6}>
            </Grid>
        </Grid>
    </Paper>
);
}

export default Quest;