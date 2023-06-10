import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-executiveviewbooking',
  templateUrl: './executiveviewbooking.component.html',
  styleUrls: ['./executiveviewbooking.component.css']
})
export class ExecutiveviewbookingComponent {
  data:any

  constructor(private service: ApiService) { }

  ngOnInit() {
this.service.viewbookingexecutive().subscribe(res=>{
  this.data=res
  console.log(this.data);
  
})
  }

}
