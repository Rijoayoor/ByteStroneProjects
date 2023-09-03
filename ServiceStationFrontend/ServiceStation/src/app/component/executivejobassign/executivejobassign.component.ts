import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { AssignTechnician } from 'src/app/model/assign-technician';
import { AssignJobs } from 'src/app/model/assignjob';
import { Customer } from 'src/app/model/customer';
import { Customerupdatedetails } from 'src/app/model/customerupdatedetails';
import { Executivestatuschange } from 'src/app/model/executivestatuschange';

@Component({
  selector: 'app-executivejobassign',
  templateUrl: './executivejobassign.component.html',
  styleUrls: ['./executivejobassign.component.css']
})
export class ExecutivejobassignComponent {
  name = ""
  date!: Date

  data: any
  stat: any
  technicians: any
  techniciandetails: any
  requirement: any
  lengths: any

  POSTS: any;

  page: number = 1;

  count: number = 0;

  tableSize: number = 10;

  roleId = this.service.roleIdGetter()
  // customerId = this.service.customerIdGetter()
  constructor(private service: ApiService) { }
  ex :Customerupdatedetails={
    customerId: 0, // Example customerId
    customerName:'', // Example customerName
    contactNumber:'', // Example contactNumber
    serviceRequirements: ''



  }
  onTableDataChange(event: any) {

    this.page = event;

  }

  Assignedname:string|any
  ngOnInit() {
    this.service.viewjobassign(this.roleId).subscribe(res => {
      this.data = res
      console.log(this.data.bookingDate);
      this.data.forEach((item:any) => {
        console.log("name111: " + item.technicianName);
        this.Assignedname=item.technicianName
        
    });
    
      console.log(this.data);
      console.log("name"+this.data[0].technicianName);

console.log(this.Assignedname);

    })
    this.service.viewtechnician().subscribe(res => {
     
      
      this.technicians = res
      const techniciansArray = Object.values(res);
        
      //   // Filter out the technician with the assigned name
      //   this.technicians = techniciansArray.filter(tech => tech.technicianName !== this.Assignedname);
      //   console.log("llkk"+this.technicians);
        

     
      // this.lengths = this.technicians.length;
      // console.log("ll"+this.lengths);

    })
  }

  assign(bookingId: number,executiveId:number, assign: AssignJobs) {

    // assign.expectedCompletionDate=this.date
    console.log(assign);

    this.service.updateTechnician(executiveId, bookingId, assign).subscribe(res => {
      console.log(res);
      


      this.service.updateRequirement(executiveId,bookingId,assign).subscribe(res => {
        this.requirement = res;
        console.log(res);

      })


      alert("Job Assigned !!")


      // window.location.reload()


    })

  }


}
