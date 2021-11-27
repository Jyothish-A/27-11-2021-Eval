import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { HrComponent } from './hr/hr.component';
import { LoginComponent } from './login/login.component';
import { RequestlistComponent } from './requestlist/requestlist.component';
import { AuthGuard } from './shared/auth.guard';
import { TravelFormComponent } from './travel-form/travel-form.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [  
  {path:'login',component: LoginComponent},
  {path:'', redirectTo:'/login', pathMatch:"full"},  
  {path:'admin',component:AdminComponent, canActivate: [AuthGuard], data: {Role : 'ADMIN'}},
  {path:'hr',component:HrComponent, canActivate: [AuthGuard], data: {Role : 'HR'}},
  {path:'user',component:UserComponent, canActivate: [AuthGuard], data: {Role : 'USER'}},
  {path:'admin/addeditrequest',component:TravelFormComponent, canActivate: [AuthGuard], data: {Role : ['ADMIN']}},
  {path:'user/addeditrequest',component:TravelFormComponent, canActivate: [AuthGuard], data: {Role : ['USER']}},
  {path:'admin/listrequests',component:RequestlistComponent, canActivate: [AuthGuard], data: {Role : ['ADMIN']}}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
