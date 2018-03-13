//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';

// import reuired services for this component
import {SchemeService} from '../../../../services/manage-scheme/scheme.service';
import { SchemeResponse } from '../../../../models/manage-scheme/scheme-response';
import {} from '../../';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-listof-scheme',
  templateUrl: './listof-scheme.component.html',
  styleUrls: ['./listof-scheme.component.css']
})
export class ListofSchemeComponent implements OnInit 
{
  //#region component global level propertie/variables/models declaration & initlizations

  @Output('selectedScheme') selectedScheme = new EventEmitter<string>();
  isDataLoadingCompleted: boolean = true;
  searchedSchemes: any = null;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private schemeService: SchemeService) { }
  
  ngOnInit() { }

  //#endregion 

  //#region public methods

  public searchSchemes(schemeSearchParams: any)
  {
    debugger;
    //alert('Working Child');

    //reset data every time before calling
    this.searchedSchemes =  null;
    this.isDataLoadingCompleted = null;

    // here get Question obserable
    let observable = this.schemeService.searchSchemes(schemeSearchParams);

    let subscription = observable.subscribe
        (
            // calls the onNext() function in the observer
            (searchedSchemeResponse: SchemeResponse) =>
            {
              debugger;

                // if service has returned valid response then only
                if (searchedSchemeResponse != null 
                    && searchedSchemeResponse.OperationStatus.RequestSuccessful == true
                    && searchedSchemeResponse.Scheme.length >0
                  )
                {
                    this.searchedSchemes = searchedSchemeResponse.Scheme;
                    console.log(searchedSchemeResponse);
                }
                else
                {
                    // show error message on screen
                }
            },

            // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
            // here we can also call our logger service to log this exception
            (error: string) => console.log('error while searching Schemes: ' + error),

            // calls the onComplete() function in the observer
            () => { this.isDataLoadingCompleted = true; console.log('Schemes searching completed'); subscription.unsubscribe(); }
        );
  }

  //#endregion 

  //#region private methods
  
  onRowClick(event, id) 
  {
    debugger;
    //console.log(event.target.outerText, id);  //cell/column text = outerText; row-id : "id" param
    //alert(event.target.outerText);
    
    //event.currentTarget.style.backgroundColor="red";
    //alert(event.t);

    //alert(id);
    this.selectedScheme.emit(id);
  }
  
  //#endregion

}

//#endregion