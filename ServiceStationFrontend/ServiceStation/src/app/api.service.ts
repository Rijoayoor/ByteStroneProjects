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
  changestatusexecutive(roleId:number){
    return this.Http.get<Executivestatuschange>(`http://localhost:5087/api/detailsstatus/${roleId}`)
  }
  updatestatus(roleId:number,customerId:number,e:Executivestatuschange){
    return this.Http.put(`http://localhost:5087/api/executive/${roleId}/customer/${customerId}`,e)

  }


  
  searchRequest(searchCriteria1:any,searchCriteria2:any,searchCriteria3:any,searchCriteria4:any,searchCriteria5:any,roleId:number){
     return this.Http.get(`http://localhost:5087/api/details/name/${searchCriteria1||null}/date/${searchCriteria2||null}/email/${searchCriteria3||null}/vehiclemodel/${searchCriteria4||null}/requirement/${searchCriteria5||null}/${roleId}`)
  }

  viewjobassign(roleId:number){
    return this.Http.get<Executivestatuschange>(`http://localhost:5087/api/detailsstatus/${roleId}`)
  }

  viewtechnician(){
    return this.Http.get(`http://localhost:5087/api/technician`)
  }
  updateTechnician(roleId:number,bookingId:number,assign:AssignJobs){
    return this.Http.put(`http://localhost:5087/api/executive/${roleId}/booking/${bookingId}`,assign)

  }
  viewbookingtechnician(roleId:number){
    return this.Http.get<Technicianbooking>(`http://localhost:5087/api/technician/${roleId}`)
  }

  changestatustechnician(roleId:number){
    return this.Http.get<Technicianstatuschange>(`http://localhost:5087/api/detailsstatustechnician/${roleId}`)
  }

  updatestatustechnician(roleId:number,customerId:number,e:Technicianstatuschange){
    return this.Http.put(`http://localhost:5087/api/technician/${roleId}/customer/${customerId}`,e)

  }


}
