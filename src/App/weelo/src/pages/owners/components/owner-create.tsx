import React, { ChangeEvent } from 'react';
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
import { AppState } from "../../../store/root-reducer";
import { CreateOwnerAction } from "../../../actions/owner.actions";
import AuthService from '../../../services/auth.service';
import { ReturnLogin } from '../../../utils/return-login';
import { OwnerState } from '../../../reducer/owner.reducer';
import { Owner } from '../../../models/owner.model';
import { toImageBase64 } from '../../../services/imagehelper';

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

const OwnerCreatePage = (props: Props) => {
  ReturnLogin();
  let file:any;
  const classes = useStyles();
  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<Owner>({});

  const onCreate = (owner: Owner) => {
    props.CreateOwnerAction(owner);
  };

  const onChangeImage = (e: ChangeEvent<HTMLInputElement>) => {
    file = e.target.files;
    e.preventDefault();
  }

  const onSubmit = handleSubmit(async (data) => {
    const userInfo = AuthService.getUserInfo();
    data.image = await toImageBase64(file[0]);
    data.createdBy = userInfo.Id;
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
          Owners Create
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
                  name="image"
                  render={({
                    field: { onChange,value },
                    fieldState: { error },
                  }) => (
                    <input
                      required
                      onChange={e => {onChange([onChangeImage(e)])}}
                      id="image"
                      name="image"
                      type="file"
                    />
                  )}
                />

                {errors.image && (
                  <div className={classes.errorscolors}>
                    input image valid
                  </div>
                )}


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

                {errors.name && (
                  <div className={classes.errorscolors}>
                    input name valid
                  </div>
                )}

                <Controller
                  control={control}
                  rules={{
                    required: "this field is required.",
                  }}
                  name="address"
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
                      id="address"
                      label="Address"
                      name="address"
                      autoComplete="address"
                      autoFocus
                    />
                  )}
                />

                {errors.address && (
                  <div className={classes.errorscolors}>
                    input address valid
                  </div>
                )}

                <Controller
                  control={control}
                  rules={{
                    required: "this field is required.",
                  }}
                  name="birthday"
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
                      type="date"
                      fullWidth
                      onChange={onChange}
                      id="birthday"
                      label="Birthday"
                      name="birthday"
                      autoComplete="birthday"
                      autoFocus
                      InputLabelProps={{shrink:true}}
                    />
                  )}
                />

                {errors.birthday && (
                  <div className={classes.errorscolors}>
                    input birthday valid
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
  ownerState: state.owners,
});

const mapDispatchToProps = {
    CreateOwnerAction,
};

type Props = {
  ownerState: OwnerState;
  CreateOwnerAction: (owner: Owner) => void;
};

export default connect(mapStateToProps, mapDispatchToProps)(OwnerCreatePage);