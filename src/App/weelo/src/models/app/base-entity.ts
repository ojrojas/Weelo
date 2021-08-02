export interface BaseEntity{
    id:string;
    createdBy:string;
    createOn:Date;
    modifiedBy:string;
    modifiedOn:Date;
    state:boolean;
}