import { PropertyTrace } from "../models/property-trace.model";
import {
  ACTIONS_ERRORS,
  ADD_PROPERTY_TRACE,
  DELETE_PROPERTY_TRACE,
  GET_BY_ID_PROPERTY_TRACE,
  LIST_PROPERTIES_TRACE,
  PropertyTraceActionTypes,
  UPDATE_PROPERTY_TRACE,
} from "../typeactions/property-trace.typeactions";

export interface PropertyTraceState {
  propertyTrace: PropertyTrace;
  propertiesTrace: PropertyTrace[];
  error: any;
}

export const PropertyTraceStateDefault: PropertyTraceState = {
  error: null,
  propertiesTrace: [],
  propertyTrace: {} as PropertyTrace,
};

export const PropertyTraceReducer = (
  state: PropertyTraceState = PropertyTraceStateDefault,
  actions: PropertyTraceActionTypes
): PropertyTraceState => {
  switch (actions.type) {
    case LIST_PROPERTIES_TRACE:
      return {
        ...state,
        propertiesTrace: actions.propertiesTrace,
      };
    case ADD_PROPERTY_TRACE:
      return {
        ...state,
        propertyTrace: actions.propertyTrace,
      };
    case UPDATE_PROPERTY_TRACE:
      return {
        ...state,
        propertyTrace: actions.propertyTrace,
      };
    case DELETE_PROPERTY_TRACE:
      return {
        ...state,
        propertyTrace: actions.propertyTrace,
      };
    case GET_BY_ID_PROPERTY_TRACE:
      return {
        ...state,
        propertyTrace: actions.propertyTrace,
      };
    case ACTIONS_ERRORS:
      return {
        ...state,
        error: actions.error,
      };
    default:
      return state;
  }
};
