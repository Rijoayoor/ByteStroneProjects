import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';
import { Customer } from 'src/app/model/customer';
import { Executivestatuschange } from 'src/app/model/executivestatuschange';

@Component({
  selector: 'app-executivechangestatus',
  templateUrl: './executivechangestatus.component.html',
  styleUrls: ['./executivechangestatus.component.css']
})
export class ExecutivechangestatusComponent {
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
  ex=Executivestatuschange

  onTableDataChange(event:any){

    this.page=event;    

  }
ngOnInit(){
  this.service.changestatusexecutive(this.roleId).subscribe(res=>{
    this.data=res
    // this.data.map((el:any)=>{
      console.log(this.data);
    //   el.status
      
    // })
   
  })
  
}
 
update(bookingId:number,e:Executivestatuschange){
  // if(e.status==="Cancelled"){
  //   alert("cant update")
  // }
 
  
  // else{
  
  this.service.updatestatus(this.roleId,bookingId,e).subscribe(res=>{
    alert("Updated !!")
   
    
  })}
}

// }


