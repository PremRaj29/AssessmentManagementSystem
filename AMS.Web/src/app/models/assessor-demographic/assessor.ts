import { AssessorBase } from "./assessor-base";
import { AssessorPersonalDetail } from "./assessor-personal-detail";
import { AssessorCommunicationDetail } from "./assessor-communication-detail";
import { AssessorOtherDetail } from "./assessor-other-detail";
import { AssessorIdProofDetail } from "./assessor-id-proof-detail";
import { AssessorJobRole } from "./assessor-job-role";
import { AssessorPreferredLocation } from "./assessor-preferred-location";

export class Assessor extends AssessorBase {
    constructor(){        
        super();
        
        this.PerosnalDetail = new AssessorPersonalDetail();
        this.CommunicationDetail = new AssessorCommunicationDetail();
        this.OtherDetail = new AssessorOtherDetail();
        this.IdProofs = Array<AssessorIdProofDetail>();
        this.JobRoles = new Array<AssessorJobRole>();
        this.PreferredLocations = new Array<AssessorPreferredLocation>();
    };

    IRIS_Id: string = null;
    SSC_Id: string = null;
    NSDC_Id: string = null;

    //#region All other Assessors related details

    /**
     * Assessor basic personal details e.g. FName, DOB, Marital Status etc
     */
    PerosnalDetail: AssessorPersonalDetail;

    /**
     * Assessor basic personal details e.g. FName, DOB, Marital Status etc
     */
    CommunicationDetail: AssessorCommunicationDetail;

    /**
     * Assessor all other details like OdigoStatus, BankName, Number etc
     */
    OtherDetail: AssessorOtherDetail;

    /**
     * Assessor basic unique identity proofs e.g. Aadhar, DL, VoterId etc
     */
    IdProofs: Array<AssessorIdProofDetail>;

    /**
     * Assessor professional preferred Job-Roles list
     */
    JobRoles: Array<AssessorJobRole>;

    /**
     * Assessor preferred Job-Locations(City) list
     */
    PreferredLocations: Array<AssessorPreferredLocation>;

    //#endregion
}
