import { Component, OnInit } from '@angular/core';

import { SkillCouncilService } from '../../../../services/manage-skill-council/skill-council.service';
import { OperationStatus } from '../../../../models/shared/operation-status';
import { SkillCouncil } from '../../../../models/manage-skill-council/skill-council';

@Component({
  selector: 'app-add-skill-council',
  templateUrl: './add-skill-council.component.html',
  styleUrls: ['./add-skill-council.component.css']
})
export class AddSkillCouncilComponent implements OnInit {

  //default skill-council object
  skillCouncil: SkillCouncil = new SkillCouncil();

  formSubmitted: boolean = false;
  isFormDataSubmissionCompleted: boolean = null;

  constructor(private skillCouncilService: SkillCouncilService) { }

  ngOnInit() {
  }

  //#region public methods

  public councilTypeChanged(childData: any) {
    this.skillCouncil.CouncilTypeId = childData;
    //console.log('Selected CouncilType Id : '+childData);
  }

  public submitSkillCouncil() {
    //alert('Working Child');
    debugger;

    //local reference
    let skillCouncil = this.skillCouncil;

    if (!(skillCouncil.CouncilTypeId != 0 && skillCouncil.Code != null && skillCouncil.FullName != null)) {
      return false;
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.skillCouncilService.addSkillCouncil(this.skillCouncil)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedSkillCouncilResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedSkillCouncilResponse.RequestSuccessful) {
          //response meesage directive will be used to show/display on form
          alert('SkillCouncils successfully submitted');

          // reset form other mandatory data
          this.resetFormDetails();
        }
        else {
          let returnedMessages = searchedSkillCouncilResponse.Messages;
          // show error message on screen
          if (returnedMessages != null && returnedMessages.length > 0) {
            //this.formProcessStatus = returnedMessages[0].Text;
            alert(returnedMessages[0].Text);
          }
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while posting data for SkillCouncils: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('SkillCouncils successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public resetFormDetails() {
    this.skillCouncil = new SkillCouncil();

    //also set form-submitted status
    this.formSubmitted = false;
  }

  //#endregion 

  //#region private methods

  //#endregion 

}
