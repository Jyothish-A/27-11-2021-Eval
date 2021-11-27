import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Login } from './Login'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient,
    private router : Router,    
  ) { }

  
  public loginVerify(user: Login)
  {
    // console.log(user);
    return this.httpClient.get(environment.apiUrl + "/api/travel/GetUserByUPT/" + user.Username + "/" + user.Password);
  }

  getUserByPassword(user: Login): Observable<any> {
    // console.log(user.Username);
    // console.log(user.Password);
    return this.httpClient.get(environment.apiUrl + "/api/travel/GetUserByUP/" + user.Username + "/" + user.Password);
  }
  
  public logout()
  {
    localStorage.clear();
    sessionStorage.clear();
  }
  


}
