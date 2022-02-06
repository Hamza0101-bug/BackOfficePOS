import { commonParams } from "./commonparams";

export interface IBrand {
    pageIndex: number;
    pageSize: number;
    count: number;
    records: IBrandList[];
}

export interface IBrandList {
    id: number;
    name: string;
    description: string;
    shortDescription: string;
    brandImage: string;
    branchID: number;
    branch: string;
}

export class brandParams extends commonParams {
    branchID?:number;
}

