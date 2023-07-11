import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Customer } from 'src/app/model/customer';
import { flush } from '@angular/core/testing';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent {
  name = ""
  role= ""
  custumerOns = false
  bookingFormsOns = false


  constructor(private service: ApiService, private route: Router) { }
  ngOnInit() {
    this.name = this.service.nameGetter()
    this.role=this.service.roleGetter()

  }
  logout() {
    this.route.navigateByUrl("/login")
  }
  customerdetails() {
    this.custumerOns = !this.custumerOns
    if (this.bookingFormsOns) {
      this.bookingFormsOns = !this.bookingFormsOns
    }

    // this.route.navigateByUrl("/customerhome")
  }
  bookingdetails() {
    // this.route.navigateByUrl("/customerbooking")
    this.bookingFormsOns = !this.bookingFormsOns
    if (this.custumerOns) {
      this.custumerOns = !this.custumerOns
    }
  }





}


