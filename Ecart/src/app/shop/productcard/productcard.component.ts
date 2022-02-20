import { Component, Input, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { IProductList } from 'src/app/shared/models/product';

@Component({
  selector: 'app-productcard',
  templateUrl: './productcard.component.html',
  styleUrls: ['./productcard.component.scss']
})
export class ProductcardComponent implements OnInit {
 @Input() product : IProductList;
  constructor(private basketServices: BasketService) { }

  ngOnInit(): void {
  }

  addItemToBasket() {
    this.basketServices.addItemToBasket(this.product)
  }

}
