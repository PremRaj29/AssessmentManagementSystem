export class BatchDetails 
{
    constructor(){};

    BatchMasterId: number = null;
    SchemeId: number = null;
    JobRoleId: number = null;    
    CityId: number = null;
    District?: string = null;
    TotalCandidates: number = null;

    SchemeName?: string = null;
    JobRoleName?: string = null;
    CityName?: string = null;
    StateName?: string = null;

    //VTP SPOC related details
    VTP_Id: number = null;
    VTP_Name?: string = null;
    VTP_SPOC_Name?: string = null;
    VTP_SPOC_Email?: string = null;
    VTP_SPOC_Mobile?: string = null;
    VTP_SPOC_Mobile2?: string = null;
    VTP_SPOC_AlternativeNo?: string = null;
    VTP_Address?: string = null;

    //Centre SPOC related details
    Centre_SPOC_Name?: string = null;
    Centre_SPOC_Email?: string = null;
    Centre_SPOC_Mobile?: string = null;

    //additional UI required fields 
    SkillCouncilTypeId?: number = 0;
    SkillCouncilId?: number = null;
    StateId?: number = null;
}
