import { State } from "./state";
import { City } from "./city";
import { OperationStatus } from "../shared/operation-status";

export class GeographyResponse 
{
    //#region Constructor
    
    public GeographyResponse()
    {
        this.States = new Array<State>();
        this.Cities = new Array<City>();

        this.OperationStatus = new OperationStatus();
    }
    //#endregion Constructor

    //#region Class Properties

    States: Array<State>;

    Cities:Array<City>;

    OperationStatus: OperationStatus

    //#endregion
}
