import { Dispatch } from "react";
import { Owner } from "../models/owner.model";
import { ApiRequest } from "../services/api-request.service";
import { AppActions } from "../typeactions/app.typeactions";
import {
  ACTIONS_ERRORS,
  ADD_OWNER,
  DELETE_OWNER,
  GET_BY_ID_OWNER,
  LIST_OWNER,
  UPDATE_OWNER,
} from "../typeactions/owner.typeactions";

const request = ApiRequest();
const get = "list-owners";
const post = "create-owner";
const deletes = "delete-owner/";
const update = "update-owner";
const getbyid = "getbyid-owner/";

export const ListOwner = (owners: Owner[]): AppActions => ({
  type: LIST_OWNER,
  owners,
});

export const UpdateOwner = (owner: Owner): AppActions => ({
  type: UPDATE_OWNER,
  owner,
});

export const DeleteOwner = (owner: Owner): AppActions => ({
  type: DELETE_OWNER,
  owner,
});

export const CreateOwner = (owner: Owner): AppActions => ({
  type: ADD_OWNER,
  owner,
});

export const GetByIdOwner = (owner: Owner): AppActions => ({
  type: GET_BY_ID_OWNER,
  owner,
});

export const ErrorOwner = (error: any): AppActions => ({
  type: ACTIONS_ERRORS,
  error,
});

export const ListOwnerAction = () => async (dispatch: Dispatch<AppActions>) => {
  const response = await request.Request.Get(get);
  if (response.isAxiosError) {
    dispatch(ErrorOwner(response));
  } else {
    dispatch(ListOwner(response.data.owners));
  }
};

export const CreateOwnerAction =
  (owner: Owner) => async (dispatch: Dispatch<AppActions>) => {
    const response = await request.Request.Post(post, owner);
    if (response.isAxiosError) {
      dispatch(ErrorOwner(response));
    } else {
      dispatch(ListOwner(response.data.ownerDto));
    }
  };

export const UpdateOwnerAction =
  (owner: Owner) => async (dispatch: Dispatch<AppActions>) => {
    const response = await request.Request.Put(update, owner);
    if (response.isAxiosError) {
      dispatch(ErrorOwner(response));
    } else {
      dispatch(ListOwner(response.data.ownerDto));
    }
  };

export const DeleteOwnerAction =
  (ownerId: string) => async (dispatch: Dispatch<AppActions>) => {
    const response = await request.Request.Delete(deletes + ownerId);
    if (response.isAxiosError) {
      dispatch(ErrorOwner(response));
    } else {
      dispatch(ListOwner(response.data.ownerDto));
    }
  };

export const GetByIdOwnerAction =
  (ownerId: string) => async (dispatch: Dispatch<AppActions>) => {
    const response = await request.Request.Get(getbyid + ownerId);
    if (response.isAxiosError) {
      dispatch(ErrorOwner(response));
    } else {
      dispatch(ListOwner(response.data.ownerDto));
    }
  };
