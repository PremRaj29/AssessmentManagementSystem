//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { OperationStatus } from '../../../../models/shared/operation-status';

// import Domain class
import { AssessorCommunicationDetail } from '../../../../models/assessor-demographic/assessor-communication-detail';

// import required services for this component
import { AssessorCommunicationDetailService } from '../../../../services/assessor-demographic/assessor-communication-detail.service';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-accessor-communication-detail',
  templateUrl: './communication-detail.component.html',
  styleUrls: ['./communication-detail.component.css'],
  providers: [AssessorCommunicationDetailService]
})
export class CommunicationDetailComponent implements OnInit {
  
  //interact with input & output of this components
  @Input('disableFormSubmit') disableFormSubmit: number = 1;
  @Input('assessorId') assessorId: number = null;
  @Input('isModifyState') isModifyState: boolean = false;
  /**
   * comment : here purpose of this input is basically sending all data from parent service to fill all child tabs data in ONE-GO on page-load
   */
  @Input('assessorCommunicationDetailFromParent') assessorCommunicationDetail: AssessorCommunicationDetail = new AssessorCommunicationDetail();


  //default batch-master object
  //assessorCommunicationDetail: AssessorCommunicationDetail = new AssessorCommunicationDetail();
  
  formSubmitted: boolean = false;
  isFormDataSubmissionCompleted: boolean = null;
  selectedTab : number = 0;

  constructor(private assessorCommunicationDetailService: AssessorCommunicationDetailService) { }

  ngOnInit() {
  }

  //#region Child components event-emitter handler methods
  
  public stateChanged(childData: any) {
    debugger;
    this.assessorCommunicationDetail.StateId = childData;
    console.log('Selected State Id : ' + childData);
  }

  public cityChanged(childData: any) {
    debugger;
    this.assessorCommunicationDetail.CityId = childData;
    console.log('Selected City Id : ' + childData);
  }

  //#endregion

  //#region event handlers

  setSelectedTab(tabIndex)
  {
    //alert('Tab Changed :'+tabIndex);
    this.selectedTab = tabIndex;
  }

  hasValidValue(value)
  {
    let hasValid = false;

    if( value ) {
      hasValid = true;
    }

    return hasValid;
  }

  public submitAssessorCommunicationDetails() {
    debugger;

    //local reference
    let communicationDetail = this.assessorCommunicationDetail;
    communicationDetail.AssessorId = this.assessorId;  //recieved from Parent component

    /**
     * comment : here make sure if user manipulate html "DISABLE" property/attribute of element then 
     * reject request if it's invalid for form data submission
     */
    if (this.disableFormSubmit == 1 ||
          !(            
            this.hasValidValue(communicationDetail.AssessorId)
            && this.hasValidValue(communicationDetail.EmailId)
            && this.hasValidValue(communicationDetail.MobileNo)
            && this.hasValidValue(communicationDetail.CityId)
          )
       )
    {
      return false;
    }
    else {
      //prepare typed object 
      //batchData.BatchId = assessor.BatchId
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get assessor-service obserable
    let observable = (this.isModifyState) ? 
                    this.assessorCommunicationDetailService.modifyAssessorCommunicationDetail(communicationDetail) : 
                    this.assessorCommunicationDetailService.addAssessorCommunicationDetail(communicationDetail);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedJobRoleResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedJobRoleResponse.RequestSuccessful) {
          //response meesage directive will be used to show/display on form
          alert('Assessor communication details successfully submitted');

          //Only when "Addition" mode is 
          if(this.isModifyState)
          {
            this.disableFormSubmit = 0;
          }
        }
        else {
          let returnedMessages = searchedJobRoleResponse.Messages;
          // show error message on screen
          if (returnedMessages != null && returnedMessages.length > 0) {
            alert(returnedMessages[0].Text);
          }
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while posting data for AssessorCommunicationDetails: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('Assessor communication details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public resetFormDetails() {

    this.assessorCommunicationDetail = new AssessorCommunicationDetail();

    //also set form-submitted status
    this.formSubmitted = false;
  }

  /**
   * Eigther MobileNo model updates or "WhatsApp On Primary - YES/NO" selected fire this event to reduce User data-filling effort
   */
  public replicateMobileNo()
  {
    //debugger;
    if(this.assessorCommunicationDetail.WhatsAppOnPrimaryNo == true)
    {
      this.assessorCommunicationDetail.WhatsAppNo = this.assessorCommunicationDetail.MobileNo;
    }
  }

  /**
   * Eigther MobileNo model updates or "WhatsApp On Primary - YES/NO" selected fire this event to reduce User data-filling effort
   */
  public replicateCommunicationAddress()
  {
    //debugger;
    if(this.assessorCommunicationDetail.HasSameAsCommAddress == true)
    {
      this.assessorCommunicationDetail.PermanentAddressLine1 = this.assessorCommunicationDetail.CommAddressLine1;
      this.assessorCommunicationDetail.PermanentAddressLine2 = this.assessorCommunicationDetail.CommAddressLine2;
      this.assessorCommunicationDetail.PermanentAddressLine3 = this.assessorCommunicationDetail.CommAddressLine3;
      this.assessorCommunicationDetail.PermanentAddressPinCode = this.assessorCommunicationDetail.CommAddressPinCode;
    }
  }

  //#endregion
}

//#endregion