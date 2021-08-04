import { PropertyTrace } from "../models/property-trace.model";

export const ADD_PROPERTY_TRACE = "ADD_PROPERTY_TRACE";
export const UPDATE_PROPERTY_TRACE = "UPDATE_PROPERTY_TRACE";
export const DELETE_PROPERTY_TRACE = "DELETE_PROPERTY_TRACE";
export const LIST_PROPERTIES_TRACE = "LIST_PROPERTIES_TRACE";
export const GET_BY_ID_PROPERTY_TRACE = "GET_BY_ID_PROPERTY_TRACE";
export const ACTIONS_ERRORS = "ACTIONS_ERRORS";

export interface LoadPropertyTraces {
  type: typeof LIST_PROPERTIES_TRACE;
  propertiesTrace: PropertyTrace[];
}

export interface CreatePropertyTraces {
  type: typeof ADD_PROPERTY_TRACE;
  propertyTrace: PropertyTrace;
}

export interface UpdatePropertyTraces {
  type: typeof UPDATE_PROPERTY_TRACE;
  propertyTrace: PropertyTrace;
}

export interface DeletePropertyTraces {
  type: typeof DELETE_PROPERTY_TRACE;
  propertyTrace: PropertyTrace;
}

export interface GetByIdPropertyTraces {
  type: typeof GET_BY_ID_PROPERTY_TRACE;
  propertyTrace: PropertyTrace;
}

export interface ErrorPropertyTraces {
  type: typeof ACTIONS_ERRORS;
  error: any;
}

export type PropertyTraceActionTypes =
  | LoadPropertyTraces
  | CreatePropertyTraces
  | UpdatePropertyTraces
  | DeletePropertyTraces
  | GetByIdPropertyTraces
  | ErrorPropertyTraces;
