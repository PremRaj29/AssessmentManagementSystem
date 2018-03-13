import { BaseResponse } from "../shared/base-response";
import { AssessorCommunicationDetail } from "./assessor-communication-detail";

export class CommunicationDetailsResponse extends BaseResponse
{
    //#region Constructor

    public CommunicationDetailsResponse()
    {
        this.CommunicationDetails = new Array<AssessorCommunicationDetail>();
    }

    //#endregion Constructor

    //#region Class Properties

    CommunicationDetails:Array<AssessorCommunicationDetail>;

    //#endregion
}
