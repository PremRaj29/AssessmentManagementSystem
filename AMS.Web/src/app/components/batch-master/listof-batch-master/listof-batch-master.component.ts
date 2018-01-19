//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

// import reuired services for this component
import {BatchMasterService} from '../../../services/batch-master/batch-master.service';
import { BatchMasterResponse } from '../../../models/batch-master/batch-master-response';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-listof-batch-master',
  templateUrl: './listof-batch-master.component.html',
  styleUrls: ['./listof-batch-master.component.css']
})
export class ListofBatchMasterComponent implements OnInit {
  
    //#region component global level propertie/variables/models declaration & initlizations
  
    @Output('selectedBatchMaster') selectedBatchMaster = new EventEmitter<string>();
    isDataLoadingCompleted: boolean = true;
    searchedBatchMaster: any = null;
  
    //#endregion
  
    //#region constructor and OnInit implementation
  
    constructor(private batchMasterService: BatchMasterService, private router: Router,private route: ActivatedRoute) { }
    
    ngOnInit() { }
  
    //#endregion 
  
    //#region public methods
  
    public searchBatchMaster(batchMasterSearchParams: any)
    {
      //alert('Working Child');
  
      //reset data every time before calling
      this.searchedBatchMaster =  null;
      this.isDataLoadingCompleted = null;
  
      // here get Question obserable
      let observable = this.batchMasterService.searchBatchMaster(batchMasterSearchParams);
  
      let subscription = observable.subscribe
          (
              // calls the onNext() function in the observer
              (batchMasterResponse: BatchMasterResponse) =>
              {
                debugger;
  
                  // if service has returned valid response then only
                  if (batchMasterResponse != null 
                      && batchMasterResponse.OperationStatus.RequestSuccessful == true
                      && batchMasterResponse.BatchMaster.length >0
                    )
                  {
                      this.searchedBatchMaster = batchMasterResponse.BatchMaster;
                      console.log(batchMasterResponse);
                  }
                  else
                  {
                      // show error message on screen
                  }
              },
  
              // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
              // here we can also call our logger service to log this exception
              (error: string) => console.log('error while searching BatchMaster: ' + error),
  
              // calls the onComplete() function in the observer
              () => { this.isDataLoadingCompleted = true; console.log('BatchMaster searching completed'); subscription.unsubscribe(); }
          );
    }
  
    //#endregion 
  
    //#region private methods
    
    onRowClick(event, id) 
    {
      this.selectedBatchMaster.emit(id);
    }
    
    //#endregion
  
  }
  
  //#endregion