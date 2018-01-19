import { Component, OnInit } from '@angular/core';

import { JobRoleService } from '../../../../services/manage-job-role/job-role.service';
import { OperationStatus } from '../../../../models/shared/operation-status';

@Component({
  selector: 'app-add-job-role',
  templateUrl: './add-job-role.component.html',
  styleUrls: ['./add-job-role.component.css']
})
export class AddJobRoleComponent implements OnInit {

  //default job-role object
  jobRole: any = {
    Code: null,
    Name: null,
    SkillCouncilTypeId: 0,
    SkillCouncilId: null,
    Description: null
  };

  formSubmitted: boolean = false;
  isFormDataSubmissionCompleted: boolean = null;

  constructor(private jobRoleService: JobRoleService) { }

  ngOnInit() {
  }

  //#region public methods

  public councilTypeChanged(childData: any) {
    this.jobRole.SkillCouncilTypeId = childData;
    //console.log('Selected CouncilType Id : '+childData);
  }

  public skillCouncilChanged(childData: any) {
    debugger;
    this.jobRole.SkillCouncilId = childData;
    console.log('Selected SkillCouncil Id : ' + childData);
  }

  public submitJobRole() {
    //alert('Working Child');
    debugger;

    //local reference
    let jobRole = this.jobRole;

    if (!(jobRole.SkillCouncilId != null && jobRole.SkillCouncilId > 0 && jobRole.Code != null && jobRole.Name != null)) {
      return false;
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.jobRoleService.addJobRole(this.jobRole)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedJobRoleResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedJobRoleResponse.RequestSuccessful) {
          //response meesage directive will be used to show/display on form
          alert('JobRoles successfully submitted');

          // reset form other mandatory data
          this.resetFormDetails();
        }
        else {
          let returnedMessages = searchedJobRoleResponse.Messages;
          // show error message on screen
          if (returnedMessages != null && returnedMessages.length > 0) {
            //this.formProcessStatus = returnedMessages[0].Text;
            alert(returnedMessages[0].Text);
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

  public resetFormDetails() {
    this.jobRole = {
      Code: '',
      Name: null,
      SkillCouncilTypeId: 0,
      SkillCouncilId: null,
      Description: null
    };

    //also set form-submitted status
    this.formSubmitted = false;
  }

  //#endregion 

  //#region private methods

  //#endregion 

}
