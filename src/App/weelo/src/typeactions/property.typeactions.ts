import { Property } from "../models/property.model";

export const ADD_PROPERTY = "ADD_PROPERTY";
export const UPDATE_PROPERTY = "UPDATE_PROPERTY";
export const DELETE_PROPERTY = "DELETE_PROPERTY";
export const LOAD_PROPERTIES = "LOAD_PROPERTIES";
export const ERROR_ACTIONS = "ERROR_ACTIONS";
export const GET_BY_ID_PROPERTY = "GET_BY_ID_PROPERTY";

export interface LoadPropertiesAction {
  type: typeof LOAD_PROPERTIES;
  properties: Property[];
}

export interface CreatePropertyAction {
  type: typeof ADD_PROPERTY;
  property: Property;
}

export interface UpdatePropertyAction {
  type: typeof UPDATE_PROPERTY;
  property: Property;
}

export interface DeletePropertyAction {
  type: typeof DELETE_PROPERTY;
  property: Property;
}

export interface GetByIdPropertyAction {
  type: typeof GET_BY_ID_PROPERTY;
  property: Property;
}

export interface ErrorPropertyAction {
  type: typeof ERROR_ACTIONS;
  error: any;
}

export type PropertyActionTypes =
  | LoadPropertiesAction
  | CreatePropertyAction
  | UpdatePropertyAction
  | DeletePropertyAction
  | GetByIdPropertyAction
  | ErrorPropertyAction;
