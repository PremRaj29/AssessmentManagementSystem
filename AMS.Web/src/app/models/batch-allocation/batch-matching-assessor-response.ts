import { OperationStatus } from "../shared/operation-status";
import { Assessor } from "../assessor-demographic/assessor";

export class BatchMatchingAssessorResponse
{
    //#region Constructor

    public BatchAllocationResponse()
    {
        this.Assessors = new Array<Assessor>();
        this.OperationStatus = new OperationStatus();
    }

    //#endregion Constructor

    //#region Class Properties

    Assessors:Array<Assessor>;

    OperationStatus:OperationStatus;

    //#endregion
}
