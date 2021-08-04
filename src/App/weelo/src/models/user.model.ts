import { BaseEntity } from "./app/base-entity";

export interface User extends BaseEntity {
  name: string;
  lastName: string;
  userName: string;
  password: string;
  modifiedBy:string;
  modifiedOn:Date;
}
