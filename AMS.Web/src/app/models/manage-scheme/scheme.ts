export class Scheme 
{
    Id: number;
    Code : string = null;
    Name : string = null;
    Description? : string = null;
    
    CreatedDate? : Date = null;
    CreatedBy? : number = null;
    ModifiedDate? : Date = null;
    ModifiedBy? : number = null;
    IsActive : boolean = true;
}