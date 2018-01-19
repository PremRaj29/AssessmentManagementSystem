import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

import { ListofJobRoleService } from '../../../services/shared/listof-job-role.service';
import { JobRole } from '../../../models/manage-job-role/job-role';
import { JobRoleResponse } from '../../../models/manage-job-role/job-role-response';

@Component({
  selector: 'app-job-role',
  templateUrl: './job-role.component.html',
  styleUrls: ['./job-role.component.css'],
  providers: [ListofJobRoleService]
})
export class JobRoleComponent implements OnInit, OnChanges {

  //interact with input & output of this components
  @Input('skillCouncilTypeId') skillCouncilTypeId: number;
  @Input('skillCouncilId') skillCouncilId: number = null;
  @Input('jobRoleId') jobRoleId: number = null;
  @Output('selectedJobRole') selectedJobRole = new EventEmitter<number>();

  public jobRoles: Array<JobRole> = null;

  isDataLoadingCompleted: boolean = false;

  constructor(private listofJobRoleService: ListofJobRoleService) { }

  ngOnInit() {
  }

  /**
   * 
   * @param changes Method will keep watch on @Input control value based on that take action
   */
  ngOnChanges(changes: SimpleChanges) 
  {
    //call only when eigther input has some valid value & change in eigther "SkillCouncilTypeId" or "SkillId"
    if (
         (changes['skillCouncilTypeId'] != undefined && changes['skillCouncilTypeId'].currentValue != null) || 
         (changes['skillCouncilId'] != undefined && changes['skillCouncilId'].currentValue != null)
     )
    {
      //#region Custom logic to resolve dependetn DDL binding/auto select issue on page LOAD

      /**
       * Reset selected value ["jobRoleId"] of this (CHILD- JobRoles) component 
       * only when components already have some data (this.jobRoles.length >0) otherwise no need.  
       */

      if (this.jobRoles != null && this.jobRoles.length > 0) {
        this.jobRoles = null;
        this.jobRoleId = null;
      }

      //#endregion

      //#region process further only if Valid "skillCouncilId" is there

      if (!(this.skillCouncilId > 0)) {
        return;
      }

      //otherwise load child compList data
      this.getJobRoles();

    //#endregion  
    }  
  }

  //#region public methods

  //#region get methods

  getJobRoles() {

    debugger;    

    // here get job-role-service obserable
    let observable = this.listofJobRoleService.getJobRoles(this.skillCouncilId);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (jobRoleResponse: JobRoleResponse) => {
        debugger;

        // if service has returned valid response then only
        if (jobRoleResponse != null && jobRoleResponse.OperationStatus.RequestSuccessful) {
          // reset skillcouncil data
          this.jobRoles = jobRoleResponse.JobRoles;

          //also reset selectedId comp output
          this.selectedJobRole.emit(this.jobRoleId);
          //console.log(jobRoleResponse.JobRoles);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while loading JobRoles: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('JobRoles loading completed'); }
      );
  }

  //#endregion

  onItemChange(data: any) {
    debugger;
    this.selectedJobRole.emit(data);
  }


  //#endregion
}

