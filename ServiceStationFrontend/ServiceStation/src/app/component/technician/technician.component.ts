import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-technician',
  templateUrl: './technician.component.html',
  styleUrls: ['./technician.component.css']
})
export class TechnicianComponent {
  name=""
  role=""
  viewBookingtechnician=false
  changeStatus=false
  ViewBooking = "ViewBooking"
  ChangeStatus = "changeStatus"

  
  constructor(private service:ApiService,private route: Router){}
  ngOnInit(){
    this.name=this.service.nameGetter()
    this.role=this.service.roleGetter()
  }
  logout() {
    this.route.navigateByUrl("/login")
  }

  bookingdetailstechnician(ViewBooking:string)
  {
    if (ViewBooking == "ViewBooking") {
      this.viewBookingtechnician = true
      this.changeStatus=false

    }
    else if(ViewBooking="changeStatus"){
      this.viewBookingtechnician = false
      this.changeStatus=true

    }

  }

}
