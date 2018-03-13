import { BaseResponse } from "../shared/base-response";
import { AssessorPersonalDetail } from "./assessor-personal-detail";


export class PersonalDetailsResponse extends BaseResponse
{
    //#region Constructor

    public PersonalDetailsResponse()
    {
        this.PerosnalDetails = new Array<AssessorPersonalDetail>();
    }

    //#endregion Constructor

    //#region Class Properties

    PerosnalDetails:Array<AssessorPersonalDetail>;

    //#endregion
}
