import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  Username : string = "Error";

  constructor(private authService : AuthService, private router : Router) { }

  ngOnInit(): void {
    this.Username = localStorage.getItem("username");
  }

  logout()
  {
    this.authService.logout();
    this.router.navigateByUrl("login");
  }


}
