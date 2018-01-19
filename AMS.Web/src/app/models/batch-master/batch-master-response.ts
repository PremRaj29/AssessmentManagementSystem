import { BatchMaster } from "./batch-master";
import { OperationStatus } from "../shared/operation-status";

export class BatchMasterResponse 
{
    //#region Constructor

    public BatchMasterResponse()
    {
        this.BatchMaster = new Array<BatchMaster>();
        this.OperationStatus = new OperationStatus();
    }

    //#endregion Constructor

    //#region Class Properties

    BatchMaster:Array<BatchMaster>;

    OperationStatus:OperationStatus;

    //#endregion
}
