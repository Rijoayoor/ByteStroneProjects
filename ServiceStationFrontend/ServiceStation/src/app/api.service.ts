import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { CustomerDetails } from './model/customer-details';
import { Customer } from './model/customer';

@Injectable({
  providedIn: 'root'
})
export class ApiService {


  name = ""
  role = ""

  constructor(private Http: HttpClient) { }

  login(Username: string, Password: string, Userrole: string) {
    return this.Http.post(" http://localhost:5087/api/login", { Username, Password, Userrole })
  }
  nameSetter(name: string) {
    this.name = name
  }
  nameGetter() {
    return this.name
  }
  roleSetter(role: string) {
    this.role = role
  }
  roleGetter() {
    return this.role
  }

  customerDetails(customerDetails:Customer){
    return this.Http.post<CustomerDetails>("http://localhost:5087/api/customer",customerDetails)

  }

}
