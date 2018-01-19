import { BatchDetails } from "./batch-details";

export class BatchMaster 
{
    constructor(){
        this.BatchDetails = new BatchDetails();
    };

    Id: number;
    BatchId: string = null;
    BatchName?: string = null;
    //All other batch details except BatchId and BatchName
    BatchDetails : BatchDetails = null;

    CreatedDate? : Date = null;
    CreatedBy? : number = null;
    ModifiedDate? : Date = null;
    ModifiedBy? : number = null;
    IsActive : boolean = true;
}
