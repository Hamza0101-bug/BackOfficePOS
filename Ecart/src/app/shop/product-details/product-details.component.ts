import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct, IProductList } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product : IProductList;
  quantity: number = 0;
  constructor(private shopServices: ShopService, private activeRoute: ActivatedRoute,
    private bcService: BreadcrumbService) {this.bcService.set('@productDetails', ' ') }

  ngOnInit() {
    this.getProduct();
  }

  getProduct() {
    this.shopServices.getProductById(+this.activeRoute.snapshot.paramMap.get('id')).subscribe((res)=> {
      this.product = res;
      this.bcService.set('@productDetails', res.name);

    });
  }
  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    };
  }

  addItemToBasket()
  {}

}
