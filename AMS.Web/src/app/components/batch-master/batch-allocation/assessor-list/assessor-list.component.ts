//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

// import reuired services for this component
import {BatchAllocationService} from '../../../../services/batch-master/batch-allocation.service';
import { BatchMasterResponse } from '../../../../models/batch-master/batch-master-response';
import { BatchMatchingAssessorResponse } from '../../../../models/batch-allocation/batch-matching-assessor-response';
import { SearchBatchMatchingAssessorRequestParams } from '../../../../models/batch-allocation/search-batch-matching-assessor-request-params';
import { OperationStatus } from '../../../../models/shared/operation-status';
import { BatchAllocation } from '../../../../models/batch-allocation/batch-allocation';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-batch-matching-assessor-list',
  templateUrl: './assessor-list.component.html',
  styleUrls: ['./assessor-list.component.css']
})
export class AssessorListComponent implements OnInit {
  
  //#region component global level propertie/variables/models declaration & initlizations
  @Input('searchedBatchMasterId') searchedBatchMasterId: number = null;
  @Output('selectedAssessorId') selectedAssessorId = new EventEmitter<string>();
  isDataLoadingCompleted: boolean = true;
  searchedBatchMatchingAssessor: any = null;
  assessorBatchAllocationSearchParams: SearchBatchMatchingAssessorRequestParams;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private batchAllocationService: BatchAllocationService, private router: Router,private route: ActivatedRoute) { }
  
  ngOnInit() { }

  //#endregion 

  //#region public methods

  public searchBatchMatchingAssessor(batchAssessorSearchParams: SearchBatchMatchingAssessorRequestParams)
  {
    debugger;
    //alert('Working Child');

    //reset data every time before calling
    this.searchedBatchMatchingAssessor =  null;
    this.isDataLoadingCompleted = null;
    this.assessorBatchAllocationSearchParams = batchAssessorSearchParams; 

    // here get Question obserable
    let observable = this.batchAllocationService.searchBatchMatchingAssessors(batchAssessorSearchParams);

    let subscription = observable.subscribe
        (
            // calls the onNext() function in the observer
            (batchMatchingAssessorResponse: BatchMatchingAssessorResponse) =>
            {
              debugger;

                // if service has returned valid response then only
                if (batchMatchingAssessorResponse != null 
                    && batchMatchingAssessorResponse.OperationStatus.RequestSuccessful == true
                    && batchMatchingAssessorResponse.Assessors.length >0
                  )
                {
                    this.searchedBatchMatchingAssessor = batchMatchingAssessorResponse.Assessors;
                    //console.log(batchMatchingAssessorResponse);
                }
                else
                {
                    // show error message on screen
                }
            },

            // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
            // here we can also call our logger service to log this exception
            (error: string) => console.log('error while searching Batch Matching Assessor: ' + error),

            // calls the onComplete() function in the observer
            () => { this.isDataLoadingCompleted = true; console.log('BatchMatchingAssessor searching completed'); subscription.unsubscribe(); }
        );
  }

  public allocateAssessorOnBatch(assessorId: number)
  {
    debugger;
    let batchAllocation = new BatchAllocation();

    if (!(assessorId >0))
    {
      return false;
    }
    else
    {
      let confirmStatus = confirm('Are you sure want to Allocate/Map this assessor on selected Batch ?');

      if(!confirmStatus)
      {
        return false;
      }
      else
      {
        //set all required porpertie before Posting data
        batchAllocation.AssessorId = assessorId;
        batchAllocation.BatchMasterId = this.searchedBatchMasterId;
        batchAllocation.AssessmentDate = this.assessorBatchAllocationSearchParams.AssessmentDate;
        batchAllocation.Timing = this.assessorBatchAllocationSearchParams.AssessmentTiming;
        batchAllocation.BatchId = this.assessorBatchAllocationSearchParams.BatchId;
        batchAllocation.BatchName = this.assessorBatchAllocationSearchParams.BatchName;
      }
    }

    //reset data every time before calling
    this.isDataLoadingCompleted = false;

    // here get Question obserable
    let observable = this.batchAllocationService.addBatchAllocation(batchAllocation);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (assessorResponse: OperationStatus) => 
      {
        //debugger;

        // if service has returned valid response then only
        if (assessorResponse != null && assessorResponse.RequestSuccessful == true) 
        {
          //here reload "Assessor JobRole" after submission/add operation
          console.log(assessorResponse);

          alert('Assessor has been allocated/mapped successfuly.');
        }
        else {
          // show error message on screen
          alert(assessorResponse.Messages[0].Text);
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => { console.log('error while submitting data for AssessorBatchAllocation: ' + error); alert(error); },

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('AssessorBatchAllocation details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  //#endregion 

  //#region private methods
  
  onRowClick(event, id) 
  {
    //this.selectedBatchMaster.emit(id);
  }
  
  //#endregion

}

//#endregion