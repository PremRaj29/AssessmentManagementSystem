//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { OperationStatus } from '../../models/shared/operation-status';
import { Assessor } from '../../models/assessor-demographic/assessor';
import { SearchAssessorRequestParams } from '../../models/assessor-demographic/search-assessor-request-params';
import { AssessorResponse } from '../../models/assessor-demographic/assessor-response';

//import environment variables 
import {environment} from '../../../environments/environment';

//#endregion

//#region service decorator & defination

@Injectable()
export class AssessorService {

  //#region global level propertie/variables/models declaration & initlizations

  private assessorRequestUrl: string = environment.apiUrl + 'Assessor/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) {};

  //#region service decorator & defination

  /**
   * Method will return the of details of supplied AssessorId
   */
  getAssessorDetails(assessorId: number) : Observable<AssessorResponse>
  {
    //debugger;
    //reference-url : http://{Path}/AMS.Services/api/Assessor/1

    // comment : here manipulate url string
    this.requestUrl  = this.assessorRequestUrl + assessorId;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will return the of details of based on supplied AssessorId/IRIS_Id
   */
  getAssessorDetailsV2(assessorId: string = null,iris_Id: string = null) : Observable<AssessorResponse>
  {
    //debugger;
    //reference-url : http://{Path}/AMS.Services/api/Assessor/36541/{ #123/Prem/$TRACE }

    // comment : here manipulate url string
    this.requestUrl  = this.assessorRequestUrl + `?assessorId=${assessorId || ''}&iris_Id=${iris_Id || ''}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added Assessor with supplied details/data
   */
  addAssessor(assessor: Assessor): Observable<OperationStatus> {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/Assessor

    // comment : here manipulate url string
    this.requestUrl = this.assessorRequestUrl;

    this.addRequestHeaders();

    return this.http
      .post((this.requestUrl), JSON.stringify(assessor), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will return list of Assessor data based on supplied search-params
   */
  searchAssessor(searchParams: SearchAssessorRequestParams): Observable<AssessorResponse> {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/Assessor/Search?assessorId=386312

    // comment : here manipulate url string
    this.requestUrl = this.assessorRequestUrl + `Search?AssessorId=0&Name=${searchParams.Name || ''}&Gender=${searchParams.Gender || ''}&Email=${searchParams.EmailId}&Mobile=${searchParams.MobileNo}&WhatsAppNo=${searchParams.WhatsAppNo}&StateId=${searchParams.StateId}&CityId=${searchParams.CityId}&SkillCouncilTypeId=${searchParams.SkillCouncilTypeId}&SkillCouncilId=${searchParams.SkillCouncilId}&JobRoleId=${searchParams.JobRoleId}`;
    //&IRIS_Id=${searchParams.IRIS_Id || ''} //this paramater creating some issue ??

    this.addRequestHeaders();     

    return this.http
    .post(this.requestUrl, JSON.stringify(searchParams), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added Assessor with supplied details/data
   */
  modifyAssessor(assessor: Assessor): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/SkillCouncil/5/JobRole/127

    // comment : here manipulate url string
    this.requestUrl = this.assessorRequestUrl + `${assessor.Id || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(assessor), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added Assessor with supplied details/data
   */
  deleteAssessor(assessorId: number): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/Assessor/1

    // comment : here manipulate url string
    this.requestUrl = this.assessorRequestUrl +assessorId;
    
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
