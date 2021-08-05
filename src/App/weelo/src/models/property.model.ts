import { BaseEntity } from "./app/base-entity";
import { PropertyImage } from "./property-image.model";
import { PropertyTrace } from "./property-trace.model";

export interface Property extends BaseEntity {
  name: string;
  address: string;
  price: number;
  codeInternal: number;
  year: number;
  ownerId: string;
  calification: number;
  rating: number;
  propertyImage: PropertyImage;
  propertyTrace: PropertyTrace;
  PropertyImageId: string;
  PropertyTraceId: string;
}

