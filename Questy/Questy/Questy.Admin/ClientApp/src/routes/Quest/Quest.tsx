import * as React from 'react';
import { createTheme } from '@mui/material/styles';
import makeStyles from '@mui/styles/makeStyles';
import {Paper, Grid, Typography, TextField, Button } from '@mui/material';
import Theme from '../../shared/Theme';
import IQuest from '../Quest/models/IQuest';
import DateTimePicker from '@mui/lab/DateTimePicker';
import { fetchClient } from '../../helpers/fetchClient';
import { useNavigate } from 'react-router';

const Quest = () => {
    const theme = createTheme();
    const navigate = useNavigate();
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

    const updateQuestObject = (key : any, value : any) => {
        // Destructure current state object
        const newQuest = {
          ...quest,
          [key]: value,
        };
        setQuest(newQuest);
      };

      const handleSubmit = () => {         
        fetchClient.post({endpoint: '/quests', data: quest, callback: onSave});
      }

      const onSave = () => {
           navigate("/quests");
      }

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
                    required
                    id="txtQuestTitle"
                    label="Quest Title"
                    defaultValue={quest.title}
                    fullWidth
                    size="small"
                    variant="outlined"
                    onChange={(newValue) => {
                        updateQuestObject("title", newValue.target.value); 
                     }}
                    />
            </Grid>
            <Grid item xs={12}>
                <TextField
                id="txtQuestDescription"
                label="Quest Description"
                multiline
                required
                rows={4}
                fullWidth
                defaultValue={quest.description}
                size="small"
                variant="outlined"
                onChange={(newValue) => {
                    updateQuestObject("description", newValue.target.value); 
                 }}
                />
            </Grid>
            <Grid item xs={6}>
                <Grid container>
                    <Grid item xs={2}>
                        <Typography variant="body1" gutterBottom>
                            Start Date:
                        </Typography>
                    </Grid>
                    <Grid item xs={10}>
                        <DateTimePicker
                        renderInput={(props) => <TextField {...props} />}
                        value={quest.startDate}
                        onChange={(newValue) => {
                        updateQuestObject("startDate", newValue); 
                        }}
                    />
                    </Grid>
                </Grid>
            </Grid>
            <Grid item xs={6}>
                <Grid container>
                    <Grid item xs={2}>
                        <Typography variant="body1" gutterBottom>
                            End Date:
                        </Typography>
                    </Grid>
                    <Grid item xs={10}>
                        <DateTimePicker
                        renderInput={(props) => <TextField {...props} />}
                        value={quest.endDate}
                        onChange={(newValue) => {
                        updateQuestObject("endDate", newValue); 
                        }}
                    />
                    </Grid>
                </Grid>
            </Grid>
            <Grid item xs={12} className="mt-3" sx={{display: "flex", justifyContent: "flex-end"}}>
                <Button variant="contained" color="error">Cancel</Button>
                <Button variant="contained" color="secondary" onClick={handleSubmit}>Save</Button>
            </Grid>
        </Grid>
    </Paper>
);
}

export default Quest;