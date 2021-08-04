import { BaseEntity } from "./app/base-entity";

export interface PropertyImage extends BaseEntity{
    propertyId:string;
    file:string;
    enabled:boolean;
    width:number;
    height:number;
}