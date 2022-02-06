import {commonParams} from "./commonparams"

export interface IProduct {
    pageIndex: number;
    pageSize: number;
    count: number;
    records: IProductList[];
};

export interface IProductList{
    id: number;
    name: string;
    description: string;
    price: number;
    imageName: string;
    shortDescription: string;
    tags: string;
    active: boolean;
    itemCode: string;
    brandID: number;
    categoryID: number;
    branchID: number;
    category: string;
    brand: string;
    branch: string;
};

export class productParams extends commonParams{
    brandId? : number=null;
    categoryID? :number=null;
    branchID?:number =null;
    itemCode? :string;
}


