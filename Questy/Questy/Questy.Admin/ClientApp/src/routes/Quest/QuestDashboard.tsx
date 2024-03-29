import * as React from 'react';
import { useNavigate } from 'react-router';
import { Paper, Grid, Typography, Button } from '@mui/material';
import { createTheme } from '@mui/material/styles';
import makeStyles from '@mui/styles/makeStyles';
import { Theme } from '@mui/material/styles';
import LocalStorage from '../../helpers/LocalStorage';
import Loading from '../../shared/Loading';
import { fetchClient } from '../../helpers/fetchClient';
import logger from '../../helpers/logger';
import MaterialTable, { Column } from "@material-table/core";
import materialTableIcons from '../../shared/MaterialTableIcons';
import IQuestDashboard from '../Quest/models/IQuestDashboard';
import { FiEdit } from 'react-icons/fi';
import { RiDeleteBin2Line } from 'react-icons/ri';

const QuestDashboard = () => {
    const navigate = useNavigate();
    const theme = createTheme();
    const [isLoading, setIsLoading] = React.useState(true);
    const [dataSource, setDataSource] = React.useState<Array<IQuestDashboard>>([]);
   
    const columns: Array<Column<IQuestDashboard>> = [
        { field: 'id', title: 'ID', type: 'numeric', width: 10 },
        { field: 'title', title: 'Title'},
        { field: 'description', title: 'Description' },
        { field: 'startDate', title: 'Start Date'},
        { field: 'endDate', title: 'End Date' }
    ];

    const options = {
        filtering: true,
        search: true,
		    sorting: true,
        actionsColumnIndex: -1
    }

    const gridStyle = { minHeight: 550 }
	
    React.useEffect(() => {
        getData();
    }, [])

    const useStyles = makeStyles((theme: Theme) => ({
        paper: {
          padding: theme.spacing(2),
          textAlign: 'center',
          height: 650,
          marginTop: 80,
          margin: 20
        },
        buttonDiv: {
            display: "flex",
            justifyContent: "end",
            marginBottom: 15
          }
      })); 

      const classes = useStyles();

      function getData() {
        fetchClient.get({endpoint: '/quests', callback: onDataGet});
      }

      function onDataGet(data: Array<IQuestDashboard>) {        
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
                        <Loading fullscreen={true} message={"Loading quests, please wait..."}/>
                      </Paper>}
                      {!isLoading && <div>
                        <Paper className={classes.paper}>
                        <div className={classes.buttonDiv}>
                          <Button onClick={() => navigate("/quest")} variant="contained" color="secondary">Create New Quest</Button>
                        </div>
                        <MaterialTable
                          title='Active Quests'
                          icons={materialTableIcons}
                          data={dataSource}
                          columns={columns}      
                          options={options}
                          style={gridStyle}
                          actions={[
                            {
                              icon: () => <FiEdit/>,
                              tooltip: 'Edit Quest',
                              // @ts-ignore
                              onClick: (event, rowData) => history.push("/quest/" + rowData.id)
                            },
                            {
                              icon: () => <RiDeleteBin2Line/>,
                              tooltip: 'Delete Quest',
                              onClick: (event, rowData) => alert("You want to delete ")
                            }
                          ]}								  
                        />
                      </Paper>
                      </div>}
                </Grid>
          </Grid>
    </div>
    )
}

export default QuestDashboard;