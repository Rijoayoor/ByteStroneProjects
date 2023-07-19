import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-technicianviewjob',
  templateUrl: './technicianviewjob.component.html',
  styleUrls: ['./technicianviewjob.component.css']
})
export class TechnicianviewjobComponent {
  data:any

  // pagination
  POSTS:any;

  page:number=1;

  count:number=0;

  tableSize:number=10;

 
  roleId=this.service.roleIdGetter()

  constructor(private service: ApiService) { }
onTableDataChange(event:any){

    this.page=event;    

  }

  ngOnInit() {
this.service.viewbookingtechnician(this.roleId).subscribe(res=>{
  this.data=res
  console.log(this.data);
  console.log(this.roleId);
  
})
  }

}
