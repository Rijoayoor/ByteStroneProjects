import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-executiveviewbooking',
  templateUrl: './executiveviewbooking.component.html',
  styleUrls: ['./executiveviewbooking.component.css']
})
export class ExecutiveviewbookingComponent {
  data:any

  // pagination
  POSTS:any;

  page:number=1;

  count:number=0;

  tableSize:number=10;

  // tableSizes:any=[5,10,15,20];

  // booking.customerId=this.service.customerIdGetter()
  roleId=this.service.roleIdGetter()

  constructor(private service: ApiService) { }
onTableDataChange(event:any){

    this.page=event;    

  }

  // onTableSizeChange(event:any){

  //   this.tableSize=event.target.value;

  //   this.page=1;    

  // }
  ngOnInit() {
this.service.viewbookingexecutive(this.roleId).subscribe(res=>{
  this.data=res
  console.log(this.data);
  console.log(this.roleId);
  
})
  }

}
