//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

// import Domain class
//import { BatchMaster } from '../../models/batch-master/batch-master';
import { SearchAssessorParams } from '../../../models/batch-master/search-assessor-params';

//import required components
import {BatchDetailsComponent} from './batch-details/batch-details.component';

// import required services for this component
import { BatchMasterService } from '../../../services/batch-master/batch-master.service';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-batch-allocation',
  templateUrl: './batch-allocation.component.html',
  styleUrls: ['./batch-allocation.component.css']
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

  constructor(private batchMasterService: BatchMasterService) { }

  ngOnInit() {
  }

  //#region component event handlers methods

  public searchBatchMaster() 
  {
    //debugger;
    if(this.batchSearchedValue != null && this.batchSearchedValue != '')
    {

      this.childCompBatchDetailsComponent.loadBatchMasterDetails(
        (this.batchSearchType == 1 ? this.batchSearchedValue: null)
        ,(this.batchSearchType == 2 ? this.batchSearchedValue: null)
      );

      // if(this.batchSearchType == 1)
      // {
      //   this.childCompBatchDetailsComponent.loadBatchMasterDetails(this.batchSearchedValue,null);
      // }
      // else if(this.batchSearchType == 2)
      // {
      //   this.childCompBatchDetailsComponent.loadBatchMasterDetails(this.batchSearchedValue,null);
      // }
    }
  }

  public searchAssessorForBatchAllocation()
  {

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
    alert('Searched BatchMasterId : '+ this.searchedBatchMasterId);
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