import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-executiveviewtechnicians',
  templateUrl: './executiveviewtechnicians.component.html',
  styleUrls: ['./executiveviewtechnicians.component.css']
})
export class ExecutiveviewtechniciansComponent {
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
    this.service.Executiveviewtechnician().subscribe(res => {
      this.data = res
      console.log(this.data);
      console.log(this.roleId);
    })
  }
}
