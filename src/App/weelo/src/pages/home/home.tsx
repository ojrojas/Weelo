import {
  Container,
  CssBaseline,
  Grid,
  makeStyles,
  Typography,
} from "@material-ui/core";
import { connect } from "react-redux";
import { PropertyState } from "../../reducer/property.reducer";
import { AppState } from "../../store/root-reducer";
import { LoadPropertyAction } from "../../actions/property.actions";
import PropertyListPage from "../properties/components/property-list";
import { useEffect } from "react";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    display: "inline-flex",
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

const HomePage = (props: Props) => {
  const { propertyState } = props;

  const loadData = () => {
    props.LoadPropertyAction();
  };

  useEffect(() => {
    loadData();
  }, []);

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
          Wellcome to luxuries
        </Typography>
        <Grid container className={classes.root}>
          <PropertyListPage properties={propertyState.properties} />
        </Grid>
      </Container>
    </div>
  );
};

const mapStateToProps = (state: AppState) => ({
  propertyState: state.property,
});

const mapDispatchToProps = {
  LoadPropertyAction,
};

type Props = {
  propertyState: PropertyState;
  LoadPropertyAction: () => void;
};

export default connect(mapStateToProps, mapDispatchToProps)(HomePage);
