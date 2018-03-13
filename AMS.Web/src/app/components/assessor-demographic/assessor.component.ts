//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { OperationStatus } from '../../models/shared/operation-status';

// import Domain class
import { Assessor } from '../../models/assessor-demographic/assessor';

//import required components
import { ListofAssessorComponent } from './listof-assessor/listof-assessor.component';

// import required services for this component
import { AssessorService } from '../../services/assessor-demographic/assessor.service';
import { SearchAssessorRequestParams } from '../../models/assessor-demographic/search-assessor-request-params';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-assessor',
  templateUrl: './assessor.component.html',
  styleUrls: ['./assessor.component.css']
})
export class AssessorComponent implements OnInit {

  //default assessor object
  assessor: Assessor = new Assessor();

  // searchParams: any = {
  //   BatchId: '386311',
  //   BatchName: null,
  // };
  searchParams: SearchAssessorRequestParams = new SearchAssessorRequestParams();
  showAdvanceSearchPanel = false;

  isDataLoadingCompleted: boolean = false;
  selectedAssessorId : 0;

  // get acess to Child-component
  @ViewChild(ListofAssessorComponent) private childCompListofAssessor: ListofAssessorComponent;

  constructor(private assessorService: AssessorService,private router: Router,private route: ActivatedRoute) { }

  ngOnInit() {
    this.searchParams.IRIS_Id = '#10001';
  }

  //#region Child components event-emitter handler methods

  /*
  public councilTypeChanged(childData: any) {
    debugger;
    this.assessor.BatchDetails.SkillCouncilTypeId = childData;
    console.log('Selected CouncilType Id : ' + childData);
  }

  public skillCouncilChanged(childData: any) {
    debugger;
    this.assessor.BatchDetails.SkillCouncilId = childData;
    console.log('Selected SkillCouncil Id : ' + childData);
  }

  public jobRoleChanged(childData: any) {
    debugger;
    this.assessor.BatchDetails.JobRoleId = childData;
    console.log('Selected JobRole Id : ' + childData);
  }

  public schemeChanged(childData: any) {
    debugger;
    this.assessor.BatchDetails.SchemeId = childData;
    console.log('Selected Scheme Id : ' + childData);
  }

  public vtpChanged(childData: any) {
    debugger;
    this.assessor.BatchDetails.VTP_Id = childData;
    console.log('Selected VTP Id : ' + childData);
  }

  public stateChanged(childData: any) {
    debugger;
    this.assessor.BatchDetails.StateId = childData;
    console.log('Selected State Id : ' + childData);
  }

  public cityChanged(childData: any) {
    debugger;
    this.assessor.BatchDetails.CityId = childData;
    console.log('Selected City Id : ' + childData);
  }*/

  //#endregion

  //#region event handlers methods

  public searchAssessors() {
    this.childCompListofAssessor.searchAssessors(this.searchParams);
    //alert('Search Clicked');
  }

  public resetSearchPanel() {
    this.searchParams = null;
  }

  public parentMethod(childData: any) {
    this.selectedAssessorId = childData;
    //alert('Selected Assessor : '+ this.selectedAssessorId);
    this.router.navigate(['./modify', childData], { relativeTo: this.route });
  }

  public toggleAdvanceSearchPanel()
  {
    this.showAdvanceSearchPanel = !this.showAdvanceSearchPanel;
  }

//#endregion

}

//#endregion