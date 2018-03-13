import { BaseResponse } from "../shared/base-response";
import { Assessor } from "./assessor";

export class AssessorResponse extends BaseResponse
{
    //#region Constructor

    public AssessorResponse()
    {
        this.Assessor = new Array<Assessor>();
    }

    //#endregion Constructor

    //#region Class Properties

    Assessor:Array<Assessor>;

    //#endregion
}
