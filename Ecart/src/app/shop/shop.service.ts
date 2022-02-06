import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { brandParams, IBrand, IBrandList } from '../shared/models/brand';
import { categoryParams, ICategory, ICategoryList } from '../shared/models/category';
import { IProduct, IProductList, productParams } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseurl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  // Product Services
  getProducts(searchPrams: productParams) {
   
    return this.http.post<IProduct>(this.baseurl +"Product/Product",searchPrams);
  }

  // Brands Services
  getBrands(searchPrams: brandParams) {
   
    return this.http.post<IBrand>(this.baseurl +"Brand/Brands",searchPrams);
  }

  getAllBrandss () {
    return this.http.get<IBrandList[]>(this.baseurl +"Brand/AllBrands");
  }

  // Categories Services

  getCategories (searchPrams: categoryParams) {
    return this.http.post<ICategory>(this.baseurl +"Category/Categories",searchPrams);
  }
  
  getAllCategories () {
    return this.http.get<ICategoryList[]>(this.baseurl +"Category/AllCategories");
  }

  getProductById(id:number) {
    return this.http.get<IProductList>(this.baseurl +"Product/"+id);
  }

}
