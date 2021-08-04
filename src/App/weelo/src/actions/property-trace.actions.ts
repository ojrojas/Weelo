import { Dispatch } from "react";
import { PropertyTrace } from "../models/property-trace.model";
import { ApiRequest } from "../services/api-request.service";
import { AppActions } from "../typeactions/app.typeactions";
import {
  ACTIONS_ERRORS,
  ADD_PROPERTY_TRACE,
  DELETE_PROPERTY_TRACE,
  GET_BY_ID_PROPERTY_TRACE,
  LIST_PROPERTIES_TRACE,
  UPDATE_PROPERTY_TRACE,
} from "../typeactions/property-trace.typeactions";

const request = ApiRequest();

const getPropertyTraceUrl = "list-propertytrace";
const postPropertyTraceUrl = "create-propertytrace";
const putPropertyTraceUrl = "create-propertytrace";
const deletePropertyTraceUrl = "delete-propertytrace/";
const getByIdPropertyTraceUrl = "getbyid-propertytrace/";

export const ListPropertyTrace = (
  propertiesTrace: PropertyTrace[]
): AppActions => ({
  type: LIST_PROPERTIES_TRACE,
  propertiesTrace,
});

export const CreatePropertyTrace = (
  propertyTrace: PropertyTrace
): AppActions => ({
  type: ADD_PROPERTY_TRACE,
  propertyTrace,
});

export const UpdatePropertyTrace = (
  propertyTrace: PropertyTrace
): AppActions => ({
  type: UPDATE_PROPERTY_TRACE,
  propertyTrace,
});

export const DeletePropertyTrace = (
  propertyTrace: PropertyTrace
): AppActions => ({
  type: DELETE_PROPERTY_TRACE,
  propertyTrace,
});

export const GetByIdPropertyTrace = (
  propertyTrace: PropertyTrace
): AppActions => ({
  type: GET_BY_ID_PROPERTY_TRACE,
  propertyTrace,
});

export const ErrorPropertyTrace = (error: any): AppActions => ({
  type: ACTIONS_ERRORS,
  error,
});

export const ListPropertyTraceAction =
  () => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Request.Get(getPropertyTraceUrl);
    if (response.isAxiosError) {
      dispatch(ErrorPropertyTrace(response));
    } else {
      dispatch(ListPropertyTrace(response.data.properties));
    }
  };

export const CreatePropertyTraceAction =
  (propertyTrace: PropertyTrace) => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Request.Post(
      postPropertyTraceUrl,
      propertyTrace
    );
    if (response.isAxiosError) {
      dispatch(ErrorPropertyTrace(response));
    } else {
      dispatch(CreatePropertyTrace(response.data.propertyTraceDto));
    }
  };

export const UpdatePropertyTraceAction =
  (propertyTrace: PropertyTrace) => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Request.Post(
      putPropertyTraceUrl,
      propertyTrace
    );
    if (response.isAxiosError) {
      dispatch(ErrorPropertyTrace(response));
    } else {
      dispatch(UpdatePropertyTrace(response.data.propertyTraceDto));
    }
  };

export const DeletePropertyTraceAction =
  (propertyTraceId: string) => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Request.Delete(
      deletePropertyTraceUrl + propertyTraceId
    );
    if (response.isAxiosError) {
      dispatch(ErrorPropertyTrace(response));
    } else {
      dispatch(DeletePropertyTrace(response.data.propertyTraceDto));
    }
  };

export const GetByIdPropertyTraceAction =
  (propertyTraceId: string) => async (dispatch: Dispatch<AppActions>) => {
    var response = await request.Request.Get(
      getByIdPropertyTraceUrl + propertyTraceId
    );
    if (response.isAxiosError) {
      dispatch(ErrorPropertyTrace(response));
    } else {
      dispatch(GetByIdPropertyTrace(response.data.propertyTraceDto));
    }
  };
