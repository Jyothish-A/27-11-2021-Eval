import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { HrComponent } from './hr/hr.component';
import { UserComponent } from './user/user.component';
import { FormsModule } from '@angular/forms';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxPaginationModule } from 'ngx-pagination';
import {  Ng2SearchPipeModule } from 'ng2-search-filter';
import { ReactiveFormsModule } from '@angular/forms';

import { AuthService } from './shared/auth.service';
import {AuthGuard } from './shared/auth.guard';
import { AuthInterceptor } from './shared/auth.interceptor';
import { TravelFormComponent } from './travel-form/travel-form.component';

import { RequestService } from './shared/request.service';
import { RequestlistComponent } from './requestlist/requestlist.component';
import { SignupComponent } from './signup/signup.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AdminComponent,
    HrComponent,
    UserComponent,
    TravelFormComponent,
    RequestlistComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule, 
    ToastrModule.forRoot(),
    NgxPaginationModule,
    Ng2SearchPipeModule,
    ReactiveFormsModule
  ],

  providers: [  RequestService,
                AuthService, 
                AuthGuard,
              {
              provide: HTTP_INTERCEPTORS,
              useClass: AuthInterceptor,
              multi : true
            }],
  bootstrap: [AppComponent]
})


export class AppModule { }
