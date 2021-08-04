import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import { AppState } from "../../../store/root-reducer";
import { connect } from "react-redux";
import { Button } from "@material-ui/core";
import historyRouter from "../../../utils/history.router";
import { ReturnLogin } from "../../../utils/return-login";
import { OwnerState } from "../../../reducer/owner.reducer";
import { Owner } from "../../../models/owner.model";

const useStyles = makeStyles({
  table: {
    minWidth: 650,
  },
});

const OwnerListPage = (props: Props) => {
  ReturnLogin();
  const classes = useStyles();

  const updateFunction = (owner: Owner): void => {
    historyRouter.push("owners-update", { owner: owner });
  };

  const detailFunction = (owner: Owner): void => {
    historyRouter.push("owners-getbyid", { owner: owner });
  };

  const deleteFunction = (owner: Owner): void => {
    historyRouter.push("owners-delete", { owner: owner });
  };

  return (
    <TableContainer component={Paper}>
      <Table className={classes.table} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>#</TableCell>
            <TableCell>Name</TableCell>
            <TableCell>Birthday</TableCell>
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.ownerState.owners.map((owner: Owner, index: number) => (
            <TableRow key={owner.name}>
              <TableCell component="th" scope="row">
                {index + 1}
              </TableCell>
              <TableCell>{owner.name}</TableCell>
              <TableCell>{owner.birthday}</TableCell>
              <TableCell>
                <Button color="secondary" onClick={(e) => updateFunction(owner)}>
                  Update
                </Button>
                <Button color="secondary" onClick={(e) => detailFunction(owner)}>
                  Detail
                </Button>
                <Button color="secondary" onClick={(e) => deleteFunction(owner)}>
                  Delete
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

const mapStateToProps = (state: AppState) => ({
  ownerState: state.owners,
});

type Props = {
  ownerState: OwnerState;
};

export default connect(mapStateToProps)(OwnerListPage);
