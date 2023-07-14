import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './component/customer/customer.component';
import { LoginComponent } from './login/login.component';
import { ExecutiveComponent } from './component/executive/executive.component';
import { TechnicianComponent } from './component/technician/technician.component';
import { CustomerhomeComponent } from './component/customerhome/customerhome.component';
import { CustomerbookingComponent } from './component/customerbooking/customerbooking.component';
import { ExecutiveviewbookingComponent } from './component/executiveviewbooking/executiveviewbooking.component';
import { ExecutivechangestatusComponent } from './component/executivechangestatus/executivechangestatus.component';
import { ExecutivesearchComponent } from './component/executivesearch/executivesearch.component';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"customer",component:CustomerComponent},
  {path:"executive",component:ExecutiveComponent},
  {path:"technician",component:TechnicianComponent},
  {path:"",component:LoginComponent},
  {path:"customerhome",component:CustomerhomeComponent},
  {path:"customerbooking",component:CustomerbookingComponent},
  {path:"executiveviewbooking",component:ExecutiveviewbookingComponent},
  {path:"executivechangestatus",component:ExecutivechangestatusComponent},
  {path:"executivesearch",component:ExecutivesearchComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
