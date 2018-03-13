import { BaseResponse } from "../shared/base-response";
import { AssessorJobRole } from "./assessor-job-role";

export class JobRolesResponse extends BaseResponse
{
    //#region Constructor

    public JobRolesResponse()
    {
        this.JobRoles = new Array<AssessorJobRole>();
    }

    //#endregion Constructor

    //#region Class Properties

    JobRoles:Array<AssessorJobRole>;

    //#endregion
}
