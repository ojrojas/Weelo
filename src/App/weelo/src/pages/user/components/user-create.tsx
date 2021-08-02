import React from 'react';
import {
  Button,
  Container,
  CssBaseline,
  Grid,
  makeStyles,
  Paper,
  TextField,
  Typography,
} from "@material-ui/core";
import { Controller, useForm } from "react-hook-form";
import { connect } from "react-redux";
import { User } from "../../../models/user.model";
import { UserState } from "../../../reducer/user.reducer";
import { AppState } from "../../../store/root-reducer";
import { CreateUserAction } from "../../../actions/user.actions";
import AuthService from '../../../services/auth.service';

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

const UserCreatePage = (props: Props) => {
  const classes = useStyles();
  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<User>({});

  const onCreate = (user: User) => {
    props.CreateUserAction(user);
  };

  const onSubmit = handleSubmit((data) => {
    const userInfo = AuthService.getUserInfo() as User;
    data.createdBy = userInfo.createdBy;
    data.createOn = new Date();
    onCreate(data);
  });

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
            <Paper elevation={1} className={classes.paper}>
              <form className={classes.form} noValidate onSubmit={onSubmit}>
                <Controller
                  control={control}
                  rules={{
                    required: "this field is required.",
                  }}
                  name="name"
                  render={({
                    field: { onChange, value },
                    fieldState: { error },
                  }) => (
                    <TextField
                      error={!!error}
                      helperText={error ? error.message : null}
                      variant="outlined"
                      margin="normal"
                      required
                      fullWidth
                      onChange={onChange}
                      id="name"
                      label="Name"
                      name="name"
                      autoComplete="name"
                      autoFocus
                    />
                  )}
                />

                {errors.userName && (
                  <div className={classes.errorscolors}>
                    input name valid
                  </div>
                )}

                <Controller
                  control={control}
                  rules={{
                    required: "this field is required.",
                  }}
                  name="lastName"
                  render={({
                    field: { onChange, value },
                    fieldState: { error },
                  }) => (
                    <TextField
                      error={!!error}
                      helperText={error ? error.message : null}
                      variant="outlined"
                      margin="normal"
                      required
                      fullWidth
                      onChange={onChange}
                      id="lastName"
                      label="Last Name"
                      name="lastName"
                      autoComplete="lastName"
                      autoFocus
                    />
                  )}
                />

                {errors.userName && (
                  <div className={classes.errorscolors}>
                    input lastname valid
                  </div>
                )}

                <Controller
                  control={control}
                  rules={{
                    required: "this field is required.",
                  }}
                  name="userName"
                  render={({
                    field: { onChange, value },
                    fieldState: { error },
                  }) => (
                    <TextField
                      error={!!error}
                      helperText={error ? error.message : null}
                      variant="outlined"
                      margin="normal"
                      required
                      fullWidth
                      onChange={onChange}
                      id="username"
                      label="Username"
                      name="username"
                      autoComplete="username"
                      autoFocus
                    />
                  )}
                />

                {errors.userName && (
                  <div className={classes.errorscolors}>
                    input username valid
                  </div>
                )}

                <Controller
                  control={control}
                  rules={{
                    required: "this field is required."
                  }}
                  name="password"
                  render={({
                    field: { onChange, value },
                    fieldState: { error },
                  }) => (
                    <TextField
                      error={!!error}
                      helperText={error ? error.message : null}
                      variant="outlined"
                      margin="normal"
                      required
                      fullWidth
                      onChange={onChange}
                      id="password"
                      type="password"
                      label="Password"
                      name="password"
                      autoComplete="password"
                      autoFocus
                    />
                  )}
                />

                {errors.userName && (
                  <div className={classes.errorscolors}>
                    input password valid
                  </div>
                )}

                <Button
                  type="submit"
                  fullWidth
                  variant="contained"
                  color="primary"
                  className={classes.submit}
                >
                  Create
                </Button>
              </form>
            </Paper>
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
  CreateUserAction,
};

type Props = {
  userState: UserState;
  CreateUserAction: (user: User) => void;
};

export default connect(mapStateToProps, mapDispatchToProps)(UserCreatePage);
