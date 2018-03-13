import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router, Params } from '@angular/router';

//custom components/modules/services
import { SchemeService } from '../../../../services/manage-scheme/scheme.service';
import { SchemeResponse } from '../../../../models/manage-scheme/scheme-response';
import { Scheme } from '../../../../models/manage-scheme/scheme';
import { OperationStatus } from '../../../../models/shared/operation-status';

@Component({
  selector: 'app-modify-scheme',
  templateUrl: './modify-scheme.component.html',
  styleUrls: ['./modify-scheme.component.css']
})
export class ModifySchemeComponent implements OnInit 
{

  //default scheme object
  scheme: Scheme = new Scheme();

  formSubmitted: boolean = false;
  isReadOnlyMode: number = 1;
  isDataLoadingCompleted: boolean = true;
  isFormDataSubmissionCompleted: boolean = null;

  constructor(private schemeService: SchemeService, private router: Router,private route: ActivatedRoute) { }

  ngOnInit() 
  {
    this.route.params.subscribe((routeData: Params) => {
      this.loadSchemeDetails(routeData['id']);
    });
  }

  loadSchemeDetails(schemeId: number) 
  {
    // here get Question obserable
    let observable = this.schemeService.getSchemeDetails(schemeId)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedSchemeResponse: SchemeResponse) => {
        debugger;

        // if service has returned valid response then only
        if (searchedSchemeResponse != null
          && searchedSchemeResponse.OperationStatus.RequestSuccessful == true
          && searchedSchemeResponse.Scheme.length > 0
        ) {
          this.scheme = searchedSchemeResponse.Scheme[0];
          console.log(searchedSchemeResponse);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while getting details of Scheme: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('Scheme details loading completed'); subscription.unsubscribe(); }
      );
  }

  public modifyScheme() {
    debugger;

    //local reference
    let scheme = this.scheme;

    if (!(scheme.Code != null && scheme.Name != null)) {
      return false;
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.schemeService.modifyScheme(this.scheme)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (searchedSchemeResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (searchedSchemeResponse != null) 
        {
          if (searchedSchemeResponse.RequestSuccessful) 
          {
            //response meesage directive will be used to show/display on form
            //this.formProcessStatus = 'Scheme successfully submitted';
            alert('Scheme successfully submitted');
          }
          else 
          {
            let returnedMessages = searchedSchemeResponse.Messages;
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
      (error: string) => console.log('error while posting data for Scheme: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('Scheme successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public deleteScheme() 
  {
    debugger;

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.schemeService.deleteScheme(this.scheme)

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (schemeResponse: OperationStatus) => {
        debugger;

        // if service has returned valid response then only
        if (schemeResponse != null) 
        {
          if (schemeResponse.RequestSuccessful) 
          {
            //response meesage directive will be used to show/display on form
            alert('Scheme details successfully deleted');

            //this.router.navigate(['./manage-masters/scheme']);  //will also work
            this.router.navigate(['./scheme'], { relativeTo: this.route.parent.parent });
          }
          else 
          {
            let returnedMessages = schemeResponse.Messages;
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
      (error: string) => console.log('error while posting data for Scheme: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('Scheme successfully deleted'); subscription.unsubscribe(); }
      );
  }

  public readOnlyModeChanged() {
    //reset form-submitted status
    this.formSubmitted = false;
  }

}