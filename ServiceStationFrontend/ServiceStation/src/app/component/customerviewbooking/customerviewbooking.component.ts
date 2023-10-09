import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';
import { Customerviewbooking } from 'src/app/model/customerviewbooking';

@Component({
  selector: 'app-customerviewbooking',
  templateUrl: './customerviewbooking.component.html',
  styleUrls: ['./customerviewbooking.component.css']
})
export class CustomerviewbookingComponent {
  data:any
  roleId=this.service.roleIdGetter()
  constructor(private service: ApiService) { }
  ngOnInit(){
    console.log(this.roleId);
    this.service.viewbookingcustomer(this.roleId).subscribe(res=>{
      this.data=res
      console.log(this.data);
  })
}
}
