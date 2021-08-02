import {
  Button,
  Checkbox,
  Container,
  CssBaseline,
  FormControlLabel,
  Grid,
  Link,
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
    width:600,
    padding:20,
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
                      fullWidth
                      onChange={onChange}
                      name="password"
                      label="Password"
                      type="password"
                      id="password"
                      autoComplete="current-password"
                    />
                  )}
                />

                {errors.userName && (
                  <div className={classes.errorscolors}>
                    input your password
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
