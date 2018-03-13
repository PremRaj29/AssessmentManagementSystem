//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { OperationStatus } from '../../../../models/shared/operation-status';

// import Domain class
import { AssessorOtherDetail } from '../../../../models/assessor-demographic/assessor-other-detail';

// import required services for this component
import { AssessorOtherDetailService } from '../../../../services/assessor-demographic/assessor-other-detail.service';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-accessor-other-detail',
  templateUrl: './other-detail.component.html',
  styleUrls: ['./other-detail.component.css'],
  providers:[AssessorOtherDetailService]
})
export class OtherDetailComponent implements OnInit {
  
  //interact with input & output of this components
  @Input('disableFormSubmit') disableFormSubmit: number = 1;
  @Input('assessorId') assessorId: number = null;
  @Input('isModifyState') isModifyState: boolean = false;
  /**
   * comment : here purpose of this input is basically sending all data from parent service to fill all child tabs data in ONE-GO on page-load
   */
  @Input('assessorOtherDetailFromParent') assessorOtherDetail: AssessorOtherDetail = new AssessorOtherDetail();


  //default batch-master object
  //assessorOtherDetail: AssessorOtherDetail = new AssessorOtherDetail();
  
  formSubmitted: boolean = false;
  isFormDataSubmissionCompleted: boolean = null;
  selectedTab : number = 0;

  constructor(private assessorOtherDetailService: AssessorOtherDetailService) { }

  ngOnInit() {
  }

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

  public submitAssessorOtherDetails() {
    debugger;

    //local reference
    let otherDetail = this.assessorOtherDetail;
    otherDetail.AssessorId = this.assessorId;  //recieved from Parent component

    /**
     * comment : here make sure if user manipulate html "DISABLE" property/attribute of element then 
     * reject request if it's invalid for form data submission
     */
    if (this.disableFormSubmit == 1 || !(this.hasValidValue(otherDetail.AssessorId)))
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
                    this.assessorOtherDetailService.modifyAssessorOtherDetail(otherDetail) : 
                    this.assessorOtherDetailService.addAssessorOtherDetail(otherDetail);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedJobRoleResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedJobRoleResponse.RequestSuccessful) {
          //response meesage directive will be used to show/display on form
          alert('Assessor other details successfully submitted');

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
      (error: string) => console.log('error while posting data for AssessorOtherDetails: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('Assessor other details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public resetFormDetails() {

    this.assessorOtherDetail = new AssessorOtherDetail();

    //also set form-submitted status
    this.formSubmitted = false;
  }

  //#endregion
}

//#endregion