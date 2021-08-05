import { Dispatch } from "react";
import { PropertyImage } from "../models/property-image.model";
import { ApiRequest } from "../services/api-request.service";
import { AppActions } from "../typeactions/app.typeactions";
import {
  ACTIONS_ERRORS,
  ADD_PROPERTY_IMAGE,
  DELETE_PROPERTY_IMAGE,
  GET_BY_ID_PROPERTY_IMAGE,
  LIST_PROPERTIES_IMAGE,
  UPDATE_PROPERTY_IMAGE,
} from "../typeactions/property-image.typeactions";

const request = new ApiRequest();

const getPropertyImageUrl = "list-propertyimage";
const postPropertyImageUrl = "create-propertyimage";
const putPropertyImageUrl = "update-propertyimage";
const deletePropertyImageUrl = "delete-propertyimage/";
const getByIdPropertyImageUrl = "getbyid-propertyimage/";

export const ListPropertyImage = (
  propertiesImage: PropertyImage[]
): AppActions => ({
  type: LIST_PROPERTIES_IMAGE,
  propertiesImage,
});

export const CreatePropertyImage = (
  propertyImage: PropertyImage
): AppActions => ({
  type: ADD_PROPERTY_IMAGE,
  propertyImage,
});

export const UpdatePropertyImage = (
  propertyImage: PropertyImage
): AppActions => ({
  type: UPDATE_PROPERTY_IMAGE,
  propertyImage,
});

export const DeletePropertyImage = (
  propertyImage: PropertyImage
): AppActions => ({
  type: DELETE_PROPERTY_IMAGE,
  propertyImage,
});

export const GetByIdPropertyImage = (
  propertyImage: PropertyImage
): AppActions => ({
  type: GET_BY_ID_PROPERTY_IMAGE,
  propertyImage,
});

export const ErrorPropertyImage = (error: any): AppActions => ({
  type: ACTIONS_ERRORS,
  error,
});

export const ListPropertyImageAction =
  () => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Get(getPropertyImageUrl);
    if (response.isAxiosError) {
      dispatch(ErrorPropertyImage(response));
    } else {
      dispatch(ListPropertyImage(response.data.propertyImageDto));
    }
  };

export const CreatePropertyImageAction =
  (propertyImage: PropertyImage) => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Post(
      postPropertyImageUrl,
      propertyImage
    );
    if (response.isAxiosError) {
      dispatch(ErrorPropertyImage(response));
    } else {
      dispatch(ListPropertyImage(response.data.propertyImageDto));
    }
  };

export const UpdatePropertyImageAction =
  (propertyImage: PropertyImage) => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Put(
      putPropertyImageUrl,
      propertyImage
    );
    if (response.isAxiosError) {
      dispatch(ErrorPropertyImage(response));
    } else {
      dispatch(ListPropertyImage(response.data.propertyImageDto));
    }
  };

export const DeletePropertyImageAction =
  (propertyImageId: string) => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Delete(
      deletePropertyImageUrl + propertyImageId);
    if (response.isAxiosError) {
      dispatch(ErrorPropertyImage(response));
    } else {
      dispatch(DeletePropertyImage(response.data.propertyImageDto));
    }
  };

export const GetByIdPropertyImageAction =
  (propertyImageId: string) => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Get(
        getByIdPropertyImageUrl + propertyImageId
    );
    if (response.isAxiosError) {
      dispatch(ErrorPropertyImage(response));
    } else {
      dispatch(DeletePropertyImage(response.data.propertyImageDto));
    }
  };
