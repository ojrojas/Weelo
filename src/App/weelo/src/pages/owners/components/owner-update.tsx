import React, { ChangeEvent, useState } from "react";
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
import { UpdateOwnerAction } from "../../../actions/owner.actions";
import AuthService from "../../../services/auth.service";
import { ReturnLogin } from "../../../utils/return-login";
import { OwnerState } from "../../../reducer/owner.reducer";
import { Owner } from "../../../models/owner.model";
import { toImageBase64 } from "../../../services/imagehelper";

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

const OwnerUpdatePage = (props: Props) => {
  ReturnLogin();
  const owner = props.location.state.owner;
  let file: any;
  const [image, setImage] = useState<string>(owner.photo);
  const classes = useStyles();
  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<Owner>({
    defaultValues: owner,
  });

  const onCreate = (owner: Owner) => {
    props.UpdateOwnerAction(owner);
  };

  const onChangeImage = async (e: ChangeEvent<HTMLInputElement>) => {
    file = e.target.files;
    setImage("");
    if (file.length > 0) {
      setImage(await toImageBase64(file[0]));
    }
  };

  const onSubmit = handleSubmit(async (data) => {
    const userInfo = AuthService.getUserInfo();
    data.photo = image;
    data.modifiedBy = userInfo.Id;
    data.modifiedOn = new Date();
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
          Owners Update
        </Typography>
        <Grid container className={classes.root}>
          <Grid item xl={12}>
            <Paper elevation={1} className={classes.paper}>
              <form className={classes.form} noValidate onSubmit={onSubmit}>
                {image ? (
                  <div>
                    <img
                      src={image}
                      height="100"
                      width="100"
                      alt="card business"
                    />
                  </div>
                ) : (
                  <></>
                )}

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
                    <input
                      required
                      value={value}
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
                  name="photo"
                  render={({
                    field: { onChange, value },
                    fieldState: { error },
                  }) => (
                    <input
                      required
                      onChange={(e) => {
                        onChange([onChangeImage(e)]);
                      }}
                      id="photo"
                      name="photo"
                      type="file"
                    />
                  )}
                />

                {errors.photo && (
                  <div className={classes.errorscolors}>input image valid</div>
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
                      value={value}
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
                  <div className={classes.errorscolors}>input name valid</div>
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
                      value={value}
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
                      value={new Date(value)}
                      id="birthday"
                      label="Birthday"
                      name="birthday"
                      autoComplete="birthday"
                      autoFocus
                      InputLabelProps={{ shrink: true }}
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
  ownerState: state.owners,
});

const mapDispatchToProps = {
  UpdateOwnerAction,
};

type Props = {
  ownerState: OwnerState;
  UpdateOwnerAction: (owner: Owner) => void;
  location: {
    state: {
      owner: Owner;
    };
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(OwnerUpdatePage);
