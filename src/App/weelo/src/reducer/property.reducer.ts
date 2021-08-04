import { Property } from "../models/property.model";
import {
  ADD_PROPERTY,
  DELETE_PROPERTY,
  ERROR_ACTIONS,
  GET_BY_ID_PROPERTY,
  LOAD_PROPERTIES,
  PropertyActionTypes,
  UPDATE_PROPERTY,
} from "../typeactions/property.typeactions";

export interface PropertyState {
  property: Property;
  properties: Property[];
  error: any;
}

export const PropertyDefault: PropertyState = {
  error: null,
  property: {} as Property,
  properties: [],
};

export const PropertyReducer = (
  state: PropertyState = PropertyDefault,
  action: PropertyActionTypes
): PropertyState => {
  switch (action.type) {
    case ADD_PROPERTY:
      return {
        ...state,
        property: action.property,
      };
    case LOAD_PROPERTIES:
      return {
        ...state,
        properties: action.properties,
      };
    case UPDATE_PROPERTY:
      return {
        ...state,
        property: action.property,
      };
    case DELETE_PROPERTY:
      return {
        ...state,
        property: action.property,
      };
    case GET_BY_ID_PROPERTY:
      return {
        ...state,
        property: action.property,
      };
    case ERROR_ACTIONS:
      return {
        ...state,
        error: action.error,
      };
    default:
      return state;
  }
};
