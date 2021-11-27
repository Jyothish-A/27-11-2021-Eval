import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/auth.service';
import { RequestService } from '../shared/request.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-travel-form',
  templateUrl: './travel-form.component.html',
  styleUrls: ['./travel-form.component.css']
})
export class TravelFormComponent implements OnInit {

  username = localStorage.getItem("username");
  currentRole = localStorage.getItem("ACCESS_ROLE");

  constructor(public reqService : RequestService, 
    private toastrService : ToastrService,
    private authService : AuthService,
    private router : Router
    ) { }

  ngOnInit(): void {
    this.reqService.refreshProjects();
    this.reqService.refreshRequests();
    this.reqService.refreshEmployees();
    
  }

  onSubmit(form : NgForm)
  {
    console.log(form.value);

    let addId = this.reqService.formData.Requestid;
    // this.reqService.formData.NoDays = this.reqService.formData.ToDate.valueOf() - this.reqService.formData.FromDate.valueOf() 

    var ToDate = new Date(this.reqService.formData.ToDate);
    var FromDate = new Date(this.reqService.formData.FromDate);


    var diff = Math.abs(ToDate.getTime() - FromDate.getTime());
    var diffDays = Math.ceil(diff / (1000 * 3600 * 24)); 
    this.reqService.formData.NoDays = diffDays

    // INSERT
    
    if(addId == 0 || addId == null)
    {
      this.addRequest(form);
      this.toastrService.success('Request Inserted', 'Travel App');
    }
    else
    {
      this.updateRequest(form);
      console.log("Updating Request ..");
    }

    // window.location.reload();
    
    
  }

  resetform(form?:NgForm)
  {
    if(form != null)
    {
      form.resetForm();
    }
  }


  addRequest(form?:NgForm)
  {
    console.log("Inserting a Request");
    this.reqService.addRequest(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetform(form);
        this.toastrService.success("Request inserted");
      }
    );
  }


  updateRequest(form?:NgForm)
  {
    console.log("Updating request ...");
    this.reqService.updateRequest(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetform(form);
        this.toastrService.success('Request Updated', 'Travel App');
        this.reqService.refreshProjects();
      }
    );
  }

  logout()
  {
    this.authService.logout();
    this.router.navigateByUrl("login");
  }





}
