import { SkillCouncil } from './skill-council';
import { OperationStatus } from '../shared/operation-status';

export class SkillCouncilResponse
{
    //#region Constructor

    constructor()
    {
        this.SkillCouncil = new Array<SkillCouncil>();
        this.OperationStatus = new OperationStatus();
    }

    //#endregion Constructor

    //#region Class Properties

    SkillCouncil: Array<SkillCouncil>;

    OperationStatus: OperationStatus;

    //#endregion
}