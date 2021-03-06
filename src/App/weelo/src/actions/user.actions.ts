import { Dispatch } from "react";
import { User } from "../models/user.model";
import { ApiRequest } from "../services/api-request.service";
import { AppActions } from "../typeactions/app.typeactions";
import {
  ADD_USER,
  DELETE_USER,
  ERROR_ACTIONS,
  GET_BY_ID_USER,
  LOAD_USERS,
  UPDATE_USER,
} from "../typeactions/user.typeactions";
import { routeweelo } from "../utils/baseroute.route";
import historyRouter from "../utils/history.router";

const uriCreateUser = routeweelo + "create-user";
const uriDeleteUser = routeweelo + "delete-user/";
const uriGetByIdUser = routeweelo + "getbyid-user/";
const uriListUsers = routeweelo + "list-users";
const uriUpdateUser = routeweelo + "update-user/";

const request = new ApiRequest();

export const LoadUserSuccess = (users: User[]): AppActions => ({
  type: LOAD_USERS,
  users,
});

export const CreateUserSuccess = (user: User): AppActions => ({
  type: ADD_USER,
  user,
});

export const UpdateUserSuccess = (user: User): AppActions => ({
  type: UPDATE_USER,
  user,
});

export const DeleteUserSuccess = (user: User): AppActions => ({
  type: DELETE_USER,
  user,
});

export const GetByIdUserSuccess = (user: User): AppActions => ({
  type: GET_BY_ID_USER,
  user,
});

export const OnError = (error: any): AppActions => ({
  type: ERROR_ACTIONS,
  error,
});

export const LoadUserAction =
  () =>
  async (dispatch: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Get(uriListUsers);
    if (response.isAxiosError) {
      OnError(response);
    } else {
      dispatch(LoadUserSuccess(response.data.users));
    }
  };

export const CreateUserAction =
  (user: User) =>
  async (dispatch: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Post(uriCreateUser, user);
    if (response.isAxiosError) {
      OnError(response);
    } else {
      dispatch(CreateUserSuccess(response.data.userDto));
      historyRouter.goBack();
    }
  };

export const UpdateUserAction =
  (user: User) =>
  async (dispatch: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Put(uriUpdateUser + user.id, user);
    if (response.isAxiosError) {
      OnError(response);
    } else {
      dispatch(UpdateUserSuccess(response.data.userDto));
      historyRouter.goBack();
    }
  };

export const DeleteUserAction =
  (userId: string) =>
  async (dispatch: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Delete(uriDeleteUser + userId);
    if (response.isAxiosError) {
      OnError(response);
    } else {
      dispatch(DeleteUserSuccess(response.data.userDto));
      historyRouter.goBack();
    }
  };

export const GetByIdUserAction =
  (userId: string) =>
  async (dispatch: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Get(uriGetByIdUser + userId);
    if (response.isAxiosError) {
      OnError(response);
    } else {
      dispatch(GetByIdUserSuccess(response.data.userDto));
    }
  };
