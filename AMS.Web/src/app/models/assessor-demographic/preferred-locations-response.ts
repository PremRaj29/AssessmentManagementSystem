import { BaseResponse } from "../shared/base-response";
import { AssessorPreferredLocation } from "./assessor-preferred-location";


export class PreferredLocationsResponse extends BaseResponse
{
    //#region Constructor

    public PreferredLocationsResponse()
    {
        this.PreferredLocations = new Array<AssessorPreferredLocation>();
    }

    //#endregion Constructor

    //#region Class Properties

    PreferredLocations:Array<AssessorPreferredLocation>;

    //#endregion
}
