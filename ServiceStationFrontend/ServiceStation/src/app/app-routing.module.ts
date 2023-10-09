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
import { CustomerviewbookingComponent } from './component/customerviewbooking/customerviewbooking.component';
import { authguardNewGuard } from './guard/authguard-new.guard';

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "customer", component: CustomerComponent, canActivate: [authguardNewGuard]},
  { path: "executive", component: ExecutiveComponent, canActivate: [authguardNewGuard] },
  { path: "technician", component: TechnicianComponent, canActivate: [authguardNewGuard] },
  { path: "", component: LoginComponent },
  { path: "**", component: LoginComponent, canActivate: [authguardNewGuard]  },
  { path: "customerhome", component: CustomerhomeComponent, canActivate: [authguardNewGuard] },
  { path: "customerbooking", component: CustomerbookingComponent , canActivate: [authguardNewGuard]},
  { path: "executiveviewbooking", component: ExecutiveviewbookingComponent , canActivate: [authguardNewGuard] },
  { path: "executivechangestatus", component: ExecutivechangestatusComponent, canActivate: [authguardNewGuard] },
  { path: "executivesearch", component: ExecutivesearchComponent, canActivate: [authguardNewGuard] },
  {path:"customerviewbooking",component:CustomerviewbookingComponent,canActivate:[authguardNewGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
