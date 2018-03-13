import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router, Params } from '@angular/router';

//custom components/modules/services
import { VtpService } from '../../../../services/manage-vtp/vtp.service';
import { VocationalTrainingProviderResponse } from '../../../../models/manage-vtp/vtp-response';
import { VocationalTrainingProvider } from '../../../../models/manage-vtp/vtp';
import { OperationStatus } from '../../../../models/shared/operation-status';


@Component({
  selector: 'app-modify-vtp',
  templateUrl: './modify-vtp.component.html',
  styleUrls: ['./modify-vtp.component.css']
})
export class ModifyVtpComponent implements OnInit 
{

  //default vtp object
  vtp: VocationalTrainingProvider = new VocationalTrainingProvider();

  formSubmitted: boolean = false;
  isReadOnlyMode: number = 1;
  isDataLoadingCompleted: boolean = true;
  isFormDataSubmissionCompleted: boolean = null;

  constructor(private vtpService: VtpService, private router: Router,private route: ActivatedRoute) { }

  ngOnInit() 
  {
    this.route.params.subscribe((routeData: Params) => {
      this.loadVtpDetails(routeData['id']);
    });
  }

  loadVtpDetails(vtpId: number) 
  {
    // here get Question obserable
    let observable = this.vtpService.getVtpDetails(vtpId)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedVtpResponse: VocationalTrainingProviderResponse) => {
        debugger;

        // if service has returned valid response then only
        if (searchedVtpResponse != null
          && searchedVtpResponse.OperationStatus.RequestSuccessful == true
          && searchedVtpResponse.VocationalTrainingProvider.length > 0
        ) {
          this.vtp = searchedVtpResponse.VocationalTrainingProvider[0];
          console.log(searchedVtpResponse);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while getting details of Vtp: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('Vtp details loading completed'); subscription.unsubscribe(); }
      );
  }

  public modifyVTP() {
    debugger;

    //local reference
    let vtp = this.vtp;

    if (!(vtp.Code != null && vtp.Name != null)) {
      return false;
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.vtpService.modifyVtp(this.vtp)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedVtpResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedVtpResponse != null) 
        {
          if (searchedVtpResponse.RequestSuccessful) 
          {
            //response meesage directive will be used to show/display on form
            //this.formProcessStatus = 'Vtp successfully submitted';
            alert('Vtp successfully submitted');
          }
          else 
          {
            let returnedMessages = searchedVtpResponse.Messages;
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
      (error: string) => console.log('error while posting data for Vtp: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('Vtp successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public deleteVTP() 
  {
    debugger;

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.vtpService.deleteVtp(this.vtp)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (vtpResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (vtpResponse != null) 
        {
          if (vtpResponse.RequestSuccessful) 
          {
            //response meesage directive will be used to show/display on form
            alert('Vtp details successfully deleted');

            //this.router.navigate(['./manage-masters/vtp']);  //will also work
            this.router.navigate(['./vtp'], { relativeTo: this.route.parent.parent });
          }
          else 
          {
            let returnedMessages = vtpResponse.Messages;
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
      (error: string) => console.log('error while posting data for Vtp: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('Vtp successfully deleted'); subscription.unsubscribe(); }
      );
  }

  public readOnlyModeChanged() {
    //reset form-submitted status
    this.formSubmitted = false;
  }

}