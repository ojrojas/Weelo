import { Dispatch } from "react";
import { Login } from "../models/login.model";
import { ApiRequest } from "../services/api-request.service";
import StorageService from "../services/storage.services";
import { AppActions } from "../typeactions/app.typeactions";
import {
  ERROR_ACTIONS,
  LOGIN,
  LOGIN_SUCCESS,
} from "../typeactions/login.typeactions";
import { routeweelo } from "../utils/baseroute.route";
import historyRouter from "../utils/history.router";

const urilogin = routeweelo + "login";

const request = ApiRequest();

export const Logins = (login: Login): AppActions => ({
  type: LOGIN,
  login,
});

export const LoginSuccess = (auth_token: string): AppActions => ({
  type: LOGIN_SUCCESS,
  auth_token,
});

export const LoginFailure = (error: any): AppActions => ({
  type: ERROR_ACTIONS,
  error,
});

export const LoginAction =
  (login: Login, urlReturn: string) =>
  async (dispatch: Dispatch<AppActions>): Promise<void> => {
    dispatch(Logins(login));

    const response = await request.Request.Post(urilogin, login);
    if (response.isAxiosError) {
      LoginFailure(response);
    } else {
      LoginSuccess(response.data.auth_Token);
      if (response.data.auth_Token) {
        StorageService.setSessionToken(response.data.auth_Token);
        historyRouter.push(urlReturn);
      }
    }
  };
