import { AssessorBase } from "./assessor-base";

export class AssessorPersonalDetail extends AssessorBase
{
    Name: string = null;
    Gender: string = null;
    DOB?: Date = null;
    MaritalStatus?: boolean = null;
    FatherName?: string = null;
    MotherName?: string = null;
}