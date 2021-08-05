import { Login } from "../../models/login.model";
import { store } from "../../store/store";
import { render, RenderResult, screen } from "@testing-library/react";
import { Provider } from "react-redux";
import { MemoryRouter } from "react-router-dom";
import LoginPage from './login';

describe("Test Login page", ()=> {
   
  const renderLoginPage = (): RenderResult =>
    render(
      <Provider store={store}>
        <MemoryRouter>
          <LoginPage />
        </MemoryRouter>
      </Provider>
    );
  
    test("Render login page", () => {
      renderLoginPage();
      const initalLoginState = store.getState().login.login;
  
      let titleLogin = screen.getByText("Sign in");
      expect(titleLogin).toBeInTheDocument();
      let userNameLabel = screen.getByText("Username");
      expect(userNameLabel).toBeInTheDocument();
      let passwordLabel = screen.getByText("Password");
      expect(passwordLabel).toBeInTheDocument();
      let submitButton = screen.getByText("Login");
      expect(submitButton).toBeInTheDocument();

      expect(initalLoginState).toEqual({} as Login);
    });

   
  
})