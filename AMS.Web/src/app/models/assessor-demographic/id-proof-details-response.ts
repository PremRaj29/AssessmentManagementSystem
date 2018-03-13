import { BaseResponse } from "../shared/base-response";
import { AssessorIdProofDetail } from "./assessor-id-proof-detail";

export class IdProofDetailsResponse extends BaseResponse
{
    //#region Constructor

    public IdProofDetailsResponse()
    {
        this.IdProofDetails = new Array<AssessorIdProofDetail>();
    }

    //#endregion Constructor

    //#region Class Properties

    IdProofDetails:Array<AssessorIdProofDetail>;

    //#endregion
}
