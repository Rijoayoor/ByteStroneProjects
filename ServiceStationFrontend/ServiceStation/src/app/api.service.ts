import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { CustomerDetails } from './model/customer-details';
import { Customer } from './model/customer';
import { Booking } from './model/booking';
import { Bookingdetails } from './model/bookingdetails';
import { Executivebooking } from './model/executivebooking';

@Injectable({
  providedIn: 'root'
})
export class ApiService {


  name = ""
  role = ""
  customerId!:number
  roleId!:number

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
  Bookingdetails(Bookingdetails:Booking){
    return this.Http.post<Bookingdetails>("http://localhost:5087/api/booking",Bookingdetails)


  }
  customerIdSetter(id:number){
    this.customerId=id
  }
  customerIdGetter(){
    return this.customerId
  }
  roleIdSetter(roleId:number)
  {
    this.roleId=roleId
  }
  roleIdGetter(){
    return this.roleId
  }

  viewbookingexecutive(roleId:number){
    return this.Http.get<Executivebooking>(`http://localhost:5087/api/executive/${roleId}`)
  }



}
