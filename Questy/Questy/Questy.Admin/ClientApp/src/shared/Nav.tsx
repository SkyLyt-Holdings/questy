import React from 'react';
import { makeStyles, useTheme } from '@material-ui/core/styles';
import Drawer from '@material-ui/core/Drawer';
import List from '@material-ui/core/List';
import Divider from '@material-ui/core/Divider';
import ListItem from '@material-ui/core/ListItem';
import Grid from '@material-ui/core/Grid';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import {CgLogOut} from 'react-icons/cg';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import ChevronLeftIcon from '@material-ui/icons/ChevronLeft';
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import clsx from 'clsx';
import Typography from '@material-ui/core/Typography';
import { ImStatsDots } from "react-icons/im";
import { FaExclamation, FaUsersCog } from "react-icons/fa";
import { GiMagicShield } from "react-icons/gi";
import { AiFillTags } from "react-icons/ai";
import LocalStorage from '../helpers/LocalStorage';
import { useHistory } from 'react-router';

const Nav : React.FC = (props) => {

    const drawerWidth = 240;
    const theme = useTheme();
    const username = LocalStorage.getUsername();
    const history = useHistory();
    const useStyles = makeStyles((theme) => ({
      root: {
        display: 'flex',
      },
      appBar: {
        transition: theme.transitions.create(['margin', 'width'], {
          easing: theme.transitions.easing.sharp,
          duration: theme.transitions.duration.leavingScreen,
        }),
        backgroundColor: theme.palette.secondary.main
      },
      appBarShift: {
        width: `calc(100% - ${drawerWidth}px)`,
        marginLeft: drawerWidth,
        transition: theme.transitions.create(['margin', 'width'], {
          easing: theme.transitions.easing.easeOut,
          duration: theme.transitions.duration.enteringScreen,
        }),
      },
      menuButton: {
        marginRight: theme.spacing(2),
      },
      hide: {
        display: 'none',
      },
      drawerHeader: {
        display: 'flex',
        alignItems: 'center',
        padding: theme.spacing(0, 1),
        // necessary for content to be below app bar
        ...theme.mixins.toolbar,
        justifyContent: 'flex-end',
      },
      drawer: {
        width: drawerWidth,
        flexShrink: 0,
      },
      drawerPaper: {
        width: drawerWidth,
        backgroundColor: theme.palette.secondary.main
      },
      content: {
        flexGrow: 1,
        padding: theme.spacing(3),
        transition: theme.transitions.create('margin', {
          easing: theme.transitions.easing.sharp,
          duration: theme.transitions.duration.leavingScreen,
        }),
        marginLeft: -drawerWidth,
      },
      white: {
        color: theme.palette.text.secondary
      },
      divider: {
        backgroundColor: theme.palette.text.secondary
      },
      contentShift: {
        transition: theme.transitions.create('margin', {
          easing: theme.transitions.easing.easeOut,
          duration: theme.transitions.duration.enteringScreen,
        }),
        marginLeft: 0,
      },
      appBarText: {
        textAlign: 'end'
      },
      headingText: {
        color: theme.palette.text.secondary,
        paddingTop: 10
      }
    }));

    const classes = useStyles();
    const [open, setOpen] = React.useState(false);

    const handleDrawerOpen = () => {
      setOpen(true);
    };
  
    const handleDrawerClose = () => {
      setOpen(false);
    };

    const handleLogout = () => {
      LocalStorage.clearToken();
      history.push('/login');
    };

    const handleQuests = () => {
      history.push('/quests');
    }

    return (
      <div className={classes.root}>
        <AppBar
        position="fixed"
        className={clsx(classes.appBar, {
          [classes.appBarShift]: open,
        })}
      >
        <Toolbar>
          <Grid container spacing={3}>
            <Grid item md={1}>
              <IconButton
              color="inherit"
              aria-label="open drawer"
              onClick={handleDrawerOpen}
              edge="start"
              className={clsx(classes.menuButton, open && classes.hide)}
            >
              <MenuIcon />
            </IconButton>
            </Grid>
            <Grid item md={11} className={classes.appBarText}>
              <Typography variant="h6" className={classes.headingText} noWrap>
                Well met, {username}
              </Typography>
            </Grid>
          </Grid>       
        </Toolbar>
      </AppBar>
        <Drawer
          className={classes.drawer}
          variant="persistent"
          anchor="left"
          open={open}
          classes={{
            paper: classes.drawerPaper,
          }}
        >
        <div className={classes.drawerHeader}>
          <IconButton onClick={handleDrawerClose}>
            {theme.direction === 'ltr' ? <ChevronLeftIcon className={classes.white} /> : <ChevronRightIcon className={classes.white} />}
          </IconButton>
        </div>
          <Divider className={classes.divider} />
          <List>
          <ListItem button key="Dashboard" >
                <ListItemIcon className={classes.white}><ImStatsDots size={25} /></ListItemIcon>
                <ListItemText primary="Dashboard" className={classes.white}/>
            </ListItem>
            <ListItem button key="Quests" onClick={handleQuests}>
                <ListItemIcon className={classes.white}><FaExclamation size={25} /></ListItemIcon>
                <ListItemText primary="Quests" className={classes.white}/>
            </ListItem>
            <ListItem button key="Users" >
                <ListItemIcon className={classes.white}><FaUsersCog size={25} /></ListItemIcon>
                <ListItemText primary="Users" className={classes.white}/>
            </ListItem>
            <ListItem button key="Archetype" >
                <ListItemIcon className={classes.white}><GiMagicShield size={25} /></ListItemIcon>
                <ListItemText primary="Archetype" className={classes.white}/>
            </ListItem>
            <ListItem button key="Tags" >
                <ListItemIcon className={classes.white}><AiFillTags size={25} /></ListItemIcon>
                <ListItemText primary="Tags" className={classes.white}/>
            </ListItem>
          </List>
          <Divider className={classes.divider} />
          <List>
            <ListItem button key="Logout" onClick={handleLogout} >
                <ListItemIcon className={classes.white}><CgLogOut size={25} /></ListItemIcon>
                <ListItemText primary="Logout" className={classes.white}/>
            </ListItem>
          </List>
        </Drawer>
        <main className={clsx(classes.content, {
          [classes.contentShift]: open,
        })}>
          <div className={classes.drawerHeader}/>
          {props.children}
        </main>
      </div>
    );
}

export default Nav;
