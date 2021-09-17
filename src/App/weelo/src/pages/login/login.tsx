import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import CssBaseline from "@material-ui/core/CssBaseline";
import TextField from "@material-ui/core/TextField";
import Box from "@material-ui/core/Box";
import LockOutlinedIcon from "@material-ui/icons/LockOutlined";
import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";
import Container from "@material-ui/core/Container";
import { connect } from "react-redux";
import { AppState } from "../../store/root-reducer";
import { LoginAction } from "../../actions/login.actions";
import { LoginState } from "../../reducer/login.reducer";
import { Login } from "../../models/login.model";
import { useForm, Controller } from "react-hook-form";

function Copyright() {
  return (
    <div>
      <Typography variant="body2" color="textSecondary" align="center">
        Copyright ©
      </Typography>
      <Typography>
        Weelo Test
        {new Date().getFullYear()} .
      </Typography>
    </div>
  );
}

const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(8),
    display: "flex",
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

const LoginPage = (props: Props) => {
  const classes = useStyles();

  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<Login>({});

  const onLogin = (login: Login) => {
    props.LoginAction(login, 'home');
  };

  const onSubmit = handleSubmit((data) => {
    onLogin(data);
  });

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Avatar className={classes.avatar}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign in
        </Typography>
        <form className={classes.form} noValidate onSubmit={onSubmit}>
          <Controller
            control={control}
            rules={{
              required: "this field is required.",
            }}
            name="userName"
            render={({ field: { onChange, value }, fieldState: { error } }) => (
              <TextField
                error={!!error}
                helperText={
                  error ? error.message : null
                }
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
            <div className={classes.errorscolors}>input username valid</div>
          )}

          <Controller
            control={control}
            rules={{
              required: "this field is required.",
            }}
            name="password"
            render={({ field: { onChange, value }, fieldState: { error } }) => (
              <TextField
                error={!!error}
                helperText={
                  error ? error.message : null
                }
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
            <div className={classes.errorscolors}>input your password</div>
          )}
          <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
          >
            Login
          </Button>
        </form>
      </div>
      <Box mt={8}>
        <Copyright />
      </Box>
    </Container>
  );
};

const mapStateToProps = (state: AppState) => ({
  loginState: state.login,
});

const mapDispatchToProps = {
  LoginAction,
};

type Props = {
  loginState: LoginState;
  LoginAction: (login: Login, uriReturl: string) => void;
};

export default connect(mapStateToProps, mapDispatchToProps)(LoginPage);
