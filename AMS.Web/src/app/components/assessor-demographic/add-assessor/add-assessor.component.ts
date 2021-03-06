//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { OperationStatus } from '../../../models/shared/operation-status';

// import Domain class
import { Assessor } from '../../../models/assessor-demographic/assessor';

// import required services for this component
import { AssessorService } from '../../../services/assessor-demographic/assessor.service';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-add-assessor',
  templateUrl: './add-assessor.component.html',
  styleUrls: ['./add-assessor.component.css']
})
export class AddAssessorComponent implements OnInit {

  //default batch-master object
  assessor: Assessor = new Assessor();
  
  formSubmitted: boolean = false;
  isFormDataSubmissionCompleted: boolean = null;
  selectedTab : number = 0;
  disableFormSubmit: number = 0;

  constructor(private assessorService: AssessorService) { }

  ngOnInit() {
  }

  //#region event handlers

  setSelectedTab(tabIndex)
  {
    //alert('Tab Changed :'+tabIndex);
    this.selectedTab = tabIndex;
  }

  public submitAssessorBasicDetails() {
    debugger;

    //local reference
    let assessor = this.assessor;

    /**
     * comment : here make sure if user manipulate html "Disable" property of element then 
     * reject request if it's invalid for form data submission
     */
    if (this.disableFormSubmit == 1 || 
        !(assessor.IRIS_Id != null && assessor.IRIS_Id != '') )
    {
      return false;
    }
    else {
      //prepare typed object 
      //batchData.BatchId = assessor.BatchId
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.assessorService.addAssessor(assessor);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (assessorResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (assessorResponse.RequestSuccessful) {
          //response meesage directive will be used to show/display on form
          alert('Assessor primary details successfully submitted');

          //explicilty not clearing this form
          this.disableFormSubmit = 1;

          //comment : Here set "AssessorId" for all other tabs
          this.assessor.AssessorId = assessorResponse.RecordKey;
          this.assessor.Id = assessorResponse.RecordKey;
          //it's need to be braodcasted to all Subsribers

        }
        else {
          let returnedMessages = assessorResponse.Messages;
          // show error message on screen
          if (returnedMessages != null && returnedMessages.length > 0) {
            alert(returnedMessages[0].Text);
          }
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while posting data for Assessor: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('Assessor primary details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public resetFormDetails() {

    this.assessor = new Assessor();

    //also set form-submitted status
    this.formSubmitted = false;
  }

  //#endregion
}

//#endregion