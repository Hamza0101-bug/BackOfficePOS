import { Component, Input, OnInit } from '@angular/core';
import { IProductList } from 'src/app/shared/models/product';

@Component({
  selector: 'app-productcard',
  templateUrl: './productcard.component.html',
  styleUrls: ['./productcard.component.scss']
})
export class ProductcardComponent implements OnInit {
 @Input() product : IProductList;
  constructor() { }

  ngOnInit(): void {
  }
  addItemToBasket() {
    
  }

}
