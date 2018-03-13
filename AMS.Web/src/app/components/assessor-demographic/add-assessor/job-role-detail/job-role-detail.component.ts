//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

// import reuired services for this component
import {AssessorJobRoleDetailService} from '../../../../services/assessor-demographic/assessor-job-role-detail.service';
import { JobRolesResponse } from '../../../../models/assessor-demographic/job-roles-response';
import { AssessorJobRole } from '../../../../models/assessor-demographic/assessor-job-role';
import { OperationStatus } from '../../../../models/shared/operation-status';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-assesor-job-role-detail',
  templateUrl: './job-role-detail.component.html',
  styleUrls: ['./job-role-detail.component.css'],
  providers:[AssessorJobRoleDetailService]
})
export class JobRoleDetailComponent implements OnInit 
{
  //default assessor-job-role object
  assessorJobRole: AssessorJobRole = new AssessorJobRole();
  
  //#region component global level propertie/variables/models declaration & initlizations
  @Input('assessorId') assessorId: number = null;
  /**
   * comment : here purpose of this input is basically sending all data from parent service to fill all child tabs data in ONE-GO on page-load
   */
  @Input('assessorJobRoleDetailFromParent') assessorJobRoleDetail: Array<AssessorJobRole> = new Array<AssessorJobRole>();

  //lcaol varibles
  formSubmitted: boolean = false;
  isDataLoadingCompleted: boolean = true;
  isFormDataSubmissionCompleted: boolean = null;
  selectedTab : number = 0;
  openJobRoleMappingScreen : boolean = false;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private assessorJobRoleDetailService: AssessorJobRoleDetailService, private router: Router,private route: ActivatedRoute) { }
  
  ngOnInit() { 
  }

  //#endregion 

  //#region Child components event-emitter handler methods

  public councilTypeChanged(childData: any) {
    this.assessorJobRole.SkillCouncilTypeId = childData;
    //console.log('Selected CouncilType Id : '+childData);
  }

  public skillCouncilChanged(childData: any) {
    debugger;
    this.assessorJobRole.SkillCouncilId = childData;
    //console.log('Selected SkillCouncil Id : ' + childData);
  }

  public jobRoleChanged(childData: any) {
    debugger;
    this.assessorJobRole.JobRoleId = childData;
    //console.log('Selected JobRole Id : ' + childData);
  }


  //#endregion

  //#region public methods

  public submitNewJobRoleMapping()
  {
    debugger;

    if (!(this.assessorId >0 && this.assessorJobRole.JobRoleId >0))
    {
      return false;
    }
    else
    {
      this.assessorJobRole.AssessorId = this.assessorId;//important
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.assessorJobRoleDetailService.addAssessorJobRole(this.assessorJobRole);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (assessorResponse: OperationStatus) => {
        //debugger;

        // if service has returned valid response then only
        if (assessorResponse != null && assessorResponse.RequestSuccessful == true) 
        {
          //here reload "Assessor JobRole" after submission/add operation
          console.log(assessorResponse);

          alert('Job role has been added/mapped successfuly.');
          this.openJobRoleMappingScreen = false;
          this.assessorJobRole = new AssessorJobRole();
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while submitting data for AssessorJobRole: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('AssessorJobRole details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public removeJobRole(assessorId: number, jobRoleId: number)
  {
    debugger;

    if (!(this.assessorId >0 && assessorId >0 && jobRoleId >0))
    {
      return false;
    }
    else
    {
      let confirmStatus = confirm('Are you sure want to continue?');

      if(!confirmStatus)
      {
        return false;
      }
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.assessorJobRoleDetailService.deleteAssessorJobRole(this.assessorId,jobRoleId,0);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (assessorResponse: OperationStatus) => {
        //debugger;

        // if service has returned valid response then only
        if (assessorResponse != null && assessorResponse.RequestSuccessful == true) 
        {
          //here reload "Assessor JobRole" after submission/add operation
          console.log(assessorResponse);

          alert('Job role has been removed successfuly.');
          this.openJobRoleMappingScreen = false;
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while submitting data for AssessorJobRole: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('AssessorJobRole details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public addNewJobRoleToAssessor()
  {
    //open add/map screen in page otherwise close exisitng one
    this.openJobRoleMappingScreen = !this.openJobRoleMappingScreen;
  }

  public resetFormDetails()
  {
    this.assessorJobRole = new AssessorJobRole();
  }

  //#endregion 

  //#region private methods
  
  onRowClick(event, id) 
  {
    //this.selectedAssessor.emit(id);
    alert('Clicked Row : '+id);
  }
  
  //#endregion

}

//#endregion