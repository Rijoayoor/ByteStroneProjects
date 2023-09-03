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
  data: any
  roleId = this.service.roleIdGetter()

  
  constructor(private service:ApiService,private route: Router){}
  countUpdated:number=0;
  ngOnInit(){
   this.name=this.service.nameGetter()
    this.role=this.service.roleGetter()
    this.service.viewbookingtechnician(this.roleId).subscribe(res => {
      this.data = res
      console.log(this.data);
      
      let alertShown = false;

      this.data.forEach((technicianDetails: { status: any; }) => {
        if (technicianDetails.status == "In progress"||"Assigned" ) {
          // alert("You have pending Jobs!!!");
          this.countUpdated++;
          // alertShown = true;
        }
      });
    })
  }
  logout() {
    sessionStorage.removeItem("username");
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
