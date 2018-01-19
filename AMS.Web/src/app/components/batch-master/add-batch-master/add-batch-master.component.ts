//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { OperationStatus } from '../../../models/shared/operation-status';

// import Domain class
import { BatchMaster } from '../../../models/batch-master/batch-master';

// import required services for this component
import { BatchMasterService } from '../../../services/batch-master/batch-master.service';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-add-batch-master',
  templateUrl: './add-batch-master.component.html',
  styleUrls: ['./add-batch-master.component.css']
})
export class AddBatchMasterComponent implements OnInit {
  
    //default batch-master object
    batchMaster: BatchMaster = new BatchMaster();
  
    formSubmitted: boolean = false;
    isFormDataSubmissionCompleted: boolean = null;
  
    constructor(private batchMasterService: BatchMasterService) { }
  
    ngOnInit() {
    }
  
    //#region Child components event-emitter handler methods
  
    public councilTypeChanged(childData: any) {
      debugger;
      this.batchMaster.BatchDetails.SkillCouncilTypeId = childData;
      console.log('Selected CouncilType Id : ' + childData);
    }
  
    public skillCouncilChanged(childData: any) {
      debugger;
      this.batchMaster.BatchDetails.SkillCouncilId = childData;
      console.log('Selected SkillCouncil Id : ' + childData);
    }
  
    public jobRoleChanged(childData: any) {
      debugger;
      this.batchMaster.BatchDetails.JobRoleId = childData;
      console.log('Selected JobRole Id : ' + childData);
    }
  
    public schemeChanged(childData: any) {
      debugger;
      this.batchMaster.BatchDetails.SchemeId = childData;
      console.log('Selected Scheme Id : ' + childData);
    }
  
    public vtpChanged(childData: any) {
      debugger;
      this.batchMaster.BatchDetails.VTP_Id = childData;
      console.log('Selected VTP Id : ' + childData);
    }
  
    public stateChanged(childData: any) {
      debugger;
      this.batchMaster.BatchDetails.StateId = childData;
      console.log('Selected State Id : ' + childData);
    }
  
    public cityChanged(childData: any) {
      debugger;
      this.batchMaster.BatchDetails.CityId = childData;
      console.log('Selected City Id : ' + childData);
    }
  
    //#endregion
  
    public submitBatchMaster() {
      debugger;
  
      //local reference
      let batchMaster = this.batchMaster;
  
      if (!(batchMaster.BatchId != null && batchMaster.BatchDetails.JobRoleId != null && batchMaster.BatchDetails.SchemeId != null
        && batchMaster.BatchDetails.VTP_Id != null && batchMaster.BatchDetails.CityId != null
        && batchMaster.BatchDetails.TotalCandidates != null)
      ) {
        return false;
      }
      else {
        //prepare typed object 
        //batchData.BatchId = batchMaster.BatchId
      }
  
      //reset data every time before calling
      this.isFormDataSubmissionCompleted = false;
  
      // here get Question obserable
      let observable = this.batchMasterService.addBatchMaster(batchMaster);
  
      let subscription = observable.subscribe
        (
        // calls the onNext() function in the observer
        (searchedJobRoleResponse: OperationStatus) => {
          debugger;
  
          // if service has returned valid response then only
          if (searchedJobRoleResponse.RequestSuccessful) {
            //response meesage directive will be used to show/display on form
            alert('BatchMaster details successfully submitted');
  
            // reset form other mandatory data
            this.resetFormDetails();
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
        (error: string) => console.log('error while posting data for BatchMaster: ' + error),
  
        // calls the onComplete() function in the observer
        () => { this.isFormDataSubmissionCompleted = true; console.log('BatchMaster details successfully submitted'); subscription.unsubscribe(); }
        );
    }
  
    public resetFormDetails() {
  
      this.batchMaster = new BatchMaster();
      // this.batchMaster = {
      //   BatchId: null,
      //   BatchName: null,
      //   SkillCouncilTypeId: 0,
      //   SkillCouncilId: null,
      //   JobRoleId: null,
      //   SchemeId: null,
      //   VtpId: null,
      //   StateId: null,
      //   CityId: null,
      //   TotalCandidates: null,
      //   //VTP details
      //   VtpSpocName:null,
      //   VtpSpocEmail:null,
      //   VtpSpocMobile:null,
      //   VtpAddress:null,
      //   //Centre SPOC details
      //   CentreSpocName:null,
      //   CentreSpocEmail:null,
      //   CentreSpocMobile:null,
      // };
  
      //also set form-submitted status
      this.formSubmitted = false;
    }
  
  }

  //#endregion