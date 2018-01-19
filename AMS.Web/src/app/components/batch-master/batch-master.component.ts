//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { OperationStatus } from '../../models/shared/operation-status';

// import Domain class
import { BatchMaster } from '../../models/batch-master/batch-master';

//import required components
import { ListofBatchMasterComponent } from './listof-batch-master/listof-batch-master.component';

// import required services for this component
import { BatchMasterService } from '../../services/batch-master/batch-master.service';
import { SearchBatchMasterRequestParams } from '../../models/batch-master/search-batch-master-request-params';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-batch-master',
  templateUrl: './batch-master.component.html',
  styleUrls: ['./batch-master.component.css']
})
export class BatchMasterComponent implements OnInit {

  //default batch-master object
  batchMaster: BatchMaster = new BatchMaster();

  // searchParams: any = {
  //   BatchId: '386311',
  //   BatchName: null,
  // };
  searchParams: SearchBatchMasterRequestParams = new SearchBatchMasterRequestParams();
  showAdvanceSearchPanel = false;

  isDataLoadingCompleted: boolean = false;
  selectedBatchMasterId : 0;

  // get acess to Child-component
  @ViewChild(ListofBatchMasterComponent) private childCompListofBatchMaster: ListofBatchMasterComponent;

  constructor(private batchMasterService: BatchMasterService,private router: Router,private route: ActivatedRoute) { }

  ngOnInit() {
    this.searchParams.BatchId = '386311';
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

  //#region event handlers methods

  public searchBatchMaster() {
    this.childCompListofBatchMaster.searchBatchMaster(this.searchParams);
  }

  public resetSearchPanel() {
    this.searchParams = null;
  }

  public parentMethod(childData: any) {
    this.selectedBatchMasterId = childData;
    //alert('Selected BatchMaster : '+ this.selectedBatchMasterId);
    this.router.navigate(['./modify', childData], { relativeTo: this.route });
  }

  public toggleAdvanceSearchPanel()
  {
    this.showAdvanceSearchPanel = !this.showAdvanceSearchPanel;
  }

//#endregion

}

//#endregion