import { Owner } from "../models/owner.model";
import {
  ACTIONS_ERRORS,
  ADD_OWNER,
  DELETE_OWNER,
  GET_BY_ID_OWNER,
  LIST_OWNER,
  OwnerActionsType,
  UPDATE_OWNER,
} from "../typeactions/owner.typeactions";

export interface OwnerState {
  owner: Owner;
  owners: Owner[];
  error: any;
}

export const OwnerStateDefault: OwnerState = {
  error: null,
  owner: {} as Owner,
  owners: [],
};

export const OwnerReducer = (
  state: OwnerState = OwnerStateDefault,
  actions: OwnerActionsType
): OwnerState => {
  switch (actions.type) {
    case ADD_OWNER:
      return {
        ...state,
        owner: actions.owner,
      };
    case UPDATE_OWNER:
      return {
        ...state,
        owner: actions.owner,
      };
    case DELETE_OWNER:
      return {
        ...state,
        owner: actions.owner,
      };

    case GET_BY_ID_OWNER:
      return {
        ...state,
        owner: actions.owner,
      };
    case LIST_OWNER:
      return {
        ...state,
        owners: actions.owners,
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
