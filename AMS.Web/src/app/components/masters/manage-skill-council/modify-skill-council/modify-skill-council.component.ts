import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router, Params } from '@angular/router';

//custom components/modules/services
import { SkillCouncilService } from '../../../../services/manage-skill-council/skill-council.service';
import { SkillCouncilResponse } from '../../../../models/manage-skill-council/skill-council-response';
import { SkillCouncil } from '../../../../models/manage-skill-council/skill-council';
import { OperationStatus } from '../../../../models/shared/operation-status';

@Component({
  selector: 'app-modify-skill-council',
  templateUrl: './modify-skill-council.component.html',
  styleUrls: ['./modify-skill-council.component.css']
})
export class ModifySkillCouncilComponent implements OnInit {

  //default skill-council object
  skillCouncil: SkillCouncil = new SkillCouncil();

  formSubmitted: boolean = false;
  isReadOnlyMode: number = 1;
  isDataLoadingCompleted: boolean = true;
  isFormDataSubmissionCompleted: boolean = null;

  constructor(private skillCouncilService: SkillCouncilService, private router: Router,private route: ActivatedRoute) { }

  ngOnInit() 
  {
    this.route.params.subscribe((routeData: Params) => {
      this.loadSkillCouncilDetails(routeData['id']);
    });
  }

  loadSkillCouncilDetails(skillCouncilId: number) 
  {
    // here get Question obserable
    let observable = this.skillCouncilService.getSkillCouncilDetails(skillCouncilId)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedSkillCouncilResponse: SkillCouncilResponse) => {
        debugger;

        // if service has returned valid response then only
        if (searchedSkillCouncilResponse != null
          && searchedSkillCouncilResponse.OperationStatus.RequestSuccessful == true
          && searchedSkillCouncilResponse.SkillCouncil.length > 0
        ) {
          this.skillCouncil = searchedSkillCouncilResponse.SkillCouncil[0];
          console.log(searchedSkillCouncilResponse);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while getting details of SkillCouncil: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('SkillCouncil details loading completed'); subscription.unsubscribe(); }
      );
  }

  councilTypeChanged(childData: any) {
    this.skillCouncil.CouncilTypeId = childData;
    //console.log('Selected CouncilType Id : '+childData);
  }

  public modifySkillCouncil() {
    //local reference
    let skillCouncil = this.skillCouncil;

    if (!(skillCouncil.CouncilTypeId != 0 && skillCouncil.Code != null && skillCouncil.FullName != null)) {
      return false;
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.skillCouncilService.modifySkillCouncil(this.skillCouncil)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedSkillCouncilResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedSkillCouncilResponse != null) 
        {
          if (searchedSkillCouncilResponse.RequestSuccessful) 
          {
            //response meesage directive will be used to show/display on form
            //this.formProcessStatus = 'SkillCouncil successfully submitted';
            alert('SkillCouncil successfully submitted');
          }
          else 
          {
            let returnedMessages = searchedSkillCouncilResponse.Messages;
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
      (error: string) => console.log('error while posting data for SkillCouncil: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('SkillCouncil successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public deleteSkillCouncil() 
  {
    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.skillCouncilService.deleteSkillCouncil(this.skillCouncil)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedSkillCouncilResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedSkillCouncilResponse != null) 
        {
          if (searchedSkillCouncilResponse.RequestSuccessful) 
          {
            //response meesage directive will be used to show/display on form
            alert('SkillCouncil successfully deleted');

            //this.router.navigate(['./manage-masters/skill-council']);  //will also work
            this.router.navigate(['./skill-council'], { relativeTo: this.route.parent.parent });
          }
          else 
          {
            let returnedMessages = searchedSkillCouncilResponse.Messages;
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
      (error: string) => console.log('error while posting data for SkillCouncil: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('SkillCouncil successfully deleted'); subscription.unsubscribe(); }
      );
  }

  public readOnlyModeChanged() {
    //reset form-submitted status
    this.formSubmitted = false;
  }

}