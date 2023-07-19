import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Technicianstatuschange } from 'src/app/model/technicianstatuschange';

@Component({
  selector: 'app-technicianstatusupdate',
  templateUrl: './technicianstatusupdate.component.html',
  styleUrls: ['./technicianstatusupdate.component.css']
})
export class TechnicianstatusupdateComponent {
  name = ""
  data:any
  stat:any

  POSTS:any;

  page:number=1;

  count:number=0;

  tableSize:number=10;
  
  roleId=this.service.roleIdGetter()
  customerId=this.service.customerIdGetter()
  constructor(private service: ApiService) { }
  ex=Technicianstatuschange
  onTableDataChange(event:any){

    this.page=event;    

  }
ngOnInit(){
  this.service.changestatustechnician(this.roleId).subscribe(res=>{
    this.data=res
   
   
  })
  
}
 
update(customerId:number,e:Technicianstatuschange){
  
  
  this.service.updatestatustechnician(this.roleId,customerId,e).subscribe(res=>{
    alert("Updated !!")
   
    
  })}



}
