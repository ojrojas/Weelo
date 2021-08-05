import { Login } from "../models/login.model";
import { store } from "../store/store";
import { LoginAction, LoginFailure, Logins, LoginSuccess } from "./login.actions";

describe("Test actions login", () => {
  test("login type action", () => {
   
    const loginvalid: Login = {
      userName: "nicoles",
      password: "password",
    };

    store.dispatch(LoginAction(loginvalid, "returnUrl"));
    const resultToken = "token valid";
    store.dispatch(LoginSuccess(resultToken));
    store.dispatch(Logins(loginvalid));
    store.dispatch(LoginFailure(new Error("Error")));
    let state = store.getState().login;
    expect(state.login).toEqual(loginvalid);
    expect(state.auth_token).toBe(resultToken);
    expect("Error").toBe(state.error.name);
  });
});
