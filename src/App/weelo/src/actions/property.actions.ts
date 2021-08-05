import { Dispatch } from "react";
import { Property } from "../models/property.model";
import { ApiRequest } from "../services/api-request.service";
import { AppActions } from "../typeactions/app.typeactions";
import {
  ADD_PROPERTY,
  DELETE_PROPERTY,
  ERROR_ACTIONS,
  GET_BY_ID_PROPERTY,
  LOAD_PROPERTIES,
  UPDATE_PROPERTY,
} from "../typeactions/property.typeactions";
import { routeweelo } from "../utils/baseroute.route";
import historyRouter from "../utils/history.router";

const request = new ApiRequest();
const getPropertyAll = routeweelo + "list-property";
const createProperty = routeweelo + "create-property";
const updateProperty = routeweelo + "update-property";
const getByIdProperty = routeweelo + "getbyidproperty-property";
const deleteProperty = routeweelo + "delete-property";

export const LoadProperty = (properties: Property[]): AppActions => ({
  type: LOAD_PROPERTIES,
  properties,
});

export const CreateProperty = (property: Property): AppActions => ({
  type: ADD_PROPERTY,
  property,
});

export const DeleteProperty = (property: Property): AppActions => ({
  type: DELETE_PROPERTY,
  property,
});

export const UpdateProperty = (property: Property): AppActions => ({
  type: UPDATE_PROPERTY,
  property,
});

export const GetByIdProperty = (property: Property): AppActions => ({
  type: GET_BY_ID_PROPERTY,
  property,
});

export const OnError = (error: any): AppActions => ({
  type: ERROR_ACTIONS,
  error,
});

export const LoadPropertyAction =
  () =>
  async (dispacth: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Get(getPropertyAll);
    if (response.isAxiosError) {
      dispacth(OnError(response));
    } else {
      dispacth(LoadProperty(response.data.properties));
    }
  };

export const CreatePropertyAction =
  (property: Property) =>
  async (dispacth: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Post(createProperty, property);
    if (response.isAxiosError) {
      dispacth(OnError(response));
    } else {
      dispacth(CreateProperty(response.data.propertyDto));
      historyRouter.goBack();
    }
  };

export const UpdatePropertyAction =
  (property: Property) =>
  async (dispacth: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Put(updateProperty, property);
    if (response.isAxiosError) {
      dispacth(OnError(response));
    } else {
      dispacth(UpdateProperty(response.data.propertyDto));
      historyRouter.goBack();
    }
  };

export const DeletePropertyAction =
  (property: Property) =>
  async (dispacth: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Delete(deleteProperty);
    if (response.isAxiosError) {
      dispacth(OnError(response));
    } else {
      dispacth(DeleteProperty(response.data.propertyDto));
      historyRouter.goBack();
    }
  };

export const GetByIdPropertyAction =
  (property: Property) =>
  async (dispacth: Dispatch<AppActions>): Promise<void> => {
    const response = await request.Get(getByIdProperty);
    if (response.isAxiosError) {
      dispacth(OnError(response));
    } else {
      dispacth(CreateProperty(response.data.propertyDto));
    }
  };
