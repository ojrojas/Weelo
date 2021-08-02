import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import { UserState } from "../../../reducer/user.reducer";
import { AppState } from "../../../store/root-reducer";
import { connect } from "react-redux";
import { User } from "../../../models/user.model";
import { Button } from "@material-ui/core";
import historyRouter from "../../../utils/history.router";

const useStyles = makeStyles({
  table: {
    minWidth: 650,
  },
});

const UserListPage = (props: Props) => {
  const classes = useStyles();

  const updateFunction = (userId: string): void => {
    historyRouter.push("users-update", { state: userId });
  };

  const detailFunction = (userId: string): void => {
    historyRouter.push("users-getbyid", { state: userId });
  };

  const deleteFunction = (userId: string): void => {
    historyRouter.push("users-delete", { state: userId });
  };

  return (
    <TableContainer component={Paper}>
      <Table className={classes.table} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>#</TableCell>
            <TableCell>Name</TableCell>
            <TableCell>Last name</TableCell>
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.userState.users.map((user: User, index:number) => (
            <TableRow key={user.name}>
              <TableCell component="th" scope="row">
                {index+1}
              </TableCell>
              <TableCell>{user.lastName}</TableCell>
              <TableCell>{user.lastName}</TableCell>
              <TableCell>
                <Button
                  color="secondary"
                  onClick={(e) => updateFunction(user.id)}
                >
                  Update
                </Button>
                <Button
                  color="secondary"
                  onClick={(e) => detailFunction(user.id)}
                >
                  Detail
                </Button>
                <Button
                  color="secondary"
                  onClick={(e) => deleteFunction(user.id)}
                >
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
  userState: state.users,
});

type Props = {
  userState: UserState;
};

export default connect(mapStateToProps)(UserListPage);
