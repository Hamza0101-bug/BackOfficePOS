import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavBarsComponent } from './core/nav-bars/nav-bars.component';
import { CoreModule } from './core/core.module';
import { ShopModule } from './shop/shop.module';
import { SharedModule } from './shared/shared.module';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { toUnicode } from 'punycode';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './core/interceptors/loading.interceptor';
import { CarouselModule } from 'ngx-bootstrap/carousel';

@NgModule({
  declarations: [
    AppComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    SharedModule,
    NgxSpinnerModule,
    CarouselModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS , useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS , useClass: LoadingInterceptor, multi: true}
  
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
