import { BaseEntity } from "./app/base-entity";

export interface Owner extends BaseEntity {
  name: string;
  address: string;
  photo: string;
  birthday: Date;
  image:any;
}
