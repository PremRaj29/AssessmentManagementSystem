import { AssessorBase } from "./assessor-base";

export class AssessorCommunicationDetail extends AssessorBase
{    
    StateId?: number = null;
    CityId?: number = null;
    CityName?: string = null;
    StateName?: string = null;

    OtherLocalityName?: string = null;
    EmailId: string = null;
    MobileNo: string = null;
    WhatsAppOnPrimaryNo?: boolean = null;
    WhatsAppNo?: string = null;
    
    SecondaryEmailId?: string = null;
    SecondaryMobileNo?: string = null;
    LandlineNo?: string = null;
    EmergancyContactNo1?: string = null;
    EmergancyContactNo2?: string = null;
    
    CommAddressLine1?: string = null;
    CommAddressLine2?: string = null;
    CommAddressLine3?: string = null;
    CommAddressPinCode?: string = null;
    HasSameAsCommAddress?: boolean = null;
    PermanentAddressLine1?: string = null;
    PermanentAddressLine2?: string = null;
    PermanentAddressLine3?: string = null;
    PermanentAddressPinCode?: string = null;
}
