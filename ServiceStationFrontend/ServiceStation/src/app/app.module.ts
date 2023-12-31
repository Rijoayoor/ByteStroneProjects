import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustomerComponent } from './component/customer/customer.component';
import { ExecutiveComponent } from './component/executive/executive.component';
import { TechnicianComponent } from './component/technician/technician.component';
import { NavComponent } from './component/nav/nav.component';
import { CustomerhomeComponent } from './component/customerhome/customerhome.component';
import { CustomerbookingComponent } from './component/customerbooking/customerbooking.component';
import { ExecutiveviewbookingComponent } from './component/executiveviewbooking/executiveviewbooking.component';
import { ExecutivechangestatusComponent } from './component/executivechangestatus/executivechangestatus.component';
import { ExecutivesearchComponent } from './component/executivesearch/executivesearch.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { ExecutivejobassignComponent } from './component/executivejobassign/executivejobassign.component';
import { TechnicianviewjobComponent } from './component/technicianviewjob/technicianviewjob.component';
import { TechnicianstatusupdateComponent } from './component/technicianstatusupdate/technicianstatusupdate.component';
import { ExecutiveviewtechniciansComponent } from './component/executiveviewtechnicians/executiveviewtechnicians.component';
import { CustomerviewbookingComponent } from './component/customerviewbooking/customerviewbooking.component';

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
    ExecutivechangestatusComponent,
    ExecutivesearchComponent,
    ExecutivejobassignComponent,
    TechnicianviewjobComponent,
    TechnicianstatusupdateComponent,
    ExecutiveviewtechniciansComponent,
    CustomerviewbookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
