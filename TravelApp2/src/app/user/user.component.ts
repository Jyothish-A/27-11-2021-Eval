import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

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
