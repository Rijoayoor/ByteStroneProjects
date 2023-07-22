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
import { AuthGuard } from './guard/auth.guard';

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "customer", component: CustomerComponent, canActivate: [AuthGuard]},
  { path: "executive", component: ExecutiveComponent, canActivate: [AuthGuard] },
  { path: "technician", component: TechnicianComponent, canActivate: [AuthGuard] },
  { path: "", component: LoginComponent },
  { path: "customerhome", component: CustomerhomeComponent, canActivate: [AuthGuard] },
  { path: "customerbooking", component: CustomerbookingComponent , canActivate: [AuthGuard]},
  { path: "executiveviewbooking", component: ExecutiveviewbookingComponent , canActivate: [AuthGuard] },
  { path: "executivechangestatus", component: ExecutivechangestatusComponent, canActivate: [AuthGuard] },
  { path: "executivesearch", component: ExecutivesearchComponent, canActivate: [AuthGuard] }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
