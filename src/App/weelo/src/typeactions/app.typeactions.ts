import { LoginActionTypes } from "./login.typeactions";
import { OwnerActionsType } from "./owner.typeactions";
import { PropertyImageActionTypes } from "./property-image.typeactions";
import { PropertyTraceActionTypes } from "./property-trace.typeactions";
import { PropertyActionTypes } from "./property.typeactions";
import { UserActionTypes } from "./user.typeactions";

export type AppActions =
  | LoginActionTypes
  | UserActionTypes
  | PropertyActionTypes
  | PropertyImageActionTypes
  | PropertyTraceActionTypes
  | OwnerActionsType;
