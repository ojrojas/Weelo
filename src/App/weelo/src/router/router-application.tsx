import React from "react";
import { Switch, Route } from "react-router-dom";
import LoginPage from "../pages/login/login";
import { LayoutPage } from "../pages/layout/layout";
import HomePage from "../pages/home/home";
import { CheckoutBasketPage } from "../checkout/checkout";
import UserPage from "../pages/user/user";
import UserCreatePage from "../pages/user/components/user-create";
import UserUpdatePage from "../pages/user/components/user-update";
import UserDeletePage from "../pages/user/components/user-delete";
import UserDetailPage from "../pages/user/components/user-detail";
import PropertyCreatePage from "../pages/properties/components/property-create";
import OwnerPage from "../pages/owners/owners";
import OwnerUpdatePage from "../pages/owners/components/owner-update";
import OwnerDeletePage from "../pages/owners/components/owner-delete";
import OwnerGetByIdPage from "../pages/owners/components/owner-get";
import OwnerCreatePage from "../pages/owners/components/owner-create";
// import AuthService from "../services/auth.service";

// const PrivateRoute = ({ component: Component, ...rest }: any) => (
//   <Route
//     {...rest}
//     render={(props) =>
//       AuthService.isAuthenticated() ? (
//         <Component {...props} />
//       ) : (
//         <Redirect to={{ pathname: "/", state: { from: props.location } }} />
//       )
//     }
//   />
// );

function RouterAppRoot() {
  return (
    <div>
      <Switch>
        <Route exact path="/login" component={LoginPage} />
        <LayoutPage>
          <Route exact path="/home" component={HomePage} />
          <Route exact path="/" component={HomePage} />
          <Route exact path="/checkout" component={CheckoutBasketPage} />
          <Route exact path="/users" component={UserPage} />
          <Route exact path="/users-create" component={UserCreatePage} />
          <Route exact path="/users-update" component={UserUpdatePage} />
          <Route exact path="/users-delete" component={UserDeletePage} />
          <Route exact path="/users-getbyid" component={UserDetailPage} />
          <Route exact path="/property-create" component={PropertyCreatePage} />
          <Route exact path="/owners" component={OwnerPage} />
          <Route exact path="/owners-update" component={OwnerUpdatePage} />
          <Route exact path="/owners-delete" component={OwnerDeletePage} />
          <Route exact path="/owners-getbyid" component={OwnerGetByIdPage} />
          <Route exact path="/owners-create" component={OwnerCreatePage} />
        </LayoutPage>
        {/* <PrivateRoute component={() => <LayoutPage></LayoutPage>} /> */}
      </Switch>
    </div>
  );
}

export default RouterAppRoot;
