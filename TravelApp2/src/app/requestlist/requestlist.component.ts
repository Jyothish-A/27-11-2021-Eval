import { Component, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Request } from 'src/app/shared/RequestForm';
import { RequestService } from 'src/app/shared/request.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-requestlist',
  templateUrl: './requestlist.component.html',
  styleUrls: ['./requestlist.component.css']
})
export class RequestlistComponent implements OnInit {

  page : number = 1;
  filter : string;


  constructor(public reqService : RequestService,
    public toastrService:  ToastrService,
    private router: Router) { }

  ngOnInit(): void {
    this.reqService.refreshProjects();
    this.reqService.refreshRequests();
    this.reqService.refreshEmployees();
  }



  populateForm(request : Request)
  {
    console.log(request);

    var datePipe = new DatePipe("en-UK");
    let formatedDate : any = datePipe.transform(request.FromDate, 'yyyy-MM-dd');
    request.FromDate = formatedDate;
    formatedDate = datePipe.transform(request.ToDate, 'yyyy-MM-dd');
    request.ToDate = formatedDate;
    this.reqService.formData = Object.assign({},request);
    this.router.navigate(['admin/addeditrequest']);
  }


  updateRequest(requestId : number)
  {
    console.log(requestId);
    this.router.navigate(['admin/addeditrequest',requestId]);    
  }
}
