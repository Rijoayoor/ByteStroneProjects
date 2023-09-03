import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';


@Component({
  selector: 'app-executivesearch',
  templateUrl: './executivesearch.component.html',
  styleUrls: ['./executivesearch.component.css']
})
export class ExecutivesearchComponent {
  searchCriteria1: string ="";
  searchCriteria2: string ="";
  searchCriteria3: string ="";
  searchCriteria4: string ="";
  searchCriteria5: string ="";

  POSTS: any;

  page: number = 1;

  count: number = 0;

  tableSize: number = 10;

  viewSearchResult = true
  roleId = this.service.roleIdGetter()
  constructor(private service: ApiService) {


  }
  onTableDataChange(event: any) {

    this.page = event;

  }


  // isSearchEnabled() {
  //   // Return true if all three search criteria are filled
  //   return this.searchCriteria1 && this.searchCriteria2 && this.searchCriteria3;
  // }


  searchValue: any;
  setSearch() {
    console.log(this.searchCriteria2)
    console.log(this.searchCriteria4)
    console.log(this.searchCriteria3)
    console.log(this.searchCriteria5)


    if (this.searchCriteria1 == "" && this.searchCriteria2 == "" && this.searchCriteria3 == "" && this.searchCriteria4 == "" && this.searchCriteria5 == "") {
      alert("Please fill the required fields!!")
    }
    else {



      this.service.searchRequest(this.searchCriteria1, this.searchCriteria2, this.searchCriteria3, this.searchCriteria4, this.searchCriteria5, this.roleId).subscribe((res: any) => {
        this.searchValue = res;
        if (this.searchValue != null) {
          console.log(this.searchValue);
          this.viewSearchResult = true
        }
        else if (this.searchValue == null) {
          alert("No Records found!")
        }

      })
    }
  }
}
