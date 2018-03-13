import { AssessorBase } from "./assessor-base";

export class AssessorJobRole extends AssessorBase
{    
    SkillCouncilTypeId?: number = 0;
    SkillCouncilId?: number = null;
    JobRoleId: number = null;
    JobRoleName: string = null;
    JobRoleCode: string = null;

    ClientStatus?: boolean = null;
    ClientRemarks?: string = null;
}