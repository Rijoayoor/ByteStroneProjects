import { Component } from '@angular/core';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-technician',
  templateUrl: './technician.component.html',
  styleUrls: ['./technician.component.css']
})
export class TechnicianComponent {
  name=""
  constructor(private service:ApiService){}
  ngOnInit(){
    this.name=this.service.nameGetter()
  }

}
