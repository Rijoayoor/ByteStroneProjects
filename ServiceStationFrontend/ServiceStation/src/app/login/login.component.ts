import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';
import { compileNgModule } from '@angular/compiler';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  Username: string | any
  Password: string | any
  Userrole: string | any
  details: string | any
  data: any
  name: string = ""
  role: string = ""
  roleId!:number


  constructor(private service: ApiService, private route: Router) { }



  Login() {

    this.service.login(this.Username, this.Password, this.Userrole).subscribe(res => {
      console.log(this.Username, this.Password, this.Userrole)
      this.data = res
      console.log(this.data)
      this.name = this.data.name
      this.role = this.data.userrole
      this.roleId=this.data.roleId
      this.service.nameSetter(this.name);
      this.service.roleSetter(this.role);
      this.service.customerIdSetter(this.data.id)
      this.service.roleIdSetter(this.data.roleId)
      console.log(this.data.roleId)
      this.route.navigate([this.data.userrole])

    })
  }
}