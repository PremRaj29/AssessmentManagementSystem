//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';

// import reuired services for this component
import {JobRoleService} from '../../../../services/manage-job-role/job-role.service';
import { JobRoleResponse } from '../../../../models/manage-job-role/job-role-response';
import {} from '../../';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-listof-job-role',
  templateUrl: './listof-job-role.component.html',
  styleUrls: ['./listof-job-role.component.css']
})
export class ListofJobRoleComponent implements OnInit {

  //#region component global level propertie/variables/models declaration & initlizations

  @Output('selectedJobRole') selectedJobRole = new EventEmitter<string>();
  isDataLoadingCompleted: boolean = true;
  searchedJobRoles: any = null;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private jobRoleService: JobRoleService) { }
  
  ngOnInit() { }

  //#endregion 

  //#region public methods

  public searchJobRoles(jobRoleSearchParams: any)
  {
    //alert('Working Child');

    //reset data every time before calling
    this.searchedJobRoles =  null;
    this.isDataLoadingCompleted = null;

    // here get Question obserable
    let observable = this.jobRoleService.searchJobRoles(jobRoleSearchParams);

    let subscription = observable.subscribe
        (
            // calls the onNext() function in the observer
            (searchedJobRoleResponse: JobRoleResponse) =>
            {
              debugger;

                // if service has returned valid response then only
                if (searchedJobRoleResponse != null 
                    && searchedJobRoleResponse.OperationStatus.RequestSuccessful == true
                    && searchedJobRoleResponse.JobRoles.length >0
                  )
                {
                    this.searchedJobRoles = searchedJobRoleResponse.JobRoles;
                    console.log(searchedJobRoleResponse);
                }
                else
                {
                    // show error message on screen
                }
            },

            // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
            // here we can also call our logger service to log this exception
            (error: string) => console.log('error while searching JobRoles: ' + error),

            // calls the onComplete() function in the observer
            () => { this.isDataLoadingCompleted = true; console.log('JobRoles searching completed'); subscription.unsubscribe(); }
        );
  }

  //#endregion 

  //#region private methods
  
  onRowClick(event, id) 
  {
    //console.log(event.target.outerText, id);  //cell/column text = outerText; row-id : "id" param
    //alert(event.target.outerText);
    
    //event.currentTarget.style.backgroundColor="red";
    //alert(event.t);

    //alert(id);
    this.selectedJobRole.emit(id);
  }
  
  //#endregion

}

//#endregion