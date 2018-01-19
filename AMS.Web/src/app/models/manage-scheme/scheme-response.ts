import { OperationStatus } from "../shared/operation-status";
import { Scheme } from "./scheme";

export class SchemeResponse 
{
    //#region Constructor

    public SchemeResponse()
    {
        this.Scheme = new Array<Scheme>();
        this.OperationStatus = new OperationStatus();
    }

    //#endregion Constructor

    //#region Class Properties

    Scheme: Array<Scheme>;

    OperationStatus: OperationStatus;

    //#endregion
}