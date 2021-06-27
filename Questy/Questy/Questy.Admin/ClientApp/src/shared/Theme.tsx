import { createMuiTheme } from '@material-ui/core/styles';
import forest from '../img/forest.jpg';

const theme = createMuiTheme({
    overrides: {
        MuiCssBaseline: {
          '@global': {
            body: {
                backgroundImage: `url(${forest})`,
                backgroundRepeat: "no-repeat"
            },
          },
        },
    },
    palette: {
        primary: {
          main: '#8a2be2'
        },
        secondary: {
          main: '#008000'
        },
        text: {
            secondary: '#fff'
        }
    },
    typography : {
        h1: {
            fontFamily: 'Cinzel Decorative'
        },
        h2 :{
            fontFamily: 'Cinzel Decorative'
        },
        h3: {
            fontFamily: 'Cinzel Decorative'
        },
        h4: {
            fontFamily: 'Cinzel Decorative'
        },
        h5 :{
            fontFamily: 'Cinzel Decorative'
        },
        h6: {
            fontFamily: 'Cinzel Decorative'
        },
    }
});

export default theme;