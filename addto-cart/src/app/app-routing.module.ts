import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from'./componnents/products/products.component';
import {CartComponent} from'./componnents/cart/cart.component';
import {LogingComponent} from './componnents/loging/loging.component';
import {RegisterComponent} from './componnents/register/register.component';
import { AdminDashboardComponent } from './componnents/admin-dashboard/admin-dashboard.component';
import { PaymentComponent } from './componnents/payment/payment.component';

const routes: Routes = [
  {path:'', redirectTo:'products', pathMatch:'full'},
  {path:'products', component:ProductsComponent},
  {path: 'cart',  component:CartComponent},
  {path: 'loging',  component:LogingComponent},
  {path: 'register',  component:RegisterComponent},
  {path: 'admin-dashboard', component:AdminDashboardComponent},
  {path: 'payment' , component:PaymentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
