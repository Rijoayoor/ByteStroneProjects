import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Customer } from 'src/app/model/customer';
import { Booking } from 'src/app/model/booking';
import { Bookingdetails } from 'src/app/model/bookingdetails';

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

  serviceId!:number
  bookingDate!:Date
  customerId!:number
  bookingId!:number
  bookingDateInput!:any
  
 
  constructor(private service: ApiService, private route: Router) { }

  submitForm(form: NgForm) {

    if (form.valid) {
      let customer: Customer = new Customer();
      let booking: Booking = new Booking();

      customer.customerName = this.customerName,
        customer.contactNumber = this.contactNumber,
        customer.email = this.email,
        customer.address = this.address,
        customer.vehicleNumber = this.vehicleNumber,
        customer.vehicleModel = this.vehicleModel,
        customer.serviceRequirements = this.serviceRequirements

        booking.serviceId=this.serviceId,
      booking.bookingDate=this.bookingDate,
      // booking.customerId=this.service.customerIdGetter()

      console.log(customer)
      this.service.customerDetails(customer).subscribe(res => {
        console.log(res)
        console.log(res.customerId);
        booking.customerId=res.customerId
        // this.service.customerIdSetter(res.customerId);

        console.log(booking);
        
        this.service.Bookingdetails(booking).subscribe((res:Bookingdetails) => {
          console.log(res)
          // alert("Booking Confirmed!")
       
          
        })
        // localStorage.setItem("cid",res.customerId.toString())
        alert("Customer Details Added!")
        this.route.navigateByUrl("/customer")

      })
      
    }
    else {
      alert("Please fill the required fields!")
    }
  }
}
