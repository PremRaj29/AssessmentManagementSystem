export class SearchBatchMatchingAssessorRequestParams 
{
    constructor(){}

    BatchId : string = null;
    BatchName? : string = null;
    AssessorName? : string = null;
    AssessmentDate:Date = null;
    AssessmentTiming: boolean = null ; //Batch Assessment timing like "AM or PM" only
}
