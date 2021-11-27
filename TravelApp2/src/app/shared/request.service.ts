import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Request } from './RequestForm';
import { Login } from './Login';
import { Employee } from './Employee';
import { Project } from './Project';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  formData: Request = new Request();

  requests : Request[];

  projects : Project[];

  employee : Employee[];

  login : Login[];

  constructor(private httpClient: HttpClient) { }

  refreshRequests()
  {    
    // https://localhost:44315/api/company/getdepartmentall
    this.httpClient.get(environment.apiUrl + "/api/travel/GetRequests")
    .toPromise().then( response =>       
      this.requests = response as Request[] );
  }

  refreshProjects()
  {    
    // https://localhost:44315/api/company/getdepartmentall
    this.httpClient.get(environment.apiUrl + "/api/travel/GetProjects")
    .toPromise().then( response =>       
      this.projects = response as Project[] );
  }




  refreshEmployees()
  {    
    // https://localhost:44315/api/company/getdepartmentall
    this.httpClient.get(environment.apiUrl + "/api/travel/GetEmployees")
    .toPromise().then( response =>       
      this.employee = response as Employee[] );
  }





  addRequest(request : Request) : Observable<any>
  {
    return this.httpClient.post(environment.apiUrl + "/api/travel/AddRequest", request);
  }

  addLogin(login : Login) : Observable<any>
  {
    return this.httpClient.post(environment.apiUrl + "/api/travel/AddLogin", login);
  }

  addEmployee(employee : Employee) : Observable<any>
  {
    return this.httpClient.post(environment.apiUrl + "/api/travel/AddEmployee", employee);
  }

  updateRequest(request : Request) : Observable<any>
  {
    return this.httpClient.put(environment.apiUrl + "/api/travel/UpdateRequest", request);
  }

}
