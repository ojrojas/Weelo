import { User } from "../types/user.type";

export const ADD_USER = 'ADD_USER';
export const UPDATE_USER = 'UPDATE_USER';
export const DELETE_USER = 'DELETE_USER';
export const LOAD_USERS = 'LOAD_USERS';
export const ERROR_ACTIONS = 'ERROR_ACTIONS';

export interface SetUserAction {
    type: typeof LOAD_USERS;
    users: User[];
}

export interface UpdateUserAction {
    type: typeof UPDATE_USER;
    user: User;
}

export interface DeleteUserAction {
    type: typeof DELETE_USER;
    id: number;
}

export interface AddUserAction {
    type: typeof ADD_USER;
    user: User;
}

export interface ErrorUserAction {
    type: typeof ERROR_ACTIONS;
    error: any;
}

export type UserActionTypes =
    | SetUserAction
    | UpdateUserAction
    | DeleteUserAction
    | AddUserAction
    | ErrorUserAction;
