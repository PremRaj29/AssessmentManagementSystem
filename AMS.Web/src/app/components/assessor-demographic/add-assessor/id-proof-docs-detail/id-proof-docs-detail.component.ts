//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

// import reuired services for this component
import {AssessorIdProofDocsDetailService} from '../../../../services/assessor-demographic/assessor-id-proof-docs-detail.service';
import { IdProofDetailsResponse } from '../../../../models/assessor-demographic/id-proof-details-response';
import { AssessorIdProofDetail } from '../../../../models/assessor-demographic/assessor-id-proof-detail';
import { OperationStatus } from '../../../../models/shared/operation-status';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-id-proof-docs-detail',
  templateUrl: './id-proof-docs-detail.component.html',
  styleUrls: ['./id-proof-docs-detail.component.css'],
  providers:[AssessorIdProofDocsDetailService]
})
export class IdProofDocsDetailComponent implements OnInit 
{
  //default assessor-preferred-location object
  assessorIdProof: AssessorIdProofDetail = new AssessorIdProofDetail();
  
  //#region component global level propertie/variables/models declaration & initlizations
  @Input('assessorId') assessorId: number = null;
  /**
   * comment : here purpose of this input is basically sending all data from parent service to fill all child tabs data in ONE-GO on page-load
   */
  @Input('assessorIdProofDetailDetailFromParent') assessorIdProofDetails: Array<AssessorIdProofDetail> = new Array<AssessorIdProofDetail>();

  //lcaol varibles
  formSubmitted: boolean = false;
  isDataLoadingCompleted: boolean = true;
  isFormDataSubmissionCompleted: boolean = null;
  selectedTab : number = 0;
  openIdProofDetailMappingScreen : boolean = false;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private assessorIdProofDocsDetailDetailService: AssessorIdProofDocsDetailService, private router: Router,private route: ActivatedRoute) { }
  
  ngOnInit() { 
  }

  //#endregion 

  //#region Child components event-emitter handler methods

  public idProofDocTypeChanged(childData: any) {
    this.assessorIdProof.IdProofTypeId = childData;
    //console.log('Selected IdProofDocType Id : ' + childData);
  }

  //#endregion

  //#region public methods

  public submitNewIdProofDetailMapping()
  {
    debugger;

    let idProofDetails = this.assessorIdProof;
    //Must check for "Unqiue Number" & "Name On Document"
    if (!(this.assessorId >0 && 
      idProofDetails.IdProofTypeId >0 && idProofDetails.UniqueNumber != '' && idProofDetails.NameOnDocument 
      //uploaded file content check
      && idProofDetails.UploadedIdProofDocFile != null 
      //&& idProofDetails.UploadedIdProofDocFile.size != 0
    ))
    {
      return false;
    }
    else
    {
      this.assessorIdProof.AssessorId = this.assessorId;//important
    }

    //reset data every time before calling
    this.isFormDataSubmissionCompleted = false;

    // here get Question obserable
    let observable = this.assessorIdProofDocsDetailDetailService.addAssessorIdProofDetail(this.assessorIdProof);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (assessorResponse: OperationStatus) => {
        //debugger;

        // if service has returned valid response then only
        if (assessorResponse != null && assessorResponse.RequestSuccessful == true) 
        {
          //here reload "Assessor IdProofDetail" after submission/add operation
          console.log(assessorResponse);

          alert('IdProofDetail has been added/mapped successfuly.');
          this.openIdProofDetailMappingScreen = false;
          this.assessorIdProof = new AssessorIdProofDetail();
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while submitting data for AssessorIdProofDetail: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('AssessorIdProofDetail details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public removeIdProofDetail(assessorId: number, idProofTypeId: number)
  {
    debugger;

    if (!(this.assessorId >0 && assessorId >0 && idProofTypeId >0))
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
    let observable = this.assessorIdProofDocsDetailDetailService.deleteAssessorIdProofDetail(this.assessorId,idProofTypeId,0);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (assessorResponse: OperationStatus) => {
        //debugger;

        // if service has returned valid response then only
        if (assessorResponse != null && assessorResponse.RequestSuccessful == true) 
        {
          //here reload "Assessor IdProofDetail" after submission/add operation
          console.log(assessorResponse);

          alert('IdProofDetail has been removed successfuly.');
          this.openIdProofDetailMappingScreen = false;
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while submitting data for AssessorIdProofDetail: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isFormDataSubmissionCompleted = true; console.log('AssessorIdProofDetail details successfully submitted'); subscription.unsubscribe(); }
      );
  }

  public downloadIdProofDoc(IdProofDetail)
  {
    debugger;
    console.log(IdProofDetail);
  }

  /**
   * Method will be triggered on document selection on form
   * @param IdProofDetail 
   */
  public fileUploadEvent(IdProofDocEvent)
  {
    debugger;
    console.log(IdProofDocEvent);

    let reader = new FileReader();
    if(IdProofDocEvent.target.files && IdProofDocEvent.target.files.length > 0) 
    {
      let file = IdProofDocEvent.target.files[0];
      this.assessorIdProof.UploadedIdProofDocFile = file;
      this.assessorIdProof.UploadedIdProofDocFileName = file.name;

      //use file reader
      /*
      reader.readAsDataURL(file);
      reader.onload = () => 
      {
        this.form.get('avatar').setValue
        ({
          filename: file.name,
          filetype: file.type,
          value: reader.result.split(',')[1]
        })
      };
      */
    }
  }

  public addNewIdProofDetailToAssessor()
  {
    //open add/map screen in page otherwise close exisitng one
    this.openIdProofDetailMappingScreen = !this.openIdProofDetailMappingScreen;
  }

  public resetFormDetails()
  {
    this.assessorIdProof = new AssessorIdProofDetail();
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