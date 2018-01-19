export class SearchBatchMasterRequestParams 
{
    BatchId: string = null;
    BatchName: string = null;

    //#region All other details

    SchemeId: number = 0;
    //SchemeName: number = 0;
    JobRoleId: number = 0;
    CityId: number = 0;    
    VTP_Id: number = 0;
    TotalCandidates: number = 0;

    //#endregion

    IsActive: boolean = true;
}