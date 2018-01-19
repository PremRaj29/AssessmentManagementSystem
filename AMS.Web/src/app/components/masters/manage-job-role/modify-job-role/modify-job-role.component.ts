import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router, Params } from '@angular/router';
import { JobRoleService } from '../../../../services/manage-job-role/job-role.service';
import { JobRoleResponse } from '../../../../models/manage-job-role/job-role-response';
import { JobRole } from '../../../../models/manage-job-role/job-role';
import { OperationStatus } from '../../../../models/shared/operation-status';

@Component({
  selector: 'app-modify-job-role',
  templateUrl: './modify-job-role.component.html',
  styleUrls: ['./modify-job-role.component.css']
})
export class ModifyJobRoleComponent implements OnInit {

  //default job-role object
  jobRole: JobRole = new JobRole();

  // jobRole: any = {
  //   Code: '',
  //   Name: null,
  //   SkillCouncilTypeId: 0,
  //   SkillCouncilId: null,
  //   Description: null
  // };

  formSubmitted: boolean = false;
  isReadOnlyMode: number = 1;
  isDataLoadingCompleted: boolean = true;
  isFormDataSubmissionCompleted: boolean = null;

  constructor(private jobRoleService: JobRoleService, private router: Router,private route: ActivatedRoute) { }

  ngOnInit() {
    // this.jobRole = {
    //   Code: 'Code-111',
    //   Name: 'JobRole',
    //   SkillCouncilTypeId: 1,
    //   SkillCouncilId: 4,
    //   Description: 'Sample Description'
    // };

    this.route.params.subscribe((routeData: Params) => {
      this.loadJobRoleDetails(routeData['id']);
    });
  }

  loadJobRoleDetails(jobRoleId: number) {
    // here get Question obserable
    let observable = this.jobRoleService.getJobRoleDetails(jobRoleId)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedJobRoleResponse: JobRoleResponse) => {
        debugger;

        // if service has returned valid response then only
        if (searchedJobRoleResponse != null
          && searchedJobRoleResponse.OperationStatus.RequestSuccessful == true
          && searchedJobRoleResponse.JobRoles.length > 0
        ) {
          this.jobRole = searchedJobRoleResponse.JobRoles[0];
          console.log(searchedJobRoleResponse);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while getting details of JobRole: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('JobRole details loading completed'); subscription.unsubscribe(); }
      );
  }

  councilTypeChanged(childData: any) {
    this.jobRole.SkillCouncilTypeId = childData;
    this.jobRole.SkillCouncilId = null;
    //console.log('Selected CouncilType Id : '+childData);
  }

  skillCouncilChanged(childData: any) {
    debugger;
    this.jobRole.SkillCouncilId = childData;
    console.log('Selected SkillCouncil Id : ' + childData);
  }

  public modifyJobRole() {
    //local reference
    let jobRole = this.jobRole;

    if (!(jobRole.SkillCouncilId != null && jobRole.SkillCouncilId > 0 && jobRole.Code != null && jobRole.Name != null)) {
      return false;
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.jobRoleService.modifyJobRole(this.jobRole)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedJobRoleResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedJobRoleResponse != null) 
        {
          if (searchedJobRoleResponse.RequestSuccessful) 
          {
            //response meesage directive will be used to show/display on form
            //this.formProcessStatus = 'JobRoles successfully submitted';
            alert('JobRoles successfully submitted');
          }
          else 
          {
            let returnedMessages = searchedJobRoleResponse.Messages;
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
      () => { this.isFormDataSubmissionCompleted = true; console.log('JobRoles successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public deleteJobRole() 
  {
    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.jobRoleService.deleteJobRole(this.jobRole)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedJobRoleResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedJobRoleResponse != null) 
        {
          if (searchedJobRoleResponse.RequestSuccessful) 
          {
            //response meesage directive will be used to show/display on form
            alert('JobRoles successfully deleted');

            //this.router.navigate(['./manage-masters/job-role']);  //will also work
            this.router.navigate(['./job-role'], { relativeTo: this.route.parent.parent });
          }
          else 
          {
            let returnedMessages = searchedJobRoleResponse.Messages;
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
      () => { this.isFormDataSubmissionCompleted = true; console.log('JobRoles successfully deleted'); subscription.unsubscribe(); }
      );
  }

  public readOnlyModeChanged() {
    //reset form-submitted status
    this.formSubmitted = false;
  }

}  