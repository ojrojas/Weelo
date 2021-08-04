import React from "react";
import {
  Button,
  Container,
  CssBaseline,
  Grid,
  makeStyles,
  Paper,
  Typography,
} from "@material-ui/core";
import { connect } from "react-redux";
import { UserState } from "../../../reducer/user.reducer";
import { AppState } from "../../../store/root-reducer";
import { User } from "../../../models/user.model";
import { ReturnLogin } from "../../../utils/return-login";
import {DeleteUserAction} from '../../../actions/user.actions';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  typographic1: {
    marginBottom: theme.spacing(1),
  },
  control: {
    padding: theme.spacing(2),
  },
  paper: {
    marginTop: theme.spacing(2),
    display: "flex",
    width: 600,
    padding: 20,
    flexDirection: "column",
    alignItems: "center",
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: "100%", // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
  errorscolors: { color: "red" },
}));

const UserDeletePage = (props: Props) => {
  ReturnLogin();
  const  user  = props.location.state.user ;
  const classes = useStyles();

  const onDelete = (userId:string) => {
    props.DeleteUserAction(userId);
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
          Users Detail
        </Typography>
        <Grid container className={classes.root}>
          <Grid item xl={12}>
            <Paper elevation={1} className={classes.paper}>
              <Typography>Name: {user.name}</Typography>
              <Typography>Last Name: {user.lastName}</Typography>
              <Typography>UserName: {user.userName}</Typography>
            </Paper>
            <br/>
            <Button variant="outlined" color="secondary" onClick={() => onDelete(user.id)}>
              Delete
            </Button>
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
    DeleteUserAction,
};

type Props = {
  userState: UserState;
  DeleteUserAction: (userId:string)=>void;
  location: { state: {
    user:User
  }}
};

export default connect(mapStateToProps, mapDispatchToProps)(UserDeletePage);
