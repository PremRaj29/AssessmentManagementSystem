import { BaseResponse } from "../shared/base-response";
import { AssessorOtherDetail } from "./assessor-other-detail";


export class OtherDetailsResponse extends BaseResponse
{
    //#region Constructor

    public OtherDetailsResponse()
    {
        this.OtherDetails = new Array<AssessorOtherDetail>();
    }

    //#endregion Constructor

    //#region Class Properties

    OtherDetails:Array<AssessorOtherDetail>;

    //#endregion
}
