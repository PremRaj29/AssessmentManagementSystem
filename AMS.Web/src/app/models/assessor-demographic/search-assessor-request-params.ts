export class SearchAssessorRequestParams 
{
    //primary details
    AssessorId: number = null;
    IRIS_Id: string = null;
    SSC_Id: string = null;
    NSDC_Id: string = null;

    //other primary search params
    Name?: string = null;
    Gender?: string = null;
    EmailId?: string = null;
    MobileNo?: string = null;
    WhatsAppNo?: string = null;
    StateId?: number = null;
    CityId?: number = null;

    //#region all other Advance search params
    SkillCouncilTypeId: number = null;
    SkillCouncilId: number = null;
    JobRoleId: number = null;
    IdProofTypeId: number = null;
    IdProofValue?: string = null;
    AccountNumber?: string = null;
    //#endregion 

    IsActive: boolean = true;
}
