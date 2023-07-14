import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Customer } from 'src/app/model/customer';
import { Booking } from 'src/app/model/booking';
import { Bookingdetails } from 'src/app/model/bookingdetails';

@Component({
  selector: 'app-customerbooking',
  templateUrl: './customerbooking.component.html',
  styleUrls: ['./customerbooking.component.css']
})
export class CustomerbookingComponent {
  name=""
  serviceId!:number
  bookingDate!:Date
  customerId!:number
  bookingId!:number
  bookingDateInput!:any

  result:Bookingdetails=new Bookingdetails();

details:any
// customerId: number|any
  constructor(private service: ApiService, private route: Router) { }
  ngOnInit() {

  //  const storedCustomerId = localStorage.getItem('customerId')
  // this.customerId = storedCustomerId ? parseInt(storedCustomerId, 10) : 0;
}



  submitForm(form: NgForm) {
    if (form.valid) {
      let booking: Booking = new Booking();

      booking.serviceId=this.serviceId,
      booking.bookingDate=this.bookingDate,
      booking.customerId=this.service.customerIdGetter()

     
      console.log(booking)
      this.service.Bookingdetails(booking).subscribe((res:Bookingdetails) => {
        console.log(res)
        alert("Booking Confirmed!")
     
        
      })
    };
   
    this.route.navigateByUrl("/customer")
    
  }

}
