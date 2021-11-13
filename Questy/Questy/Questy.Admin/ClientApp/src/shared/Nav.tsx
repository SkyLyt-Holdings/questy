import * as React from 'react';
import { styled, createTheme } from '@mui/material/styles';
import MuiDrawer from '@mui/material/Drawer';
import List from '@mui/material/List';
import Divider from '@mui/material/Divider';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import {CgLogOut} from 'react-icons/cg';
import MuiAppBar, { AppBarProps as MuiAppBarProps } from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import Typography from '@mui/material/Typography';
import { ImStatsDots } from "react-icons/im";
import { FaExclamation, FaUsersCog } from "react-icons/fa";
import { GiMagicShield } from "react-icons/gi";
import { AiFillTags } from "react-icons/ai";
import LocalStorage from '../helpers/LocalStorage';
import { useNavigate } from 'react-router';
import Box from '@mui/material/Box';
import Tooltip from '@mui/material/Tooltip';
import {Outlet} from "react-router-dom";
import Grid from '@mui/material/Grid';

const drawerWidth: number = 240;

interface AppBarProps extends MuiAppBarProps {
  open?: boolean;
}

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: (prop) => prop !== 'open',
})<AppBarProps>(({ theme, open }) => ({
  zIndex: theme.zIndex.drawer + 1,
  transition: theme.transitions.create(['width', 'margin'], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  ...(open && {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  }),
}));

const Drawer = styled(MuiDrawer, { shouldForwardProp: (prop) => prop !== 'open' })(
  ({ theme, open }) => ({
    '& .MuiDrawer-paper': {
      position: 'relative',
      whiteSpace: 'nowrap',
      width: drawerWidth,
      backgroundColor: theme.palette.secondary.main,
      transition: theme.transitions.create('width', {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.enteringScreen,
      }),    
      boxSizing: 'border-box',
      ...(!open && {
        overflowX: 'hidden',
        transition: theme.transitions.create('width', {
          easing: theme.transitions.easing.sharp,
          duration: theme.transitions.duration.leavingScreen,
        }),
        width: theme.spacing(7),
        [theme.breakpoints.up('sm')]: {
          width: theme.spacing(9),
        },
      }),     
    },
  }),
);

const Nav : React.FC = (props) => {

    const username = LocalStorage.getUsername();
    const navigate = useNavigate();
    const [open, setOpen] = React.useState(true);
    
    const toggleDrawer = () => {
      setOpen(!open);
    };

    const handleLogout = () => {
      LocalStorage.clearToken();
      navigate('/login');
    };

    const handleQuests = () => {
      navigate('/quests');
    }

    const handleDashboard = () => {
      navigate('/');
    }

    return (
      <div>
      <AppBar position="absolute" open={open}>
          <Toolbar
            sx={{
              pr: '24px', // keep right padding when drawer closed
            }}
          >
            <IconButton
              edge="start"
              color="inherit"
              aria-label="open drawer"
              onClick={toggleDrawer}
              sx={{
                marginRight: '36px',
                ...(open && { display: 'none' }),
              }}
            >
              <MenuIcon />
            </IconButton>
            <Typography
              component="h1"
              variant="h6"
              color="inherit"
              noWrap
              sx={{ flexGrow: 1 }}
            >
              Questy Admin
            </Typography>
            <Typography variant="h6" noWrap>
                Well met, {username}
              </Typography>
          </Toolbar>
        </AppBar>
        <Box  sx={{
           display: 'flex'
          }}>
            <Drawer
                variant="permanent" open={open}
                >
                  <Toolbar
                    sx={{
                      display: 'flex',
                      alignItems: 'center',
                      justifyContent: 'flex-end',
                      px: [1]
                    }}
                  >
                    <IconButton sx={{color: "white"}} onClick={toggleDrawer}>
                      <ChevronLeftIcon  />
                    </IconButton>
                  </Toolbar>
                  <Divider sx={{color: "white"}} />
                  <List>
                    <Tooltip title="Dashboard" placement="right">
                      <ListItem button key="Dashboard" onClick={handleDashboard}>
                          <ListItemIcon sx={{color: "white"}}><ImStatsDots size={25} /></ListItemIcon>
                          <ListItemText primary="Dashboard" sx={{color: "white"}}/>
                      </ListItem>
                    </Tooltip>
                    <Tooltip title="Quests" placement="right">
                      <ListItem button key="Quests" onClick={handleQuests}>
                          <ListItemIcon sx={{color: "white"}}><FaExclamation size={25} /></ListItemIcon>
                          <ListItemText primary="Quests" sx={{color: "white"}}/>
                      </ListItem>
                    </Tooltip>
                    <Tooltip title="Users" placement="right">
                      <ListItem button key="Users">
                          <ListItemIcon sx={{color: "white"}}><FaUsersCog size={25} /></ListItemIcon>
                          <ListItemText primary="Users" sx={{color: "white"}}/>
                      </ListItem>
                    </Tooltip>
                    <Tooltip title="Archetypes" placement="right">
                      <ListItem button key="Archetypes">
                          <ListItemIcon sx={{color: "white"}}><GiMagicShield size={25} /></ListItemIcon>
                          <ListItemText primary="Archetypes" sx={{color: "white"}}/>
                      </ListItem>
                    </Tooltip>
                    <Tooltip title="Tags" placement="right">
                      <ListItem button key="Tags">
                          <ListItemIcon sx={{color: "white"}}><AiFillTags size={25} /></ListItemIcon>
                          <ListItemText primary="Tags" sx={{color: "white"}}/>
                      </ListItem>
                    </Tooltip>
                  </List>
                  <Divider sx={{color: "white"}} />
                  <List>
                    <Tooltip title="Logout" placement="right">
                      <ListItem button key="Logout" onClick={handleLogout} >
                          <ListItemIcon sx={{color: "white"}}><CgLogOut size={25} /></ListItemIcon>
                          <ListItemText primary="Logout" sx={{color: "white"}}/>
                      </ListItem>
                    </Tooltip>
                  </List>
            </Drawer>
            <Box component="main" sx={{
                 flexGrow: 1,
                 height: '100vh',
                 overflow: 'auto',
            }}>
                <Outlet />
            </Box>
        </Box>    
      </div>
    );
}

export default Nav;
