import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Login } from '../shared/Login';
import { Jwtresponse } from '../shared/jwtresponse';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //declare variables
  loginForm: FormGroup;
  isSubmitted = false;
  loginUser: Login = new Login();
  error = '';
  jwtResposonse : any = new Jwtresponse()

  constructor(private formBuilder: FormBuilder,
    private router: Router, private authService: AuthService) { }

  ngOnInit(): void {    

    //FormGroup
    this.loginForm = this.formBuilder.group(
      {
        Username: ['', [Validators.required, Validators.minLength(2)]],
        Password: ['', [Validators.required]]});
      }      

  get formControls() {
    return this.loginForm.controls;
  }
  //login verify
  loginCredentials() {

    //console.log("Test A");

    this.isSubmitted = true;
    // console.log(this.loginForm.value);

    //invalid
    if (this.loginForm.invalid)
      return;

    //valid
    if (this.loginForm.valid) {
      //calling mathod from AuthService  --Authorization
      //this.authService.getUserByPassword(this.loginForm.value)
      this.authService.loginVerify(this.loginForm.value)
        .subscribe(data => {

          console.log('-----------------------');


          console.log(data);

          console.log('-----------------------');

          // console.log("Intercept Check Login Component");

          this.jwtResposonse = data;

          sessionStorage.setItem("jwtToken", this.jwtResposonse.token);
          sessionStorage.setItem("username", this.jwtResposonse.uName);

          //console.log("logincomp " + sessionStorage.getItem("username"));
          //console.log("logincomp " + sessionStorage.getItem("jwtToken"));
          //check the role --based on TRoleId, it redirects to the respectice component

          
          if (this.jwtResposonse.role === 'ADMIN') {
            //logged as admin
            // console.log("Admin");           
            localStorage.setItem("username", this.jwtResposonse.uName.toString());
            localStorage.setItem("ACCESS_ROLE", this.jwtResposonse.role.toString());

            // console.log("b4 nav logincomp " + sessionStorage.getItem("username"));
            // console.log("b4 nav logincomp " + sessionStorage.getItem("jwtToken"));
            this.router.navigateByUrl('admin');
          }
          
          else if (this.jwtResposonse.role === 'HR') {
            //logged as manager
            console.log("HR");
            localStorage.setItem("username", this.jwtResposonse.uName.toString());
            localStorage.setItem("ACCESS_ROLE", this.jwtResposonse.role.toString());
            this.router.navigateByUrl('hr');
          }
          else if (this.jwtResposonse.role === 'USER') {
            //logged as manager
            console.log("User");
            localStorage.setItem("username", this.jwtResposonse.uName.toString());
            localStorage.setItem("ACCESS_ROLE", this.jwtResposonse.role.toString());
            this.router.navigateByUrl('user');
          }
          else {
            this.error = "sorry not allowed...Invalid authorization"
          }
        },
          errors => {
            this.error = "invalid username or password. try again"
          }
        );
          
    }

  }


  loginVerifyTest()
  {

    console.log("Login Verify Test");    
    if(this.loginForm.valid)
    {
      this.authService.getUserByPassword(this.loginForm.value)
      .subscribe(
        (data) => 
        {          
          //console.log("Login Verify Test data");
          console.log(data);

        },
        (error) =>
        {
          console.log(error);
        }
      )
    }
  }

}
