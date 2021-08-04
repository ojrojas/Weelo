import {
  Button,
  Container,
  CssBaseline,
  Grid,
  makeStyles,
  Typography,
} from "@material-ui/core";
import { useEffect } from "react";
import { OwnerState } from "../../reducer/owner.reducer";
import { AppState } from "../../store/root-reducer";
import historyRouter from "../../utils/history.router";
import { ReturnLogin } from "../../utils/return-login";
import { ListOwnerAction } from "../../actions/owner.actions";
import { connect } from "react-redux";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
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

const OwnerPage = (props: Props) => {
  const classes = useStyles();
  ReturnLogin();

  const loadData = () => {
    props.ListOwnerAction();
  };

  useEffect(() => {
    loadData();
  }, []);

  const createFunction = () => {
    historyRouter.push("users-create");
  };

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
          Users
        </Typography>
        <Grid container className={classes.root}>
          <Grid item xl={12}>
            <Button color="secondary" onClick={() => createFunction()}>
              Add User
            </Button>
            {/* <UserListPage /> */}
          </Grid>
        </Grid>
      </Container>
    </div>
  );
};

const mapStateToProps = (state: AppState) => ({
  ownerState: state.owner,
});

const mapDispatchToProps = {
  ListOwnerAction,
};

type Props = {
  ownerState: OwnerState;
  ListOwnerAction: () => void;
};

export default connect(mapStateToProps, mapDispatchToProps)(OwnerPage);
