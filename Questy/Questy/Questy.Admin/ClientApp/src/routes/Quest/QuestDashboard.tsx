import * as React from 'react';
import { useHistory } from 'react-router';
import {Paper, Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import LocalStorage from '../../helpers/LocalStorage';
import { useTheme } from '@material-ui/core/styles';
import Loading from '../../shared/Loading';
import { fetchClient } from '../../helpers/fetchClient';
import logger from '../../helpers/logger';
import MaterialTable from 'material-table';
import materialTableIcons from '../../shared/MaterialTableIcons';

const QuestDashboard = () => {
    const history = useHistory();
    const theme = useTheme();
    const [isLoading, setIsLoading] = React.useState(true);
    const [dataSource, setDataSource] = React.useState([]);
   
    const columns = [
        { field: 'id', title: 'ID', type: 'numeric', width: 10 },
        { field: 'title', title: 'Title', type: 'string' },
        { field: 'description', title: 'Description', type: 'string' },
        { field: 'startDate', title: 'Start', type: 'string' },
        { field: 'endDate', title: 'End', type: 'string' }
    ]

    const options = {
        filtering: true,
        search: true,
		sorting: true
    }

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
        setDataSource(data);
        logger.log(data);
        setIsLoading(false);
    }

return (
    
    <div>
          <Grid container spacing={3}>     
              <Grid item xs={12}>
                    <Paper className={classes.paper}>
                      {isLoading && <Loading fullscreen={true} message={"Loading dashboard, please wait..."}/>}
                      {!isLoading && <div>
                        <MaterialTable
                  		    title='Active Quests'
                          icons={materialTableIcons}
                          data={dataSource}
                          columns={columns}      
                          options={options}
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