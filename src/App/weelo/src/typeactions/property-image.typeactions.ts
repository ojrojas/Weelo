import { PropertyImage } from "../models/property-image.model";

export const ADD_PROPERTY_IMAGE = "ADD_PROPERTY_IMAGE";
export const UPDATE_PROPERTY_IMAGE = "UPDATE_PROPERTY_IMAGE";
export const DELETE_PROPERTY_IMAGE = "DELETE_PROPERTY_IMAGE";
export const LIST_PROPERTIES_IMAGE = "LIST_PROPERTIES_IMAGE";
export const GET_BY_ID_PROPERTY_IMAGE = "GET_BY_ID_PROPERTY_IMAGE";
export const ACTIONS_ERRORS = "ACTIONS_ERRORS";

export interface LoadPropertyImages {
  type: typeof LIST_PROPERTIES_IMAGE;
  propertiesImage: PropertyImage[];
}

export interface CreatePropertyImages {
  type: typeof ADD_PROPERTY_IMAGE;
  propertyImage: PropertyImage;
}

export interface UpdatePropertyImages {
  type: typeof UPDATE_PROPERTY_IMAGE;
  propertyImage: PropertyImage;
}

export interface DeletePropertyImages {
  type: typeof DELETE_PROPERTY_IMAGE;
  propertyImage: PropertyImage;
}

export interface GetByIdPropertyImages {
  type: typeof GET_BY_ID_PROPERTY_IMAGE;
  propertyImage: PropertyImage;
}

export interface ErrorPropertyImages {
  type: typeof ACTIONS_ERRORS;
  error: any;
}

export type PropertyImageActionTypes =
  | LoadPropertyImages
  | CreatePropertyImages
  | UpdatePropertyImages
  | DeletePropertyImages
  | GetByIdPropertyImages
  | ErrorPropertyImages;
