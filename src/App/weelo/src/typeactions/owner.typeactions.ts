import { Owner } from "../models/owner.model";

export const ADD_OWNER = "ADD_OWNER";
export const LIST_OWNER = "LIST_OWNER";
export const UPDATE_OWNER = "UPDATE_OWNER";
export const DELETE_OWNER = "DELETE_OWNER";
export const GET_BY_ID_OWNER = "GET_BY_ID_OWNER";
export const ACTIONS_ERRORS = "ACTIONS_ERRORS";

export interface AddOwner {
  type: typeof ADD_OWNER;
  owner: Owner;
}

export interface UpdateOwner {
  type: typeof UPDATE_OWNER;
  owner: Owner;
}

export interface DeleteOwner {
  type: typeof DELETE_OWNER;
  owner: Owner;
}

export interface GetByIdOwner {
  type: typeof GET_BY_ID_OWNER;
  owner: Owner;
}

export interface ListOwner {
  type: typeof LIST_OWNER;
  owners: Owner[];
}

export interface OwnerError {
  type: typeof ACTIONS_ERRORS;
  error: any;
}

export type OwnerActionsType =
  | AddOwner
  | UpdateOwner
  | DeleteOwner
  | GetByIdOwner
  | ListOwner
  | OwnerError;
