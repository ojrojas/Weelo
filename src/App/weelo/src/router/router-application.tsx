import React from "react";
import { Switch, Route } from "react-router-dom";
import { LoginPage } from "../pages/login/login";
import { LayoutPage } from "../pages/layout/layout";
import { HomePage } from "../pages/home/home";
import { CheckoutBasketPage } from "../checkout/checkout";

function RouterAppRoot() {
  return (
    <div>
      <Switch>
        <LayoutPage>
          <Route exact path="/home" component={HomePage} />
          <Route exact path="/" component={HomePage} />
          <Route exact path="/checkout" component={CheckoutBasketPage} />
          <Route exact path="/login" component={LoginPage} />
        </LayoutPage>
      </Switch>
    </div>
  );
}

export default RouterAppRoot;
