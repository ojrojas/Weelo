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
import { AppState } from "../../../store/root-reducer";
import { CreatePropertyAction } from "../../../actions/property.actions";
import AuthService from "../../../services/auth.service";
import { ReturnLogin } from "../../../utils/return-login";
import { PropertyState } from "../../../reducer/property.reducer";
import { PropertyTraceState } from "../../../reducer/property-trace.reducer";
import { PropertyImageState } from "../../../reducer/property-image.reducer";
import { Property } from "../../../models/property.model";

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

const PropertyCreatePage = (props: Props) => {
  ReturnLogin();
  const classes = useStyles();
  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<Property>({});

  const onCreate = (property: Property) => {
    props.CreatePropertyAction(property);
  };

  const onSubmit = handleSubmit((data) => {
    const userInfo = AuthService.getUserInfo();
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
          Property Create
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
                  name="price"
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
                      id="price"
                      label="Price"
                      name="price"
                      type="number"
                      autoComplete="price"
                      autoFocus
                    />
                  )}
                />

                {errors.price && (
                  <div className={classes.errorscolors}>input price valid</div>
                )}

                <Controller
                  control={control}
                  rules={{
                    required: "this field is required.",
                  }}
                  name="codeInternal"
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
                      id="codeInternal"
                      type="number"
                      label="codeInternal"
                      name="codeInternal"
                      autoFocus
                    />
                  )}
                />

                {errors.codeInternal && (
                  <div className={classes.errorscolors}>
                    input code internal valid
                  </div>
                )}

                <Controller
                  control={control}
                  rules={{
                    required: "this field is required.",
                  }}
                  name="year"
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
                      id="year"
                      type="number"
                      label="Year"
                      name="year"
                      autoFocus
                    />
                  )}
                />

                {errors.year && (
                  <div className={classes.errorscolors}>
                    input code year valid
                  </div>
                )}

                <Controller
                  control={control}
                  rules={{
                    required: "this field is required.",
                  }}
                  name="ownerId"
                  render={({
                    field: { onChange, value },
                    fieldState: { error },
                  }) => (
                    <TextField
                      select
                      error={!!error}
                      helperText={error ? error.message : null}
                      variant="outlined"
                      margin="normal"
                      required
                      fullWidth
                      onChange={onChange}
                      id="ownerId"
                      label="Owner"
                      name="ownerId"
                      autoFocus
                    />
                  )}
                />

                {errors.ownerId && (
                  <div className={classes.errorscolors}>input owner valid</div>
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
  propertyState: state.property,
  propertyImageState: state.propertyImage,
  propertyTraceState: state.propertyTrace,
});

const mapDispatchToProps = {
  CreatePropertyAction,
};

type Props = {
  propertyState: PropertyState;
  propertyImageState: PropertyImageState;
  propertyTraceState: PropertyTraceState;
  CreatePropertyAction: (property: Property) => void;
};

export default connect(mapStateToProps, mapDispatchToProps)(PropertyCreatePage);
