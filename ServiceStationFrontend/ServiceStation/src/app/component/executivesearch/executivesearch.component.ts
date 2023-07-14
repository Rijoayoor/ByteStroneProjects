import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-executivesearch',
  templateUrl: './executivesearch.component.html',
  styleUrls: ['./executivesearch.component.css']
})
export class ExecutivesearchComponent {
  searchCriteria1!: string;
  searchCriteria2!: string;
  searchCriteria3!: string;
  searchCriteria4!: string;
  searchCriteria5!: string;
  viewSearchResult=false
  constructor(private service:ApiService){
    

  }

  isSearchEnabled() {
    // Return true if all three search criteria are filled
    return this.searchCriteria1 && this.searchCriteria2 && this.searchCriteria3;
  }

  
 searchValue:any;
  setSearch(){
  this.service.searchRequest(this.searchCriteria1,this.searchCriteria2,this.searchCriteria3,this.searchCriteria4,this.searchCriteria5).subscribe((res:any)=>{
    this.searchValue=res;
    console.log(this.searchValue);
    this.viewSearchResult=true
    
  })
   }
}
