//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute,Params } from '@angular/router';
import { OperationStatus } from '../../../models/shared/operation-status';

// import Domain class
import { BatchMaster } from '../../../models/batch-master/batch-master';
import { BatchMasterResponse } from '../../../models/batch-master/batch-master-response';

// import required services for this component
import { BatchMasterService } from '../../../services/batch-master/batch-master.service';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-modify-batch-master',
  templateUrl: './modify-batch-master.component.html',
  styleUrls: ['./modify-batch-master.component.css']
})
export class ModifyBatchMasterComponent implements OnInit {

  //default batch-master object
  batchMaster: BatchMaster = new BatchMaster();

  formSubmitted: boolean = false;
  isReadOnlyMode: number = 1;
  isDataLoadingCompleted: boolean = true;
  isFormDataSubmissionCompleted: boolean = null;

  constructor(private batchMasterService: BatchMasterService, private router: Router,private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((routeData: Params) => {
      this.loadBatchMasterDetails(routeData['id']);
    });
  }

  loadBatchMasterDetails(batchMasterId: number) {
    // here get Question obserable
    let observable = this.batchMasterService.getBatchMasterDetails(batchMasterId)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (batchMasterResponse: BatchMasterResponse) => {
        //debugger;

        // if service has returned valid response then only
        if (batchMasterResponse != null
          && batchMasterResponse.OperationStatus.RequestSuccessful == true
          && batchMasterResponse.BatchMaster.length > 0
        ) {
          this.batchMaster = batchMasterResponse.BatchMaster[0];
          //console.log(batchMasterResponse);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while getting details of BatchMaster: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('BatchMaster details loading completed'); subscription.unsubscribe(); }
      );
  }

  public modifyJobRole() {
    //local reference
    let batchMasterDetails = this.batchMaster.BatchDetails;

    if (!(this.batchMaster.BatchId != null
      && batchMasterDetails.SchemeId > 0 && batchMasterDetails.JobRoleId > 0
      && batchMasterDetails.CityId > 0 && batchMasterDetails.VTP_Id > 0)) 
    {
      return false;
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.batchMasterService.modifyBatchMaster(this.batchMaster)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (batchMasterResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (batchMasterResponse != null) 
        {
          if (batchMasterResponse.RequestSuccessful) 
          {
            //response meesage directive will be used to show/display on form
            //this.formProcessStatus = 'BatchMaster successfully submitted';
            alert('BatchMaster successfully submitted');
          }
          else 
          {
            let returnedMessages = batchMasterResponse.Messages;
            // show error message on screen
            if (returnedMessages != null && returnedMessages.length > 0) 
            {
              //this.formProcessStatus = returnedMessages[0].Text;
              alert(returnedMessages[0].Text);
            }
          }
        }

      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while posting data for JobRoles: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('BatchMaster successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public readOnlyModeChanged() {
    //reset form-submitted status
    this.formSubmitted = false;
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

}

//#endregion