export class JobRole 
{
    Id: number;
    SkillCouncilTypeId: number = 0;
    SkillCouncilId?: number = null;
    Code : string = null;
    Name : string = null;
    Description? : string = null;

    SkillCouncilCode?: string = null;
    SkillCouncilName?: string = null;
    CreatedDate? : Date = null;
    CreatedBy? : number = null;
    ModifiedDate? : Date = null;
    ModifiedBy? : number = null;
    IsActive : boolean = true;
}
