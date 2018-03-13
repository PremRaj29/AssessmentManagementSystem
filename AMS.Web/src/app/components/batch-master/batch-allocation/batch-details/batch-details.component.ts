//#region library imports

import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

// import Domain class
import { BatchMaster } from '../../../../models/batch-master/batch-master';
import { BatchMasterResponse } from '../../../../models/batch-master/batch-master-response';

//import required components

// import required services for this component
import { BatchMasterService } from '../../../../services/batch-master/batch-master.service';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-batch-details',
  templateUrl: './batch-details.component.html',
  styleUrls: ['./batch-details.component.css']
})
export class BatchDetailsComponent implements OnInit {

  //interact with input & output of this components
  @Output('searchedBatchMasterId') searchedBatchMasterId = new EventEmitter<number>();

  //default batch-master object
  batchMaster: BatchMaster = new BatchMaster();
  isDataLoadingCompleted: boolean = true;

  constructor(private batchMasterService: BatchMasterService) { }

  ngOnInit() {
  }

  //#region component event handlers methods

  //#region get methods

  loadBatchMasterDetails(batchId: string = null,batchName: string = null) 
  {
    debugger;
    this.batchMaster = new BatchMaster();
    this.searchedBatchMasterId.emit(0);
    this.isDataLoadingCompleted = false;

    // here get Question obserable
    let observable = this.batchMasterService.getBatchMasterDetailsV2(batchId,batchName);

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
          
          //return/emit "BatchMaster" id to Parent component
          this.searchedBatchMasterId.emit(this.batchMaster.Id);
          
          console.log(batchMasterResponse);
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

  //#endregion

  //#endregion

}

