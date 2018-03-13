//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { SearchJobRolesRequestParams } from '../../models/manage-job-role/search-job-roles-request-params';
import { JobRole } from '../../models/manage-job-role/job-role';
import { OperationStatus } from '../../models/shared/operation-status';
import { JobRoleResponse } from '../../models/manage-job-role/job-role-response';

import {environment} from '../../../environments/environment';

// import Domain class

//#endregion

//#region service decorator & defination

@Injectable()
export class JobRoleService {

  //#region global level propertie/variables/models declaration & initlizations

  private jobRoleRequestUrl: string = environment.apiUrl + 'SkillCouncil/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) { };

  //#region service decorator & defination

  /**
   * Method will return the of details of supplied JobRoleId
   */
  getJobRoleDetails(jobRoleId: number,skillCouncilId?: number) : Observable<JobRoleResponse>
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/SkillCouncil/2/JobRole/127

    // comment : here manipulate url string
    this.requestUrl  = this.jobRoleRequestUrl + `${skillCouncilId || '0'}/JobRole/${jobRoleId || ''}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will return list of JobRoles data based on supplied search-params
   */
  searchJobRoles(searchParams: SearchJobRolesRequestParams) : Observable<JobRoleResponse>
  {
    debugger;
    //reference-url : http://{Path}}/AMS.Services/SkillCouncil/JobRole/Search?Code=TEST

    // comment : here manipulate url string
    this.requestUrl  = this.jobRoleRequestUrl +`JobRole/Search?Code=${searchParams.Code || ''}&Name=${searchParams.Name || ''}&SkillCouncilTypeId=${searchParams.SkillCouncilTypeId}&SkillCouncilId=${searchParams.SkillCouncilId}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added JobRoles with supplied details/data
   */
  addJobRole(jobRole: JobRole): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}}/AMS.Services/api/SkillCouncil/5/JobRole

    // comment : here manipulate url string
    this.requestUrl = this.jobRoleRequestUrl +`${jobRole.SkillCouncilId || ''}/JobRole`;
    
    this.addRequestHeaders();
      
    return this.http
        .post((this.requestUrl), JSON.stringify(jobRole), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added JobRoles with supplied details/data
   */
  modifyJobRole(jobRole: JobRole): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/SkillCouncil/5/JobRole/127

    // comment : here manipulate url string
    this.requestUrl = this.jobRoleRequestUrl +`${jobRole.SkillCouncilId || ''}/JobRole/`+ `${jobRole.Id || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(jobRole), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added JobRoles with supplied details/data
   */
  deleteJobRole(jobRole: JobRole): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/SkillCouncil/5/JobRole/127

    // comment : here manipulate url string
    this.requestUrl = this.jobRoleRequestUrl +`${jobRole.SkillCouncilId || ''}/JobRole/`+ `${jobRole.Id || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .delete((this.requestUrl), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  //#endregion

  //#region private methods

  private addRequestHeaders()
  {
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
