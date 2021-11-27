import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService : AuthService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    console.log("Intercepting here ..");    

    console.log(sessionStorage.getItem("username"));
    console.log(sessionStorage.getItem("jwtToken"));

    let token = sessionStorage.getItem("jwtToken");

    console.log("Token Test : " + token);

    if(sessionStorage.getItem("username") && sessionStorage.getItem("jwtToken"))
    {
      console.log("Setting Token ...")
      request = request.clone(
      {
        setHeaders : 
        {
          Authorization : `Bearer ${token}`
        }
      })
    }

    return next.handle(request);
  }
}
