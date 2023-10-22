import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-executiveviewbooking',
  templateUrl: './executiveviewbooking.component.html',
  styleUrls: ['./executiveviewbooking.component.css']
})
export class ExecutiveviewbookingComponent {
  data: any
  POSTS: any;
  page: number = 1;
  count: number = 0;
  tableSize: number = 10;
  roleId = this.service.roleIdGetter()
  constructor(private service: ApiService) { }
  onTableDataChange(event: any) {
    this.page = event;
  }
  ngOnInit() {
    console.log(this.roleId);
    this.service.viewbookingexecutive(this.roleId).subscribe(res => {
      this.data = res
      console.log(this.data);
      console.log(this.roleId);
    })
  }
}