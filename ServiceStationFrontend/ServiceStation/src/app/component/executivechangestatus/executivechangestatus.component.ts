import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { Customer } from 'src/app/model/customer';

@Component({
  selector: 'app-executivechangestatus',
  templateUrl: './executivechangestatus.component.html',
  styleUrls: ['./executivechangestatus.component.css']
})
export class ExecutivechangestatusComponent {
  name = ""
  data:any
  customerName!: string
  contactNumber!: string
  email!: string
  address!: string
  vehicleNumber!: string
  vehicleModel!: string
  serviceRequirements!: string

  constructor(private service: ApiService, private route: Router) { }
  editItem(){

  let customer: Customer = new Customer();

  customer.customerName = this.customerName,
    customer.contactNumber = this.contactNumber,
    customer.email = this.email,
    customer.address = this.address,
    customer.vehicleNumber = this.vehicleNumber,
    customer.vehicleModel = this.vehicleModel,
    customer.serviceRequirements = this.serviceRequirements
  console.log(customer)
  this.service.customerDetails(customer).subscribe(res => {
    this.data=res
    console.log(res)
    console.log(res.customerId);
    this.service.customerIdSetter(res.customerId);
    // localStorage.setItem("cid",res.customerId.toString())
    alert("Customer Details Added!")

  })
  this.route.navigateByUrl("/customer")
}

}


