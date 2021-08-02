import { Login } from "../models/login.model";

export const LOGIN = 'LOGIN';
export const LOGIN_SUCCESS = 'LOGIN_SUCCESS';
export const ERROR_ACTIONS = 'ERROR_ACTIONS';

export interface LoginAction {
    type: typeof LOGIN;
    login: Login;
}

export interface LoginSuccess {
    type: typeof LOGIN_SUCCESS;
    auth_token: string;
}

export interface LoginError {
    type: typeof ERROR_ACTIONS;
    error: any;
}

export type LoginActionTypes =
    | LoginAction
    | LoginSuccess
    | LoginError;
