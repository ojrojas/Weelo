import { createTheme, CssBaseline, ThemeProvider } from "@material-ui/core";
import { connect } from "react-redux";
import RouterAppRoot from "./router/router-application";
import { AppState } from "./store/root-reducer";

export const App = () => {
  const Tahoma = {
      fontFamily: 'Tahoma',
      fontStyle: 'normal',
      fontDisplay: 'swap',
      fontWeight: 400,
      unicodeRange:
          'U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF',
  } as any;

  const theme = createTheme({
      typography: {
          fontFamily: 'Tahoma',
          fontSize: 14,
      },
      palette: {
          primary: {
              main: '#1C3F8B',
          },
      },
      overrides: {
          MuiCssBaseline: {
              '@global': {
                  '@font-face': [Tahoma],
              },
          },
      },
  });

  return (
      <div>
          <ThemeProvider theme={theme}>
              <CssBaseline />
              <RouterAppRoot />
          </ThemeProvider>
      </div>
  );
};

const mapStateToProps = (state: AppState) => ({
 
});

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(App);
