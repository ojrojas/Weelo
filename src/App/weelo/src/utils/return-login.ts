import StorageService from "../services/storage.service";
import historyRouter from "./history.router";


export const ReturnLogin = () => {
    const token = StorageService.getSessionToken();
  if (!token) {
    historyRouter.push("login");
  }
};
