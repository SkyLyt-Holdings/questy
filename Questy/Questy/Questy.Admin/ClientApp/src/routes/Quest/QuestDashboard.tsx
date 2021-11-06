import * as React from 'react';
import { useHistory } from 'react-router';
import { Paper, Grid, Typography } from '@mui/material';
import { createTheme } from '@mui/material/styles';
import { makeStyles } from '@mui/styles';
import LocalStorage from '../../helpers/LocalStorage';
import Loading from '../../shared/Loading';
import { fetchClient } from '../../helpers/fetchClient';
import logger from '../../helpers/logger';
import MaterialTable from 'material-table';
import materialTableIcons from '../../shared/MaterialTableIcons';

const QuestDashboard = () => {
    const history = useHistory();
    const theme = createTheme();
    const [isLoading, setIsLoading] = React.useState(true);
    const [dataSource, setDataSource] = React.useState([]);
   
    const columns = [
        { field: 'id', title: 'ID', type: 'numeric', width: 10 },
        { field: 'title', title: 'Title'},
        { field: 'description', title: 'Description' },
        { field: 'startDate', title: 'Start Date'},
        { field: 'endDate', title: 'End Date' }
    ] as any;

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

    const   useStyles = makeStyles((theme) => ({
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
        setIsLoading(false);
        logger.log(data);
    }

return (
    
    <div>
          <Grid container spacing={3}>     
              <Grid item xs={12}>
                      {isLoading && 
                      <Paper className={classes.paper}>
                        <Loading fullscreen={true} message={"Loading dashboard, please wait..."}/>
                      </Paper>}
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
                </Grid>
          </Grid>
    </div>
    )
}

export default QuestDashboard;