import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-executive',
  templateUrl: './executive.component.html',
  styleUrls: ['./executive.component.css']
})
export class ExecutiveComponent {
  name: String = ""
  role = ""
  viewBookingOn = true
  changeStatus = false
  searchForm = false
  assignJob = false
  viewTechnicians = false
  constructor(private service: ApiService, private route: Router) { }
  ngOnInit() {
    this.name = this.service.nameGetter()
    this.role = this.service.roleGetter()
  }
  logout() {
    sessionStorage.removeItem("username");
    this.route.navigateByUrl("/login")
  }
  ViewBooking = "ViewBooking"
  SearchForm = "searchForm"
  ChangeStatus = "changeStatus"
  AssignJob = "assignJob"
  ViewTechnicians = "viewTechnicians"
  bookingstatus(ViewBooking: string) {
    if (ViewBooking == "ViewBooking") {
      this.viewBookingOn = true
      this.changeStatus = false;
      this.searchForm = false
      this.assignJob = false
      this.viewTechnicians = false
    }
    else if (ViewBooking == "changeStatus") {
      this.viewBookingOn = false
      this.changeStatus = true
      this.searchForm = false
      this.assignJob = false
      this.viewTechnicians = false
    }
    else if (ViewBooking == "searchForm") {
      this.viewBookingOn = false
      this.changeStatus = false
      this.searchForm = true
      this.assignJob = false
      this.viewTechnicians = false
    }
    else if (ViewBooking == "viewTechnicians") {
      this.viewBookingOn = false
      this.changeStatus = false
      this.searchForm = false
      this.assignJob = false
      this.viewTechnicians = true
    }
    else if (ViewBooking == "assignJob") {
      this.viewBookingOn = false
      this.changeStatus = false
      this.searchForm = false
      this.assignJob = true
      this.viewTechnicians = false
    }
  }
}
function bookingstatus(ViewBooking: string, string: any) {
  throw new Error('Function not implemented.');
}

