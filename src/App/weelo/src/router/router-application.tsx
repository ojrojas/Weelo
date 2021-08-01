import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { LoginPage } from "../pages/login/login";
import { LayoutPage } from "../pages/layout/layout";
import { HomePage } from "../pages/home/home";
import  AuthService  from '../services/auth.service';

const PrivateRoute = ({ component: Component, ...rest }: any) => (
    <Route
        {...rest}
        render={props =>
            AuthService.isAuthenticated() ? (
                <Component {...props} />
            ) : (
                <Redirect
                    to={{ pathname: '/', state: { from: props.location } }}
                />
            )
        }
    />
);

function RouterAppRoot() {
  return (
    <div>
      <Switch>
        <Route exact path="/login" component={LoginPage} />
        <Route exact path="/" component={LoginPage} />
        <PrivateRoute
          component={() => (
            <LayoutPage>
              <Route path="/Home" component={HomePage} />
            </LayoutPage>
          )}
        />
      </Switch>
    </div>
  );
}

export default RouterAppRoot;
