//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

// import reuired services for this component
import {AssessorService} from '../../../services/assessor-demographic/assessor.service';
import { AssessorResponse } from '../../../models/assessor-demographic/assessor-response';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-listof-assessor',
  templateUrl: './listof-assessor.component.html',
  styleUrls: ['./listof-assessor.component.css']
})
export class ListofAssessorComponent implements OnInit {
  
  //#region component global level propertie/variables/models declaration & initlizations

  @Output('selectedAssessor') selectedAssessor = new EventEmitter<string>();
  isDataLoadingCompleted: boolean = true;
  searchedAssessor: any = null;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private assessorService: AssessorService, private router: Router,private route: ActivatedRoute) { }
  
  ngOnInit() { }

  //#endregion 

  //#region public methods

  public searchAssessors(assessorSearchParams: any)
  {
    debugger;
    //alert('Working Child');

    //reset data every time before calling
    this.searchedAssessor =  null;
    this.isDataLoadingCompleted = null;

    // here get Question obserable
    let observable = this.assessorService.searchAssessor(assessorSearchParams);

    let subscription = observable.subscribe
        (
            // calls the onNext() function in the observer
            (assessorResponse: AssessorResponse) =>
            {
              debugger;

                // if service has returned valid response then only
                if (assessorResponse != null 
                    && assessorResponse.OperationStatus.RequestSuccessful == true
                    && assessorResponse.Assessor.length >0
                  )
                {
                    this.searchedAssessor = assessorResponse.Assessor;
                    console.log(assessorResponse);
                }
                else
                {
                    // show error message on screen
                }
            },

            // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
            // here we can also call our logger service to log this exception
            (error: string) => console.log('error while searching Assessor: ' + error),

            // calls the onComplete() function in the observer
            () => { this.isDataLoadingCompleted = true; console.log('Assessor searching completed'); subscription.unsubscribe(); }
        );
  }

  //#endregion 

  //#region private methods
  
  onRowClick(event, id) 
  {
    this.selectedAssessor.emit(id);
  }
  
  //#endregion

}

//#endregion