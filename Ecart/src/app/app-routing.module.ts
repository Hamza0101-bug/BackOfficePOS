import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TesterrorComponent } from './core/testerror/testerror.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path:'', component: HomeComponent, data:{breadcrumb: "Home"}},
  {path:'TestError', component: TesterrorComponent, data:{breadcrumb: "TestError"}},
  {path:'notfound', component: NotFoundComponent, data:{breadcrumb: "notfound"}},
  {path:'servererror', component: ServerErrorComponent, data:{breadcrumb: "servererror"}},
  {path:'shop', loadChildren: ()=> import('./shop/shop.module').then(mod => mod.ShopModule),
  data:{breadcrumb: "shop"}},
  {path:'basket', loadChildren: ()=> import('./basket/basket.module').then(mod => mod.BasketModule),
  data:{breadcrumb: "basket"}},
  {path:'checkout', loadChildren: ()=> import('./checkout/checkout.module').then(mod => mod.CheckoutModule),
  data:{breadcrumb: "Checkout"}},
  {path:'**', redirectTo:'notfound', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
