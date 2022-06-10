import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeadersComponent } from './componnents/headers/headers.component';
 import { ProductsComponent } from './componnents/products/products.component';
import { CartComponent } from './componnents/cart/cart.component';
import { FooterComponent } from './componnents/footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { LogingComponent } from './componnents/loging/loging.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './componnents/register/register.component';
import { AuthApiService } from './services/auth-api.service';
import { SidenavComponent } from './componnents/sidenav/sidenav.component';
import { AdminDashboardComponent } from './componnents/admin-dashboard/admin-dashboard.component';
import { PaymentComponent } from './componnents/payment/payment.component';
import { GooglePayButtonModule } from '@google-pay/button-angular';

@NgModule({
  declarations: [
    AppComponent,
    HeadersComponent,
     ProductsComponent,
    CartComponent,
    FooterComponent,
    LogingComponent,
    RegisterComponent,
    SidenavComponent,
    AdminDashboardComponent,
    PaymentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    GooglePayButtonModule

  ],
  providers: [
    AuthApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
