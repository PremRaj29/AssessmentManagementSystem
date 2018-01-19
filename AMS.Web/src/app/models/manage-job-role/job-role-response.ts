import { OperationStatus } from "../shared/operation-status";
import { JobRole } from "./job-role";

export class JobRoleResponse 
{
    //#region Constructor

    constructor()
    {
        this.JobRoles = new Array<JobRole>();
        this.OperationStatus = new OperationStatus();
    }

    //#endregion Constructor

    //#region Class Properties

    JobRoles: Array<JobRole>;

    OperationStatus: OperationStatus;

    //#endregion
}
