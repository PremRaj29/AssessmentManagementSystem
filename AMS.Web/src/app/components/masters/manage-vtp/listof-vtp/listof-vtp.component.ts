//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';

// import reuired services for this component
import {VtpService} from '../../../../services/manage-vtp/vtp.service';
import { VocationalTrainingProviderResponse } from '../../../../models/manage-vtp/vtp-response';
import {} from '../../';

//#endregion

//#region component decoratror & definations


@Component({
  selector: 'app-listof-vtp',
  templateUrl: './listof-vtp.component.html',
  styleUrls: ['./listof-vtp.component.css']
})
export class ListofVtpComponent implements OnInit 
{
  //#region component global level propertie/variables/models declaration & initlizations

  @Output('selectedVtp') selectedVtp = new EventEmitter<string>();
  isDataLoadingCompleted: boolean = true;
  searchedVtps: any = null;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private vtpService: VtpService) { }
  
  ngOnInit() { }

  //#endregion 

  //#region public methods

  public searchVtps(vtpSearchParams: any)
  {
    debugger;
    //alert('Working Child');

    //reset data every time before calling
    this.searchedVtps =  null;
    this.isDataLoadingCompleted = null;

    // here get Question obserable
    let observable = this.vtpService.searchVtps(vtpSearchParams);

    let subscription = observable.subscribe
        (
            // calls the onNext() function in the observer
            (searchedVtpResponse: VocationalTrainingProviderResponse) =>
            {
              debugger;

                // if service has returned valid response then only
                if (searchedVtpResponse != null 
                    && searchedVtpResponse.OperationStatus.RequestSuccessful == true
                    && searchedVtpResponse.VocationalTrainingProvider.length >0
                  )
                {
                    this.searchedVtps = searchedVtpResponse.VocationalTrainingProvider;
                    console.log(searchedVtpResponse);
                }
                else
                {
                    // show error message on screen
                }
            },

            // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
            // here we can also call our logger service to log this exception
            (error: string) => console.log('error while searching Vtps: ' + error),

            // calls the onComplete() function in the observer
            () => { this.isDataLoadingCompleted = true; console.log('Vtps searching completed'); subscription.unsubscribe(); }
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
    this.selectedVtp.emit(id);
  }
  
  //#endregion

}

//#endregion