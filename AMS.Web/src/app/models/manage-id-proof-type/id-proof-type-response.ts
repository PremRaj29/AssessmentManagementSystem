import { OperationStatus } from "../shared/operation-status";
import { IdProofType } from "./id-proof-type";

export class IdProofTypeResponse 
{
    //#region Constructor

    constructor()
    {
        this.IdProofTypes = new Array<IdProofType>();
        this.OperationStatus = new OperationStatus();
    }

    //#endregion Constructor

    //#region Class Properties

    IdProofTypes: Array<IdProofType>;

    OperationStatus: OperationStatus;

    //#endregion
}