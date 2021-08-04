import { PropertyImage } from "../models/property-image.model";
import {
  ACTIONS_ERRORS,
  ADD_PROPERTY_IMAGE,
  DELETE_PROPERTY_IMAGE,
  GET_BY_ID_PROPERTY_IMAGE,
  LIST_PROPERTIES_IMAGE,
  PropertyImageActionTypes,
  UPDATE_PROPERTY_IMAGE,
} from "../typeactions/property-image.typeactions";

export interface PropertyImageState {
  propertyImage: PropertyImage;
  propertiesImage: PropertyImage[];
  error: any;
}

export const PropertyImageDefault: PropertyImageState = {
  error: null,
  propertiesImage: [],
  propertyImage: {} as PropertyImage,
};

export const PropertyImageReducer = (
  state: PropertyImageState = PropertyImageDefault,
  actions: PropertyImageActionTypes
): PropertyImageState => {
  switch (actions.type) {
    case LIST_PROPERTIES_IMAGE:
      return {
        ...state,
        propertiesImage: actions.propertiesImage,
      };
    case ADD_PROPERTY_IMAGE:
      return {
        ...state,
        propertyImage: actions.propertyImage,
      };
    case UPDATE_PROPERTY_IMAGE:
      return {
        ...state,
        propertyImage: actions.propertyImage,
      };
    case DELETE_PROPERTY_IMAGE:
      return {
        ...state,
        propertyImage: actions.propertyImage,
      };
    case GET_BY_ID_PROPERTY_IMAGE:
      return {
        ...state,
        propertyImage: actions.propertyImage,
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
