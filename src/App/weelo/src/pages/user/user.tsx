import React, { useEffect } from "react";
import {
  Button,
  Container,
  CssBaseline,
  Grid,
  makeStyles,
  Typography,
} from "@material-ui/core";
import { ReturnLogin } from "../../utils/return-login";
import { AppState } from "../../store/root-reducer";
import {
  LoadUserAction,
  CreateUserAction,
  UpdateUserAction,
  DeleteUserAction,
  GetByIdUserAction,
} from "../../actions/user.actions";
import { UserState } from "../../reducer/user.reducer";
import { connect } from "react-redux";
import { User } from "../../models/user.model";
import UserListPage from "./components/user-list";
import historyRouter from "../../utils/history.router";

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

const UserPage = (props: Props) => {
  const classes = useStyles();
  ReturnLogin();

  const loadData = () => {
    props.LoadUserAction();
  };

  useEffect(() => {
    loadData();
  },[]);

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
            <UserListPage />
          </Grid>
        </Grid>
      </Container>
    </div>
  );
};

const mapStateToProps = (state: AppState) => ({
  userState: state.users,
});

const mapDispatchToProps = {
  LoadUserAction,
  CreateUserAction,
  UpdateUserAction,
  DeleteUserAction,
  GetByIdUserAction,
};

type Props = {
  userState: UserState;
  LoadUserAction: () => void;
  CreateUserAction: (user: User) => void;
  UpdateUserAction: (user: User) => void;
  DeleteUserAction: (userId: string) => void;
  GetByIdUserAction: (userId: string) => void;
};

export default connect(mapStateToProps, mapDispatchToProps)(UserPage);
