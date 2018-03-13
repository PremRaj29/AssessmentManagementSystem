import { AssessorBase } from "./assessor-base";

export class AssessorIdProofDetail extends AssessorBase
{
    IdProofTypeId: number = null;
    IdProofName: string = null;
    UniqueNumber: string = null;
    NameOnDocument?: string = null;
    DocumentFileName?: string = null;

    //additional param
    UploadedIdProofDocFile?: File = null;
    UploadedIdProofDocFileName?: string = null;
}
