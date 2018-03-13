import { Assessor } from "../assessor-demographic/assessor";

export class BatchAllocationDetail 
{
    constructor(){
        this.Assessor = new Assessor();
    }

    BatchMasterId: number = null;
    BatchId: string = null;
    BatchName: string = null;
    BatchAllocationId: number = null;

    AssessmentDate?: Date;
    AssessmentTiming?: boolean = null;
    Assessor: Assessor;
}
