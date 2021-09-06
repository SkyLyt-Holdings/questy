import * as React from 'react';
import { useHistory } from 'react-router';
import {Paper, Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import LocalStorage from '../../helpers/LocalStorage';
import { useTheme } from '@material-ui/core/styles';
import Loading from '../../shared/Loading';
import { fetchClient } from '../../helpers/fetchClient';
import ReactDataGrid from '@inovua/reactdatagrid-community';
import '@inovua/reactdatagrid-community/index.css'
import logger from '../../helpers/logger';

const QuestDashboard = () => {
    const history = useHistory();
    const theme = useTheme();
    const [isLoading, setIsLoading] = React.useState(true);
    const [dataSource, setDataSource] = React.useState([]);

    const columns = [
        { name: 'id', header: 'ID', defaultWidth: 80 },
        { name: 'title', header: 'Title', defaultFlex: 1 },
        { name: 'description', header: 'Description', defaultFlex: 1 },
        { name: 'startDate', header: 'Start', defaultFlex: 1 },
        { name: 'endDate', header: 'End', defaultFlex: 1 }

      ]
      
      const gridStyle = { minHeight: 550 }
      
    React.useEffect(() => {
        getData();
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

      function getData() {
        fetchClient.get({endpoint: '/quests', callback: onDataGet});
      }

      function onDataGet(data: []) {
        setIsLoading(false);
        setDataSource(data);
        logger.log(data);
    }

return (
    
    <div>
          <Grid container spacing={3}>     
              <Grid item xs={12}>
                    <Paper className={classes.paper}>
                      {isLoading && <Loading fullscreen={true} message={"Loading dashboard, please wait..."}/>}
                      {!isLoading && <div>
                        <Typography variant="h3">
                          Active Quests
                        </Typography>
                        <br/>
                        <ReactDataGrid
                        idProperty="id"
                        columns={columns}
                        dataSource={dataSource}
                        style={gridStyle}
                        />
                        </div>}
                    </Paper>
                </Grid>
          </Grid>
    </div>
    )
}

export default QuestDashboard;