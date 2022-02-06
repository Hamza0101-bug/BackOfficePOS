import { HttpClient } from '@angular/common/http';
import { NULL_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { brandParams, IBrandList } from '../shared/models/brand';
import { categoryParams, ICategoryList } from '../shared/models/category';
import { IProductList, productParams } from '../shared/models/product';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild("search") searchval: ElementRef;
  title = 'Ecart';
  productList: IProductList[];
  brandList: IBrandList[];
  categroyList: ICategoryList[];
  brandId: number = null;
  categoryID: number = null;
  sortSelected: string = "";
  productSearchParams = new productParams();
  totalCount: number = 0;
  sortOptionList = [
    { option: "Alphabatical A to Z ", value: "name" },
    { option: "Price Low to High", value: "priceAsc" },
    { option: "Price High to Low", value: "priceDesc" },

  ]
  constructor(private shopServices: ShopService) { }

  ngOnInit() {
    this.getProducts();
    this.getAllBrands();
    this.getAllCategories();
  }

  onReset() {
    this.searchval.nativeElement.value = "";
    this.productSearchParams.pageIndex = 1;
    this.productSearchParams = new productParams();
    this.getProducts();
  }

  productSearch() {
    this.productSearchParams.search = this.searchval.nativeElement.value;
    this.getProducts();
  }

  getProducts() {
    this.shopServices.getProducts(this.productSearchParams).subscribe((res) => {
      if (res) {
        this.productList = res.records;
        this.productSearchParams.pageIndex = res.pageIndex;
        this.productSearchParams.pageSize = res.pageSize;
        this.totalCount = res.count;
      }
    });
  }

  getBrands() {
    const searchparams: brandParams = {
      pageIndex: 1,
      pageSize: 25,
      sort: "",
      search: "",
      active: true,
      allRecord: true,
      branchID: null,
    };

    this.shopServices.getBrands(searchparams).subscribe((res) => {
      if (res) {
        this.brandList = res.records;
      }
    });
  }

  getAllBrands() {
    this.shopServices.getAllBrandss().subscribe((res) => {
      if (res) {
        this.brandList = res;
      }});
  }

  getAllCategories() {
    this.shopServices.getAllCategories().subscribe((res) => {
      if (res) {
        this.categroyList = res;
      }
    });
  }

  getCategories() {
    const searchparams: categoryParams = {
      pageIndex: 1,
      pageSize: 25,
      sort: "",
      search: "",
      active: true,
      allRecord: true,
      branchID: null,
    };
    
    this.shopServices.getCategories(searchparams).subscribe((res) => {
      if (res) {
        this.categroyList = res.records;
      }
    });

  }

  onSelectSort(sort: string) {
    this.productSearchParams.sort = sort;
    this.getProducts();
  }

  onPageChange(event: any) {
    if (this.productSearchParams.pageIndex != event) {
      this.productSearchParams.pageIndex = event;
      this.getProducts();
    }
  }

  
}
