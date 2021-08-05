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
import { AppState } from "../../../store/root-reducer";
import historyRouter from "../../../utils/history.router";
import { ReturnLogin } from "../../../utils/return-login";
import { OwnerState } from "../../../reducer/owner.reducer";
import { Owner } from "../../../models/owner.model";

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

const OwnerGetByIdPage = (props: Props) => {
  ReturnLogin();
  const  owner  = props.location.state.owner ;
  const classes = useStyles();

  const goBack = () => {
    historyRouter.goBack();
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
          Owner Detail
        </Typography>
        <Grid container className={classes.root}>
          <Grid item xl={12}>
            <Paper elevation={1} className={classes.paper}>
                <img src={owner.photo} width="50" height="50" alt="no-card-businnes"/>
              <Typography>Name: {owner.name}</Typography>
              <Typography>Address: {owner.address}</Typography>
              <Typography>Brithday: {owner.birthday}</Typography>
            </Paper>
            <br/>
            <Button color="secondary" onClick={() => goBack()}>
              Back
            </Button>
          </Grid>
        </Grid>
      </Container>
    </div>
  );
};

const mapStateToProps = (state: AppState) => ({
    ownerState: state.owners,
});

const mapDispatchToProps = {};

type Props = {
  ownerState: OwnerState;
  location: { state: {
    owner:Owner
  }}
};

export default connect(mapStateToProps, mapDispatchToProps)(OwnerGetByIdPage);
