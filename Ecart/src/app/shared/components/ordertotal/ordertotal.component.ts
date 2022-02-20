import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket, IBasketTotals } from '../../models/basket';

@Component({
  selector: 'app-ordertotal',
  templateUrl: './ordertotal.component.html',
  styleUrls: ['./ordertotal.component.scss']
})
export class OrdertotalComponent implements OnInit {
  @Input() shippingPrice: number;
  @Input() subtotal: number;
  @Input() total: number;
  basket$: Observable<IBasket>;
  basketTotal$: Observable<IBasketTotals>;
  constructor(private basketServices: BasketService) { }

  ngOnInit(): void {
    this.basketTotal$ = this.basketServices.basketTotal$;
  }

}
