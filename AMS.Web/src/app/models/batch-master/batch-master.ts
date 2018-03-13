import { BatchDetails } from "./batch-details";
import { BatchAllocationDetail } from "../batch-allocation/batch-allocation-detail";

export class BatchMaster 
{
    constructor(){
        this.BatchDetails = new BatchDetails();
        this.BatchAllocationDetails = new BatchAllocationDetail();
    };

    Id: number;
    BatchId: string = null;
    BatchName?: string = null;

    //All other batch details except BatchId and BatchName
    BatchDetails : BatchDetails = null;

    //Batch-Allocation details 
    BatchAllocationDetails: BatchAllocationDetail

    CreatedDate? : Date = null;
    CreatedBy? : number = null;
    ModifiedDate? : Date = null;
    ModifiedBy? : number = null;
    IsActive : boolean = true;
}
