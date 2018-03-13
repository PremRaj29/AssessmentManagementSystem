import { OperationStatus } from "./operation-status";

export class BaseResponse 
{
    //#region Constructor

    public BatchMasterResponse()
    {
        this.OperationStatus = new OperationStatus();
    }

    //#endregion Constructor

    //#region Class Properties

    OperationStatus:OperationStatus;

    //#endregion
}
