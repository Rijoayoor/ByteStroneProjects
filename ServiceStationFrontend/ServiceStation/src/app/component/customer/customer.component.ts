import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Customer } from 'src/app/model/customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent {
  name = ""
  


  constructor(private service: ApiService, private route: Router) { }
  ngOnInit() {
    this.name = this.service.nameGetter()
  }
  logout() {
    this.route.navigateByUrl("/login")
  }
  customerdetails()
  {
    this.route.navigateByUrl("/customerhome")
  }
  


    
  
}


