import {
  Container,
  CssBaseline,
  Grid,
  makeStyles,
  Typography,
} from "@material-ui/core";
import CardComponent from "../../components/card-component/card.properties.component";
import { CardContentHomeConfiguration } from "./configurations-home";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    display:'inline-flex'
  },
  typographic1: {
    marginBottom: theme.spacing(1),
  },
  paper: {
    height: 140,
    width: 100,
  },
  control: {
    padding: theme.spacing(2),
  },
}));

export const HomePage = () => {
  const classes = useStyles();
  return (
    <div>
      <CssBaseline />
      <Container maxWidth="xl">
        <Typography
          className={classes.typographic1}
          variant="h4"
          component="h1"
          style={{ backgroundColor: "whitesmoke" }}
        >
          Properties
        </Typography>
        <Grid container className={classes.root}>
          <CardComponent cardComponentConfiguration={CardContentHomeConfiguration} />
          <CardComponent cardComponentConfiguration={CardContentHomeConfiguration} />
          <CardComponent cardComponentConfiguration={CardContentHomeConfiguration} />
          <CardComponent cardComponentConfiguration={CardContentHomeConfiguration} />
          <CardComponent cardComponentConfiguration={CardContentHomeConfiguration} />
          <CardComponent cardComponentConfiguration={CardContentHomeConfiguration} />
        </Grid>
      </Container>
    </div>
  );
};
