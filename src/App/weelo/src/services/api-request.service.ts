import axios, { AxiosInstance } from "axios";
import { routeweelo } from "../utils/baseroute.route";
import StorageService from "./storage.service";

export class ApiRequest {
  apiAxios: AxiosInstance;
  constructor() {
    this.apiAxios = axios.create({
      baseURL: routeweelo,
      headers: {
        "Cache-Control": "no-cache",
      },
      //timeout: 15000,
    });

    this.apiAxios.interceptors.request.use(async (config) => {
      const token = StorageService.getSessionToken();
      if (token) {
        config.headers.Authorization = `Bearer ${token}`;
      }
      return config;
    });
  }

  Get = (uri: string) =>
    this.apiAxios
      .get(uri)
      .then((data) => data)
      .catch((error) => error);
  Post = (uri: string, body: any | undefined | null) =>
    this.apiAxios
      .post(uri, body)
      .then((data) => data)
      .catch((error) => error);
  Put = (uri: string, body: any | undefined | null) =>
    this.apiAxios
      .put(uri, body)
      .then((data) => data)
      .catch((error) => error);
  Delete = (uri: string) =>
    this.apiAxios
      .delete(uri)
      .then((data) => data)
      .catch((error) => error);
  Patch = (uri: string, body: any | undefined | null) =>
    this.apiAxios
      .patch(uri, body)
      .then((data) => data)
      .catch((error) => error);
}
