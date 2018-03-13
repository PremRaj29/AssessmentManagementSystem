import { AssessorBase } from "./assessor-base";

export class AssessorPreferredLocation extends AssessorBase
{    
    StateId: number = null;
    CityId: number = null;
    CityName?: string = null;
    StateName?: string = null;
}