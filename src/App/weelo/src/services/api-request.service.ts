import axios from "axios";
import { routeweelo } from "../utils/baseroute.route";
import StorageService from "./storage.services";

export const ApiRequest = () => {
  const apiAxios = axios.create({
    baseURL: routeweelo,
    headers: {
      "Cache-Control": "no-cache",
    },
    timeout: 15000,
  });

  apiAxios.interceptors.request.use(async (config) => {
    const token = StorageService.getSessionToken();
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  });

  const Request = {
    Get: (uri: string) =>
      apiAxios
        .get(uri)
        .then((data) => data)
        .catch((error) => error),
    Post: (uri: string, body: any | undefined | null) =>
      apiAxios
        .post(uri, body)
        .then((data) => data)
        .catch((error) => error),
    Put: (uri: string, body: any | undefined | null) =>
      apiAxios
        .put(uri, body)
        .then((data) => data)
        .catch((error) => error),
    Delete: (uri: string) =>
      apiAxios
        .delete(uri)
        .then((data) => data)
        .catch((error) => error),
    Patch: (uri: string, body: any | undefined | null) =>
      apiAxios
        .patch(uri, body)
        .then((data) => data)
        .catch((error) => error),
  };

  return {
    Request,
  };
};
