import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { CustomerComponent } from './component/customer/customer.component';
import { ExecutiveComponent } from './component/executive/executive.component';
import { TechnicianComponent } from './component/technician/technician.component';
import { NavComponent } from './component/nav/nav.component';
import { CustomerhomeComponent } from './component/customerhome/customerhome.component';
import { CustomerbookingComponent } from './component/customerbooking/customerbooking.component';
import { ExecutiveviewbookingComponent } from './component/executiveviewbooking/executiveviewbooking.component';
import { ExecutivechangestatusComponent } from './component/executivechangestatus/executivechangestatus.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CustomerComponent,
    ExecutiveComponent,
    TechnicianComponent,
    NavComponent,
    CustomerhomeComponent,
    CustomerbookingComponent,
    ExecutiveviewbookingComponent,
    ExecutivechangestatusComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
