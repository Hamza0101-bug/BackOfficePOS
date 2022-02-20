import {  CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PaginationHeaderComponent } from './components/pagination-header/pagination-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { OrdertotalComponent } from './components/ordertotal/ordertotal.component';

@NgModule({
  declarations: [
  
    PaginationHeaderComponent,
       PagerComponent,
       OrdertotalComponent
  ],
  
  imports: [
    CommonModule,
    CarouselModule.forRoot(),
    PaginationModule.forRoot()
  ],
  exports: [
    PaginationModule,
    PaginationHeaderComponent,
    PagerComponent,
    CarouselModule,
    OrdertotalComponent

  ],
  schemas: [NO_ERRORS_SCHEMA]


})
export class SharedModule { }