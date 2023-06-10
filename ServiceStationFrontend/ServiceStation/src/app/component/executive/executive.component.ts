import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-executive',
  templateUrl: './executive.component.html',
  styleUrls: ['./executive.component.css']
})
export class ExecutiveComponent {
  name = ""
  constructor(private service: ApiService, private route: Router) { }
  ngOnInit() {
    this.name = this.service.nameGetter()
  }

  logout() {
    this.route.navigateByUrl("/login")
  }
  bookingstatus()
  {
    this.route.navigateByUrl("/executiveviewbooking")
  }


}
