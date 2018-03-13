//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { OperationStatus } from '../../models/shared/operation-status';
import { AssessorPersonalDetail } from '../../models/assessor-demographic/assessor-personal-detail';
import { PersonalDetailsResponse } from '../../models/assessor-demographic/personal-details-response';

//import environment variables 
import {environment} from '../../../environments/environment';

//#endregion

//#region service decorator & defination

@Injectable()
export class AssessorPersonalDetailService {

  //#region global level propertie/variables/models declaration & initlizations

  private personalDetailRequestUrl: string = environment.apiUrl + 'AssessorPersonalDetail/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) {};

  //#region service decorator & defination

  /**
   * Method will return the of details of supplied AssessorPersonalDetailId
   */
  getAssessorPersonalDetails(assessorId: number) : Observable<PersonalDetailsResponse>
  {
    //debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorPersonalDetail/1

    // comment : here manipulate url string
    this.requestUrl  = this.personalDetailRequestUrl + assessorId;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added AssessorPersonalDetail with supplied details/data
   */
  addAssessorPersonalDetail(assessorPersonalDetail: AssessorPersonalDetail): Observable<OperationStatus> {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorPersonalDetail

    // comment : here manipulate url string
    this.requestUrl = this.personalDetailRequestUrl;

    this.addRequestHeaders();

    return this.http
      .post((this.requestUrl), JSON.stringify(assessorPersonalDetail), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added AssessorPersonalDetail with supplied details/data
   */
  modifyAssessorPersonalDetail(assessorPersonalDetail: AssessorPersonalDetail): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorPersonalDetail/1

    // comment : here manipulate url string
    this.requestUrl = this.personalDetailRequestUrl + `${assessorPersonalDetail.AssessorId || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(assessorPersonalDetail), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added AssessorPersonalDetail with supplied details/data
   */
  deleteAssessorPersonalDetail(assessorId: number): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorPersonalDetail/1

    // comment : here manipulate url string
    this.requestUrl = this.personalDetailRequestUrl +assessorId;
    
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
