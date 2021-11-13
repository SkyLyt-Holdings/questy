import { createTheme } from '@mui/material/styles';
import forest from '../img/forest.jpg';

const theme = createTheme({
    components: {
        MuiCssBaseline: {
            styleOverrides: {
              body: {
                backgroundImage: `url(${forest})`,
                backgroundRepeat: "no-repeat"
              },
          }
        },
        MuiButton: {
            styleOverrides: {
              // Name of the slot
              root: {
                // Some CSS
                margin: 5,
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