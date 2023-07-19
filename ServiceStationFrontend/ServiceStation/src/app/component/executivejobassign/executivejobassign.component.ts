import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { AssignJobs } from 'src/app/model/assignjob';
import { Customer } from 'src/app/model/customer';
import { Executivestatuschange } from 'src/app/model/executivestatuschange';

@Component({
  selector: 'app-executivejobassign',
  templateUrl: './executivejobassign.component.html',
  styleUrls: ['./executivejobassign.component.css']
})
export class ExecutivejobassignComponent {
  name = ""

  data:any
  stat:any
  technicians:any
  techniciandetails:any
  lengths:any

  POSTS:any;

  page:number=1;

  count:number=0;

  tableSize:number=10;
 
  roleId=this.service.roleIdGetter()
  customerId=this.service.customerIdGetter()
  constructor(private service: ApiService) { }
  ex=Executivestatuschange

  onTableDataChange(event:any){

    this.page=event;    

  }
ngOnInit(){
  this.service.viewjobassign(this.roleId).subscribe(res=>{
    this.data=res
   console.log(this.data);
   
  })
  this.service.viewtechnician().subscribe(res=>{
    this.technicians=res
    console.log(this.technicians);
    this.lengths=this.technicians.length;
    console.log(this.lengths);
    
  })
}
 
assign(bookingId:number,assign:AssignJobs){
  console.log(bookingId);
  
  
  
  this.service.updateTechnician(this.roleId,bookingId,assign).subscribe(res=>{
    console.log(res);
    
    

    alert("Job Assigned !!")
   
    
  })}

}
