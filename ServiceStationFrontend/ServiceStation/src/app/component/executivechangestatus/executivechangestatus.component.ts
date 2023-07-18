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
  // customerName!: string
  // contactNumber!: string
  // email!: string
  // address!: string
  // vehicleNumber!: string
  // vehicleModel!: string
  // serviceRequirements!: string
  // status!:string
  roleId=this.service.roleIdGetter()
  customerId=this.service.customerIdGetter()
  constructor(private service: ApiService) { }
  ex=Executivestatuschange

  // editItem(){
    

  // let customer: Customer = new Customer();

  // customer.customerName = this.customerName,
  //   customer.contactNumber = this.contactNumber,
  //   customer.email = this.email,
  //   customer.address = this.address,
  //   customer.vehicleNumber = this.vehicleNumber,
  //   customer.vehicleModel = this.vehicleModel,
  //   customer.serviceRequirements = this.serviceRequirements
  // console.log(customer)
  // this.service.customerDetails(customer).subscribe(res => {
  //   this.data=res
  //   console.log(res)
  //   console.log(res.customerId);
  //   this.service.customerIdSetter(res.customerId);
  //   // localStorage.setItem("cid",res.customerId.toString())
  //   alert("Customer Details Added!")

  // })
  // this.route.navigateByUrl("/customer")

  onTableDataChange(event:any){

    this.page=event;    

  }
ngOnInit(){
  this.service.changestatusexecutive(this.roleId).subscribe(res=>{
    this.data=res
    // this.data.map((el:any)=>{
    //   console.log(this.data);
    //   el.status
      
    // })
   
  })
  
}
 
update(customerId:number,e:Executivestatuschange){
  // if(e.status==="Cancelled"){
  //   alert("cant update")
  // }
 
  
  // else{
  
  this.service.updatestatus(this.roleId,customerId,e).subscribe(res=>{
    alert("Updated !!")
   
    
  })}
}

// }


