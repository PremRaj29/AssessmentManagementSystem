import { Component, OnInit } from '@angular/core';

import { VtpService } from '../../../../services/manage-vtp/vtp.service';
import { OperationStatus } from '../../../../models/shared/operation-status';
import { VocationalTrainingProvider } from '../../../../models/manage-vtp/vtp';

@Component({
  selector: 'app-add-vtp',
  templateUrl: './add-vtp.component.html',
  styleUrls: ['./add-vtp.component.css']
})
export class AddVtpComponent implements OnInit {

  //default vtp object
  vtp: VocationalTrainingProvider = new VocationalTrainingProvider();

  formSubmitted: boolean = false;
  isFormDataSubmissionCompleted: boolean = null;

  constructor(private vtpService: VtpService) { }

  ngOnInit() {
  }

  //#region public methods

  public submitVTP() {
    //alert('Working Child');
    debugger;

    //local reference
    let vtp = this.vtp;

    if (!(vtp.Code != null && vtp.Name != null)) {
      return false;
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.vtpService.addVtp(this.vtp)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (vtpResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (vtpResponse.RequestSuccessful) {
          //response meesage directive will be used to show/display on form
          alert('Vtps details successfully submitted');

          // reset form other mandatory data
          this.resetFormDetails();
        }
        else {
          let returnedMessages = vtpResponse.Messages;
          // show error message on screen
          if (returnedMessages != null && returnedMessages.length > 0) {
            //this.formProcessStatus = returnedMessages[0].Text;
            alert(returnedMessages[0].Text);
          }
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while posting data for VTP: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('VTP details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public resetFormDetails() {
    this.vtp = new VocationalTrainingProvider();

    //also set form-submitted status
    this.formSubmitted = false;
  }

  //#endregion 

  //#region private methods

  //#endregion 

}