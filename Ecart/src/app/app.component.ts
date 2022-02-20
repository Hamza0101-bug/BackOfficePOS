import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Ecart';

  constructor(private basketServices: BasketService) {}

  ngOnInit() { 
    const basketId = localStorage.getItem('basket_id');
    if(basketId) {
      this.basketServices.getBasket(basketId).subscribe(()=>{
        console.log("res");
      }) }
  }
}
