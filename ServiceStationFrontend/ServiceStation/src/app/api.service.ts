import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private Url= "http://localhost:5087/api/login";


  constructor(private Http:HttpClient) { }

  login(Username:string,Password:string,Userrole:string):Observable<any>{
    return this.Http.post<any>(this.Url,{Username,Password,Userrole})
  }
}
