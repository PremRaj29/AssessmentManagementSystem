//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { OperationStatus } from '../../models/shared/operation-status';
import { AssessorJobRole } from '../../models/assessor-demographic/assessor-job-role';
import { JobRolesResponse } from '../../models/assessor-demographic/job-roles-response';

//import environment variables 
import {environment} from '../../../environments/environment';

//#endregion

//#region service decorator & defination

@Injectable()
export class AssessorJobRoleDetailService {

  //#region global level propertie/variables/models declaration & initlizations

  private assessorJobRoleRequestUrl: string = environment.apiUrl + 'AssessorJobRole/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) {};

  //#region service decorator & defination

  /**
   * Method will return the of details of supplied AssessorJobRoleId
   */
  getAssessorJobRoles(assessorId: number) : Observable<JobRolesResponse>
  {
    //debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorJobRole/1

    // comment : here manipulate url string
    this.requestUrl  = this.assessorJobRoleRequestUrl + assessorId;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added AssessorJobRole with supplied details/data
   */
  addAssessorJobRole(assessorJobRole: AssessorJobRole): Observable<OperationStatus> {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorJobRole

    // comment : here manipulate url string
    this.requestUrl = this.assessorJobRoleRequestUrl;

    this.addRequestHeaders();

    return this.http
      .post((this.requestUrl), JSON.stringify(assessorJobRole), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added AssessorJobRole with supplied details/data
   */
  modifyAssessorJobRole(assessorJobRole: AssessorJobRole): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorJobRole/1

    // comment : here manipulate url string
    this.requestUrl = this.assessorJobRoleRequestUrl + `${assessorJobRole.AssessorId || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(assessorJobRole), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added AssessorJobRole with supplied details/data
   */
  deleteAssessorJobRole(assessorId: number,jobRoleId: number,id: number =0): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorJobRole/1

    // comment : here manipulate url string
    this.requestUrl = this.assessorJobRoleRequestUrl + `${assessorId || ''}/${jobRoleId || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .delete((this.requestUrl), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  //#endregion

  //#region private methods

  private addRequestHeaders() {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    this.requestOptions = new RequestOptions({ headers });
  }

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