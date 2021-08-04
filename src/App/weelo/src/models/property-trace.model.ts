import { BaseEntity } from "./app/base-entity";

export interface PropertyTrace extends BaseEntity {
  propertyId: string;
  dateSale: Date;
  name: string;
  value: number;
  tax: number;
}
