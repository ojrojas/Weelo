import { User } from "../models/user.model";

export const ADD_USER = "ADD_USER";
export const UPDATE_USER = "UPDATE_USER";
export const DELETE_USER = "DELETE_USER";
export const LOAD_USERS = "LOAD_USERS";
export const ERROR_ACTIONS = "ERROR_ACTIONS";
export const GET_BY_ID_USER = "GET_BY_ID_USER";

export interface LoadUserAction {
  type: typeof LOAD_USERS;
  users: User[];
}

export interface UpdateUserAction {
  type: typeof UPDATE_USER;
  user: User;
}

export interface DeleteUserAction {
  type: typeof DELETE_USER;
  user: User;
}

export interface AddUserAction {
  type: typeof ADD_USER;
  user: User;
}

export interface ErrorUserAction {
  type: typeof ERROR_ACTIONS;
  error: any;
}

export interface GetByIdUserAction {
  type: typeof GET_BY_ID_USER;
  user: User;
}

export type UserActionTypes =
  | LoadUserAction
  | UpdateUserAction
  | DeleteUserAction
  | AddUserAction
  | ErrorUserAction
  | GetByIdUserAction;
