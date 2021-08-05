import React, {
  ChangeEvent,
  useEffect,
  useState,
  VoidFunctionComponent,
} from "react";
import {
  Button,
  Container,
  CssBaseline,
  FormControl,
  Grid,
  InputLabel,
  makeStyles,
  MenuItem,
  NativeSelect,
  Paper,
  Select,
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
import { OwnerState } from "../../../reducer/owner.reducer";
import { ListOwnerAction } from "../../../actions/owner.actions";
import { Owner } from "../../../models/owner.model";
import { toImageBase64 } from "../../../services/imagehelper";

const useStyles = makeStyles((theme) => ({
  root: {},
  typographic1: {
    marginBottom: theme.spacing(1),
  },
  control: {
    padding: theme.spacing(1),
  },
  paper: {
    marginTop: theme.spacing(2),
    display: "flex",
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
    margin: theme.spacing(1, 0, 2),
  },
  formControl: {
    margin: theme.spacing(1),
    width: "100%",
  },
  errorscolors: { color: "red" },
}));

const PropertyCreatePage = (props: Props) => {
  ReturnLogin();
  let file: any;
  const classes = useStyles();
  const {
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<Property>({});
  const [image, setImage] = useState<string>("");

  const onCreate = (property: Property) => {
    props.CreatePropertyAction(property);
  };

  const onSubmit = handleSubmit((data) => {
    const userInfo = AuthService.getUserInfo();
    if(image=== '') return;
    data.propertyImage.file = image;
    data.propertyImage.width = 100;
    data.propertyImage.height= 200;
    data.createdBy = userInfo.Id;
    data.createOn = new Date();
    onCreate(data);
  });

  const onChangeImage = async (e: ChangeEvent<HTMLInputElement>) => {
    file = e.target.files;
    setImage("");
    if (file.length > 0) {
      setImage(await toImageBase64(file[0]));
    }
  };

  useEffect(() => {
    const loadData = () => {
      props.ListOwnerAction();
      loadData();
    };
  }, [props]);

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
          <form className={classes.form} noValidate onSubmit={onSubmit}>
            <Grid container xl={12}>
              <Grid item md={4} xs={4}>
                <Paper elevation={1} className={classes.paper}>
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
                    name="propertyImage.file"
                    render={({
                      field: { onChange, value },
                      fieldState: { error },
                    }) => (
                      <input
                        required
                        onChange={(e) => {
                          onChange([onChangeImage(e)]);
                        }}
                        id="propertyImage.file"
                        name="propertyImage.file"
                        type="file"
                      />
                    )}
                  />

                  {errors.propertyImage?.file && (
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
                    <div className={classes.errorscolors}>
                      input price valid
                    </div>
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
                        onInput={(e: any) => {
                          e.target.value = Math.max(0, parseInt(e.target.value))
                            .toString()
                            .slice(0, 4);
                        }}
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
                      <FormControl className={classes.formControl}>
                        <InputLabel htmlFor="ownerId">Owner</InputLabel>
                        <NativeSelect
                          error={!!error}
                          variant="outlined"
                          margin="none"
                          required
                          fullWidth
                          onChange={onChange}
                          id="ownerId"
                          name="ownerId"
                          autoFocus
                        >
                          <option key="option-blank" value=""></option>
                          {props.ownerState.owners.map((option: Owner) => (
                            <option key={option.id} value={option.id}>
                              {option.name}
                            </option>
                          ))}
                        </NativeSelect>
                      </FormControl>
                    )}
                  />

                  {errors.ownerId && (
                    <div className={classes.errorscolors}>
                      input owner valid
                    </div>
                  )}
                </Paper>
              </Grid>
              <Grid item md={4} xs={4}>
                <Paper elevation={1} className={classes.paper}>
                  <Controller
                    control={control}
                    rules={{
                      required: "this field is required.",
                    }}
                    name="propertyTrace.dateSale"
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
                        id="propertyTrace.dateSale"
                        label="Date Sale"
                        name="propertyTrace.dateSale"
                        autoComplete="propertyTrace.dateSale"
                        autoFocus
                        type="date"
                        InputLabelProps={{ shrink: true, required: true }}
                      />
                    )}
                  />

                  {errors.propertyTrace?.dateSale && (
                    <div className={classes.errorscolors}>
                      input date sale valid
                    </div>
                  )}

                  <Controller
                    control={control}
                    rules={{
                      required: "this field is required.",
                    }}
                    name="propertyTrace.name"
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
                        id="propertyTrace.name"
                        label="Trace name"
                        name="propertyTrace.name"
                        autoComplete="propertyTrace.name"
                        autoFocus
                      />
                    )}
                  />

                  {errors.propertyTrace?.name && (
                    <div className={classes.errorscolors}>
                      input trace trace name valid
                    </div>
                  )}

                  <Controller
                    control={control}
                    rules={{
                      required: "this field is required.",
                    }}
                    name="propertyTrace.value"
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
                        id="propertyTrace.value"
                        label="Trace value"
                        name="propertyTrace.value"
                        type="number"
                        autoComplete="propertyTrace.value"
                        autoFocus
                      />
                    )}
                  />

                  {errors.propertyTrace?.value && (
                    <div className={classes.errorscolors}>
                      input value valid
                    </div>
                  )}

                  <Controller
                    control={control}
                    rules={{
                      required: "this field is required.",
                    }}
                    name="propertyTrace.tax"
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
                        id="propertyTrace.tax"
                        type="number"
                        label="Trace tax"
                        name="propertyTrace.tax"
                        autoFocus
                      />
                    )}
                  />

                  {errors.propertyTrace?.tax && (
                    <div className={classes.errorscolors}>input tax valid</div>
                  )}
                </Paper>
              </Grid>
            </Grid>

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
        </Grid>
      </Container>
    </div>
  );
};

const mapStateToProps = (state: AppState) => ({
  propertyState: state.property,
  propertyImageState: state.propertyImage,
  propertyTraceState: state.propertyTrace,
  ownerState: state.owners,
});

const mapDispatchToProps = {
  CreatePropertyAction,
  ListOwnerAction,
};

type Props = {
  propertyState: PropertyState;
  propertyImageState: PropertyImageState;
  propertyTraceState: PropertyTraceState;
  ownerState: OwnerState;
  CreatePropertyAction: (property: Property) => void;
  ListOwnerAction: () => void;
};

export default connect(mapStateToProps, mapDispatchToProps)(PropertyCreatePage);
