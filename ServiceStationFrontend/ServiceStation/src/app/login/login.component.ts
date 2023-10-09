import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';
import { compileNgModule } from '@angular/compiler';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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
  roleId!: number
  loginForm1: FormGroup;
  constructor(private service: ApiService, private route: Router) {
    this.loginForm1 = new FormGroup({
      userName: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      role: new FormControl('', [Validators.required])
    });
  }
  ngOnInit() {
    sessionStorage.clear();
  }
  Login() {
    this.Username = this.loginForm1.get('userName')?.value.trim();
    this.Password = this.loginForm1.get('password')?.value.trim();
    this.Userrole = this.loginForm1.get('role')?.value;
    console.log(this.Username);
    console.log(this.Password);
    this.service.login(this.Username, this.Password, this.Userrole).subscribe(res => {
      if (res != null) {
        console.log(this.Username, this.Password, this.Userrole)
        this.data = res
        console.log(this.data)
        this.name = this.data.name
        this.role = this.data.userrole
        this.roleId = this.data.roleId
        this.service.nameSetter(this.name);
        this.service.roleSetter(this.role);
        this.service.customerIdSetter(this.data.id)
        this.service.roleIdSetter(this.data.roleId)
        console.log(this.data.roleId)
        sessionStorage.setItem("username", this.data.username)
        this.route.navigate([this.data.userrole])
        // alert("Login successfull!")
      }
      else {
        alert("Invalid Login")
      }
    })
  }
}