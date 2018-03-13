import { Component, OnInit } from '@angular/core';

import { SchemeService } from '../../../../services/manage-scheme/scheme.service';
import { OperationStatus } from '../../../../models/shared/operation-status';
import { Scheme } from '../../../../models/manage-scheme/scheme';

@Component({
  selector: 'app-add-scheme',
  templateUrl: './add-scheme.component.html',
  styleUrls: ['./add-scheme.component.css']
})
export class AddSchemeComponent implements OnInit {

  //default scheme object
  scheme: Scheme = new Scheme();

  formSubmitted: boolean = false;
  isFormDataSubmissionCompleted: boolean = null;

  constructor(private schemeService: SchemeService) { }

  ngOnInit() {
  }

  //#region public methods

  public submitScheme() {
    //alert('Working Child');
    debugger;

    //local reference
    let scheme = this.scheme;

    if (!(scheme.Code != null && scheme.Name != null)) {
      return false;
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.schemeService.addScheme(this.scheme)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (schemeResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (schemeResponse.RequestSuccessful) {
          //response meesage directive will be used to show/display on form
          alert('Schemes details successfully submitted');

          // reset form other mandatory data
          this.resetFormDetails();
        }
        else {
          let returnedMessages = schemeResponse.Messages;
          // show error message on screen
          if (returnedMessages != null && returnedMessages.length > 0) {
            //this.formProcessStatus = returnedMessages[0].Text;
            alert(returnedMessages[0].Text);
          }
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while posting data for Schemes: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('Schemes details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public resetFormDetails() {
    this.scheme = new Scheme();

    //also set form-submitted status
    this.formSubmitted = false;
  }

  //#endregion 

  //#region private methods

  //#endregion 

}