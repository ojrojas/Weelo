import { Login } from "../models/login.model";
import {
  ERROR_ACTIONS,
  LOGIN,
  LoginActionTypes,
  LOGIN_SUCCESS,
} from "../typeactions/login.typeactions";

export interface LoginState {
  login: Login;
  auth_token: string;
  error: any;
}

const InitialLoginState: LoginState = {
  login: {} as Login,
  auth_token: "",
  error: null,
};

export const LoginReducer = (
  state: LoginState = InitialLoginState,
  action: LoginActionTypes
): LoginState => {
  switch (action.type) {
    case LOGIN:
      return {
        ...state,
        login: action.login,
      };
    case LOGIN_SUCCESS:
      return {
        ...state,
        auth_token: action.auth_token,
      };
    case ERROR_ACTIONS:
      return {
        ...state,
        error: action.error,
      };

    default:
      return state;
  }
};
