export class Request
{
    Requestid : number ;
    TravelCause : string;
    Source : string ;
    Destination  : string ;
    Mode  : string ;
    FromDate : Date; 
    ToDate : Date;
    NoDays : number = 0;
    Priority  : string ;
    ProjectId : number ;
    EmpId  : number ;
    Status   : string ;
}