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

  // customerdetails() {
  //   this.custumerOns = !this.custumerOns
  //   if (this.bookingFormsOns) {
  //     this.bookingFormsOns = !this.bookingFormsOns
  //   }

  //   // this.route.navigateByUrl("/customerhome")
  // }
  // bookingdetails() {
  //   // this.route.navigateByUrl("/customerbooking")
  //   this.bookingFormsOns = !this.bookingFormsOns
  //   if (this.custumerOns) {
  //     this.custumerOns = !this.custumerOns
  //   }
  // }


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
    // this.route.navigateByUrl("/executiveviewbooking")
    // this.viewBookingOn = !this.viewBookingOn
    // if (this.changeStatus ) {
    //   this.changeStatus = !this.changeStatus

    // }
    // if(this.searchForm){
    //   this.changeStatus = !this.changeStatus
    // }
    // if(this.changeStatus||this.searchForm)
    // {
    //   this.changeStatus = !this.changeStatus
    //   this.searchForm = !this.searchForm
    // }

  }
  // changestatus() {
  //   // this.route.navigateByUrl("/executivechangestatus")
  //   this.changeStatus = !this.changeStatus
  //   if (this.viewBookingOn) {
  //     this.viewBookingOn = !this.viewBookingOn

  //   }
  //   if (this.searchForm) {

  //     this.searchForm = !this.searchForm
  //   }


  // }
  //   search() {
  //     // this.route.navigateByUrl("/executivesearch")
  //     this.searchForm = !this.searchForm
  //     if (this.viewBookingOn) {
  //       this.viewBookingOn = !this.viewBookingOn

  //     }
  //     if (this.changeStatus) {
  //       this.changeStatus = !this.changeStatus
  //     }

  //   }

}
function bookingstatus(ViewBooking: string, string: any) {
  throw new Error('Function not implemented.');
}

