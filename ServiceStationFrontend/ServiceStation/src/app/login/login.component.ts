import { Component } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  Username:string|any
  Password:string|any
  Userrole:string|any
  details:string|any


  constructor(private service:ApiService){ }

 

  Login() {

    this.service.login(this.Username, this.Password,this.Userrole).subscribe(

     

        (response) => {

          // Handle successful login response

          console.log( response);

          this.details=response},
          (error) => {

            // Handle login error
  
            console.error('Loggin error', error);
  
            alert("invalid credentials")
  
          })
}}