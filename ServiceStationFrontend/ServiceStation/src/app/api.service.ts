import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { CustomerDetails } from './model/customer-details';
import { Customer } from './model/customer';
import { Booking } from './model/booking';
import { Bookingdetails } from './model/bookingdetails';
import { Executivebooking } from './model/executivebooking';
import { Executivestatuschange } from './model/executivestatuschange';
import { AssignJobs } from './model/assignjob';
import { Technicianbooking } from './model/technicianbooking';
import { Technicianstatuschange } from './model/technicianstatuschange';
import { Customerviewbooking } from './model/customerviewbooking';
import { Customerupdatedetails } from './model/customerupdatedetails';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  name = ""
  role = ""
  customerId!: number
  roleId!: number
  constructor(private Http: HttpClient) { }
  login(Username: string, Password: string, Userrole: string) {
    return this.Http.post(" http://localhost:5087/api/login", { Username, Password, Userrole })
  }
  nameSetter(name: string) {
    localStorage.setItem("name", name);
  }
  nameGetter() {
    this.name = localStorage.getItem("name") || " ";
    return this.name
  }
  roleSetter(role: string) {
    localStorage.setItem("role", role);
  }
  roleGetter() {
    this.role = localStorage.getItem("role") || " ";
    return this.role
  }
  customerDetails(customerDetails: Customer) {
    return this.Http.post<CustomerDetails>("http://localhost:5087/api/customer", customerDetails)
  }
  Bookingdetails(Bookingdetails: Booking) {
    return this.Http.post<Bookingdetails>("http://localhost:5087/api/booking", Bookingdetails)
  }
  customerIdSetter(id: number) {
    this.customerId = id
  }
  customerIdGetter() {
    return this.customerId
  }
  roleIdSetter(roleId: number) {
    localStorage.setItem("roleId", JSON.stringify(roleId));
    this.roleId = roleId
  }
  roleIdGetter() {
    this.roleId = JSON.parse(localStorage.getItem("roleId") as "4")
    return this.roleId
  }
  viewbookingexecutive(roleId: any) {
    return this.Http.get<Executivebooking>(`http://localhost:5087/api/executive/${this.roleId}`)
  }
  changestatusexecutive(roleId: number) {
    return this.Http.get<Executivestatuschange>(`http://localhost:5087/api/detailsstatus/${roleId}`)
  }
  updatestatus(roleId: number, customerId: number, e: Executivestatuschange) {
    return this.Http.put(`http://localhost:5087/api/executive/${roleId}/bookings/${customerId}`, e)
  }
  searchRequest(searchCriteria1: any, searchCriteria2: any, searchCriteria3: any, searchCriteria4: any, searchCriteria5: any, roleId: number) {
    return this.Http.get(`http://localhost:5087/api/details/name/${searchCriteria1 || null}/date/${searchCriteria2 || null}/email/${searchCriteria3 || null}/vehiclemodel/${searchCriteria4 || null}/requirement/${searchCriteria5 || null}/${roleId}`)
  }
  viewjobassign(roleId: number) {
    return this.Http.get<Executivestatuschange>(`http://localhost:5087/api/detailsstatus/${roleId}`)
  }
  viewtechnician() {
    return this.Http.get(`http://localhost:5087/api/technician`)
  }
  updateTechnician(roleId: number, bookingId: number, assign: AssignJobs) {
    return this.Http.put(`http://localhost:5087/api/executive/${roleId}/booking/${bookingId}`, assign)
  }
  updateRequirement(roleId: number, customerId: number, assign: AssignJobs) {
    return this.Http.put(`http://localhost:5087/api/customer/${customerId}`, assign)
  }
  viewbookingtechnician(roleId: any) {
    return this.Http.get<Technicianbooking>(`http://localhost:5087/api/technician/${this.roleId}`)
  }
  changestatustechnician(roleId: number) {
    return this.Http.get<Technicianstatuschange>(`http://localhost:5087/api/detailsstatustechnician/${roleId}`)
  }
  // updatestatustechnician(roleId: number, customerId: number, e: Technicianstatuschange) {
  //   return this.Http.put(`http://localhost:5087/api/technician/${roleId}/customer/${customerId}`, e)
  // }

  updatestatustechnician(technicianId: number, bookingId: number, e: Technicianstatuschange) {
    return this.Http.put(`http://localhost:5087/api/technician/${technicianId}/booking/${bookingId}`, e)
  }
  Executiveviewtechnician() {
    return this.Http.get(`http://localhost:5087/api/technician`)
  }
  IsLoggedIn() {
    return sessionStorage.getItem("username") != null
  }
  viewbookingcustomer(roleId: any) {
    return this.Http.get<Customerviewbooking>(`http://localhost:5087/api/customers/${this.roleId}`)
  }
  updateCustomer(roleId: any, c: Customer) {
    return this.Http.put(`http://localhost:5087/api/customer/${this.roleId}`, c)
  }
  CustomerViewBooking() {
    return this.Http.get(`http://localhost:5087/api/bookings`)
  }
}
