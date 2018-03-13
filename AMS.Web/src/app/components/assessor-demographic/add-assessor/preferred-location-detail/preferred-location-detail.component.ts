//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

// import reuired services for this component
import {AssessorPreferredLocationDetailService} from '../../../../services/assessor-demographic/assessor-preferred-location-detail.service';
import { PreferredLocationsResponse } from '../../../../models/assessor-demographic/preferred-locations-response';
import { AssessorPreferredLocation } from '../../../../models/assessor-demographic/assessor-preferred-location';
import { OperationStatus } from '../../../../models/shared/operation-status';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-preferred-location-detail',
  templateUrl: './preferred-location-detail.component.html',
  styleUrls: ['./preferred-location-detail.component.css'],
  providers:[AssessorPreferredLocationDetailService]
})
export class PreferredLocationDetailComponent implements OnInit 
{
  //default assessor-preferred-location object
  assessorPreferredLocation: AssessorPreferredLocation = new AssessorPreferredLocation();
  
  //#region component global level propertie/variables/models declaration & initlizations
  @Input('assessorId') assessorId: number = null;
  /**
   * comment : here purpose of this input is basically sending all data from parent service to fill all child tabs data in ONE-GO on page-load
   */
  @Input('assessorPreferredLocationDetailFromParent') assessorPreferredLocationDetail: Array<AssessorPreferredLocation> = new Array<AssessorPreferredLocation>();

  //lcaol varibles
  formSubmitted: boolean = false;
  isDataLoadingCompleted: boolean = true;
  isFormDataSubmissionCompleted: boolean = null;
  selectedTab : number = 0;
  openPreferredLocationMappingScreen : boolean = false;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private assessorPreferredLocationDetailService: AssessorPreferredLocationDetailService, private router: Router,private route: ActivatedRoute) { }
  
  ngOnInit() { 
  }

  //#endregion 

  //#region Child components event-emitter handler methods

  public stateChanged(childData: any) {
    debugger;
    this.assessorPreferredLocation.StateId = childData;
    //console.log('Selected State Id : ' + childData);
  }

  public cityChanged(childData: any) {
    debugger;
    this.assessorPreferredLocation.CityId = childData;
    //console.log('Selected PreferredLocation Id : ' + childData);
  }


  //#endregion

  //#region public methods

  public submitNewPreferredLocationMapping()
  {
    debugger;

    if (!(this.assessorId >0 && this.assessorPreferredLocation.CityId >0))
    {
      return false;
    }
    else
    {
      this.assessorPreferredLocation.AssessorId = this.assessorId;//important
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.assessorPreferredLocationDetailService.addAssessorPreferredLocation(this.assessorPreferredLocation);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (assessorResponse: OperationStatus) => {
        //debugger;

        // if service has returned valid response then only
        if (assessorResponse != null && assessorResponse.RequestSuccessful == true) 
        {
          //here reload "Assessor PreferredLocation" after submission/add operation
          console.log(assessorResponse);

          alert('PreferredLocation has been added/mapped successfuly.');
          this.openPreferredLocationMappingScreen = false;
          this.assessorPreferredLocation = new AssessorPreferredLocation();
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while submitting data for AssessorPreferredLocation: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('AssessorPreferredLocation details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public removePreferredLocation(assessorId: number, jobRoleId: number)
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
    let observable = this.assessorPreferredLocationDetailService.deleteAssessorPreferredLocation(this.assessorId,jobRoleId,0);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (assessorResponse: OperationStatus) => {
        //debugger;

        // if service has returned valid response then only
        if (assessorResponse != null && assessorResponse.RequestSuccessful == true) 
        {
          //here reload "Assessor PreferredLocation" after submission/add operation
          console.log(assessorResponse);

          alert('PreferredLocation has been removed successfuly.');
          this.openPreferredLocationMappingScreen = false;
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while submitting data for AssessorPreferredLocation: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('AssessorPreferredLocation details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public addNewPreferredLocationToAssessor()
  {
    //open add/map screen in page otherwise close exisitng one
    this.openPreferredLocationMappingScreen = !this.openPreferredLocationMappingScreen;
  }

  public resetFormDetails()
  {
    this.assessorPreferredLocation = new AssessorPreferredLocation();
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