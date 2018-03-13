//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

// import Domain class
//import { BatchMaster } from '../../models/batch-master/batch-master';
import { SearchAssessorParams } from '../../../models/batch-master/search-assessor-params';

//import required components
import {BatchDetailsComponent} from './batch-details/batch-details.component';
import {AssessorListComponent } from './assessor-list/assessor-list.component';

// import required services for this component
import { BatchAllocationService } from '../../../services/batch-master/batch-allocation.service';
import { SearchBatchMatchingAssessorRequestParams } from '../../../models/batch-allocation/search-batch-matching-assessor-request-params';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-batch-allocation',
  templateUrl: './batch-allocation.component.html',
  styleUrls: ['./batch-allocation.component.css'],
  providers:[BatchAllocationService]
})
export class BatchAllocationComponent implements OnInit {

  //default batch-master object
  //batchMaster: BatchMaster = new BatchMaster();

  //searchParams: SearchBatchMasterRequestParams = new SearchBatchMasterRequestParams();
  batchSearchType: number = 0;
  batchSearchedValue: string = '';
  searchedBatchMasterId: number = 0;

  searchBatchFormSubmitted: boolean = false;
  searchBatchAssessorFormSubmitted: boolean = false;
  isDataLoadingCompleted: boolean = false;

  searchAssessorParams: SearchAssessorParams = new SearchAssessorParams();

  // get acess to Child-component
  @ViewChild(BatchDetailsComponent) private childCompBatchDetailsComponent: BatchDetailsComponent;
  @ViewChild(AssessorListComponent) private childCompAssessorListComponent: AssessorListComponent;

  constructor(private batchAllocationService: BatchAllocationService) { }

  ngOnInit() {
  }

  //#region component event handlers methods

  public searchBatchMaster() 
  {
    debugger;
    if(this.batchSearchedValue != null && this.batchSearchedValue != '')
    {
      this.isDataLoadingCompleted = false;

      this.childCompBatchDetailsComponent.loadBatchMasterDetails(
        (this.batchSearchType == 1 ? this.batchSearchedValue: null)
        ,(this.batchSearchType == 2 ? this.batchSearchedValue: null)
      );
    }
  }

  public searchAssessorForBatchAllocation()
  {
    debugger;
    if(this.searchAssessorParams.AssessmentDate != null && this.searchAssessorParams.AssessmentTiming != null)
    {
      let searchBatchAssessorParams = new SearchBatchMatchingAssessorRequestParams();
      searchBatchAssessorParams.BatchId = this.batchSearchedValue;    //need to check in case of "Search BatchName case" ??
      searchBatchAssessorParams.AssessmentDate = this.searchAssessorParams.AssessmentDate;
      searchBatchAssessorParams.AssessmentTiming = this.searchAssessorParams.AssessmentTiming;
      searchBatchAssessorParams.AssessorName = this.searchAssessorParams.AssessorName;

      this.childCompAssessorListComponent.searchBatchMatchingAssessor(searchBatchAssessorParams);
    }
  }

  public resetAssessorSearchPanel()
  {
    //on batch search reset "Assessor Search Panel" explicilty
    this.searchAssessorParams = new SearchAssessorParams();
    this.searchBatchAssessorFormSubmitted = false;
  }

  resetBatchMasterDetails()
  {
    this.searchBatchFormSubmitted = false;
    this.batchSearchedValue = '';
    this.searchedBatchMasterId = 0;
  }

  public parentMethod(childData: any) {
    this.searchedBatchMasterId = childData;

    this.isDataLoadingCompleted = true;
    //alert('Searched BatchMasterId : '+ this.searchedBatchMasterId);
  }


  onItemChange(event) {
    //set selected value 
    this.batchSearchType = event;

    //clear text
    this.resetBatchMasterDetails();
    this.resetAssessorSearchPanel();
  }

  onScheduleTimingChange(event) {
    
  }

  //#endregion
}

//#endregion