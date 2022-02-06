import {commonParams} from "./commonparams"


export interface ICategory {
    pageIndex: number;
    pageSize: number;
    count: number;
    records: ICategoryList[];
}

export interface ICategoryList {
    id: number;
    name: string;
    categoryImage: string;
    description: string;
    shortDescription: string;
    parantID: number;
    branchID: number;
    branch: string;
    active: boolean;
}


export class categoryParams extends commonParams {
    branchID?:number;
}