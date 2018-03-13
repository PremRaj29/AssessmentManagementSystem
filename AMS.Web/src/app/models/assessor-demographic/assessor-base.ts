export class AssessorBase 
{
    constructor(){};

    Id: number;
    AssessorId?: number = null;

    //5s columns
    CreatedDate?: Date = null;
    CreatedBy?: number = null;
    ModifiedDate?: Date = null;
    ModifiedBy?: number = null;
    IsActive: boolean = true;
}
