export class SearchAssessorParams 
{
    AssessorCode: string = null;
    AssessorName: string = null;

    AssessmentDate?: Date = null;
    AssessmentTiming?: boolean = null;
    JobRoleId: number = 0;
    CityId: number = 0;    
    VTP_Id: number = 0;
    TotalCandidates: number = 0;

    IsActive: boolean = true;
}
