import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/auth.service';
import { RequestService } from '../shared/request.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor( private reqService : RequestService,
    private toastrService : ToastrService,
    private authService : AuthService,
    private router : Router) { }

  ngOnInit(): void {
    this.reqService.refreshProjects();
    this.reqService.refreshRequests();
    this.reqService.refreshEmployees();
    
  }


  onSubmit(form : NgForm)
  {
    console.log(form.value);
    
      this.addLogin(form);
      this.toastrService.success('Request Inserted', 'Travel App');
   
    // window.location.reload();
    
    
  }

  resetform(form?:NgForm)
  {
    if(form != null)
    {
      form.resetForm();
    }
  }


  addLogin(form?:NgForm)
  {
    this.reqService.addLogin(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetform(form);
        this.toastrService.success("Request inserted");
      }
    );
  }

}
