import { VocationalTrainingProvider } from "./vtp";
import { OperationStatus } from "../shared/operation-status";

export class VocationalTrainingProviderResponse 
{
    //#region Constructor

    public VocationalTrainingProviderResponse()
    {
        this.VocationalTrainingProvider = new Array<VocationalTrainingProvider>();
        this.OperationStatus = new OperationStatus();
    }

    //#endregion Constructor

    //#region Class Properties

    VocationalTrainingProvider: Array<VocationalTrainingProvider>;

    OperationStatus: OperationStatus;

    //#endregion
}