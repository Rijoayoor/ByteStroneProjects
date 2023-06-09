import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Customer } from 'src/app/model/customer';

@Component({
  selector: 'app-customerhome',
  templateUrl: './customerhome.component.html',
  styleUrls: ['./customerhome.component.css']
})
export class CustomerhomeComponent {
  name = ""
  customerName!: string
  contactNumber!: string
  email!: string
  address!: string
  vehicleNumber!: string
  vehicleModel!: string
  serviceRequirements!: string
  constructor(private service: ApiService, private route: Router) { }

  


  submitForm(form: NgForm) {
    if (form.valid) {
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
        console.log(res)
      })
    };
   
    this.route.navigateByUrl("/customer")
    
  }
  


}
