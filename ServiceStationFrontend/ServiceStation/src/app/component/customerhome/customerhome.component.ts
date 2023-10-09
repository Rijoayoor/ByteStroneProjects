import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Router } from '@angular/router';
import { FormGroup, NgForm, Validators } from '@angular/forms';
import { Customer } from 'src/app/model/customer';
import { Booking } from 'src/app/model/booking';
import { Bookingdetails } from 'src/app/model/bookingdetails';
import { FormControl } from '@angular/forms';
import { Customerupdatedetails } from 'src/app/model/customerupdatedetails';

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
  serviceId!: number
  bookingDate!: Date
  // customerId!: number
  bookingId!: number
  bookingDateInput!: any
  data: any
  customerId = this.service.roleIdGetter()
  customerDetails: FormGroup;


  constructor(private service: ApiService, private route: Router) {
    this.customerDetails = new FormGroup({
      customerName: new FormControl('', [Validators.required]),
      contactNumber: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required]),
      vehicleNumber: new FormControl('', [Validators.required]),
      vehicleModel: new FormControl('', [Validators.required]),
      serviceRequirements: new FormControl('', [Validators.required]),
      bookingDate: new FormControl('', [Validators.required])
    });

  }
  minDate: any;
  ngOnInit() {
    const today = new Date();
    this.minDate = today.toISOString().split('T')[0]; // Format: YYYY-MM-DD
    console.log(this.customerId);
  }
  datalength: number = 0;
  submitForm() {

    this.customerName = this.customerDetails.get('customerName')?.value;
    this.contactNumber = this.customerDetails.get('contactNumber')?.value;
    this.email = this.customerDetails.get('email')?.value;
    this.address = this.customerDetails.get('address')?.value;
    this.vehicleNumber = this.customerDetails.get('vehicleNumber')?.value;
    this.vehicleModel = this.customerDetails.get('vehicleModel')?.value;
    this.serviceRequirements = this.customerDetails.get('serviceRequirements')?.value;
    this.bookingDate = this.customerDetails.get('bookingDate')?.value;


    let customer: Customer = new Customer();
    let booking: Booking = new Booking();

    customer.customerName = this.customerName,
      customer.contactNumber = this.contactNumber,
      customer.email = this.email,
      customer.address = this.address,
      customer.vehicleNumber = this.vehicleNumber,
      customer.vehicleModel = this.vehicleModel,
      customer.serviceRequirements = this.serviceRequirements,
      customer.customerId = this.customerId,
      booking.customerId = this.customerId,
      booking.bookingDate = this.bookingDate,

      this.service.customerDetails(customer).subscribe(res => {

        this.service.Bookingdetails(booking).subscribe((res: Bookingdetails) => {

          this.service.CustomerViewBooking().subscribe(res => {
            this.data = res
            this.datalength = this.data.length;
            customer.bookingId = this.data[this.datalength - 1].bookingId
            console.log(customer.bookingId);
            console.log(this.data[this.datalength - 1].bookingId);
            this.service.customerDetails(customer).subscribe(res => {
            })
          })
        })
        alert("Your Booking date is " + booking.bookingDate)
        this.customerDetails.reset();
      })
  }
}
