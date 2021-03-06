import React from "react";
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
import { UpdateUserAction } from "../../../actions/user.actions";
import AuthService from "../../../services/auth.service";
import { ReturnLogin } from "../../../utils/return-login";

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

const UserUpdatePage = (props: Props) => {
  ReturnLogin();
  const user = props.location.state.user;
  const classes = useStyles();
  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<User>({
    defaultValues:user
  });

  const onUpdate = (user: User) => {
    props.UpdateUserAction(user);
  };

  const onSubmit = handleSubmit((data) => {
    const userInfo = AuthService.getUserInfo();
    data.modifiedBy = userInfo.Id;
    data.modifiedOn = new Date();
    onUpdate(data);
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
          Users Update
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
                  name="id"
                  render={({
                    field: { onChange, value },
                    fieldState: { error },
                  }) => (
                    <TextField
                      required
                      value={value}
                      onChange={onChange}
                      id="id"
                      name="id"
                      type="hidden"
                    />
                  )}
                />
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
                      value={value}
                      fullWidth
                      onChange={onChange}
                      id="name"
                      label="Name"
                      name="name"
                      autoComplete="name"
                      autoFocus
                      InputLabelProps={{ shrink: user.name !== undefined ? true: false }}
                    />
                  )}
                />

                {errors.userName && (
                  <div className={classes.errorscolors}>input name valid</div>
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
                      value={value}
                      id="lastName"
                      label="Last Name"
                      name="lastName"
                      autoComplete="lastName"
                      autoFocus
                      InputLabelProps={{ shrink: user.lastName !== undefined ? true: false }}
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
                      value={value}
                      id="userName"
                      label="Username"
                      name="userName"
                      autoComplete="userName"
                      autoFocus
                      InputLabelProps={{ shrink: user.userName !== undefined ? true: false }}
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
                    required: "this field is required.",
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
                      value={value}
                      fullWidth
                      onChange={onChange}
                      id="password"
                      type="password"
                      label="Password"
                      name="password"
                      autoComplete="password"
                      autoFocus
                      InputLabelProps={{ shrink: user.password !== undefined ? true: false }}
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
                  Update
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
  UpdateUserAction,
};

type Props = {
  userState: UserState;
  UpdateUserAction: (user: User) => void;
  location: {
    state: {
      user: User;
    };
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(UserUpdatePage);
