//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { JobRoleResponse } from '../../models/manage-job-role/job-role-response';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';


// import Domain class

//#endregion

//#region service decorator & defination

@Injectable()
export class ListofJobRoleService {

  //#region global level propertie/variables/models declaration & initlizations

  private jobRoleRequestUrl: string = 'http://localhost/AMS.Services/api/SkillCouncil/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) { };

  //#region service decorator & defination

  /**
   * Method will return list of JobRoles of requested SkillCouncil
   */
  getJobRoles(skillCouncilId: number) : Observable<JobRoleResponse>
  {
    debugger;
    //reference-url : http://localhost/AMS.Services/SkillCouncil/2/JobRole

    // comment : here manipulate url string
    this.requestUrl  = this.jobRoleRequestUrl + `${skillCouncilId || '0'}/JobRole`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  //#endregion

  //#region private methods

  private parseData(res: Response) {
    return res.json() || [];
  }

  // displays the error message
  private handleError(error: Response | any) {
    let errorMessage: string;

    errorMessage = error.message ? error.message : error.toString();

    // here we will call to log error
    // logError(error);
    console.log(error);

    // here we can returns another Observable for the observer to subscribe to
    return Observable.throw(errorMessage);
  }

  //#endregion

}

  //#endregion  