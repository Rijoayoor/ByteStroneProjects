import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-executive',
  templateUrl: './executive.component.html',
  styleUrls: ['./executive.component.css']
})
export class ExecutiveComponent {
  name = ""
  role = ""
  viewBookingOn = false
  changeStatus = false
  constructor(private service: ApiService, private route: Router) { }
  ngOnInit() {
    this.name = this.service.nameGetter()
    this.role = this.service.roleGetter()
  }

  logout() {
    this.route.navigateByUrl("/login")
  }
  bookingstatus() {
    // this.route.navigateByUrl("/executiveviewbooking")
    this.viewBookingOn = !this.viewBookingOn
    if (this.changeStatus) {
      this.changeStatus = !this.changeStatus
    }

  }
  changestatus() {
    // this.route.navigateByUrl("/executivechangestatus")
    this.changeStatus = !this.changeStatus
    if (this.viewBookingOn) {
      this.viewBookingOn = !this.viewBookingOn
    }
  }


}
