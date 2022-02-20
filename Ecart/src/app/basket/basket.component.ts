import { Component, OnInit } from '@angular/core';
import { Observable, observable } from 'rxjs';
import { IBasket, IBasketItem, IBasketTotals } from '../shared/models/basket';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
  basket$: Observable<IBasket>;
  basketTotals$: Observable<IBasketTotals>;
  constructor(private basketServices: BasketService) { }

  ngOnInit(): void {
    this.basket$ = this.basketServices.basket$;
    this.basketTotals$ = this.basketServices.basketTotal$;
  }
  removeBasketItem(item: IBasketItem) {
    this.basketServices.removeItemFromBasket(item);
  }

  incrementItemQuantity(item: IBasketItem) {
    this.basketServices.incrementItemQuantity(item);
  }
  
  decrementItemQuantity(item: IBasketItem) {
    this.basketServices.decrementItemQuantity(item);
  }
}
