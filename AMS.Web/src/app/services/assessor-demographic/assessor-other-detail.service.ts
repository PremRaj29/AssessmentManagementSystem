//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { OperationStatus } from '../../models/shared/operation-status';
import { AssessorOtherDetail } from '../../models/assessor-demographic/assessor-other-detail';
import { OtherDetailsResponse } from '../../models/assessor-demographic/other-details-response';

//import environment variables 
import {environment} from '../../../environments/environment';

//#endregion

//#region service decorator & defination

@Injectable()
export class AssessorOtherDetailService {

  //#region global level propertie/variables/models declaration & initlizations

  private otherDetailRequestUrl: string = environment.apiUrl + 'AssessorOtherDetail/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) {};

  //#region service decorator & defination

  /**
   * Method will return the of details of supplied AssessorOtherDetailId
   */
  getAssessorOtherDetails(assessorId: number) : Observable<OtherDetailsResponse>
  {
    //debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorOtherDetail/1

    // comment : here manipulate url string
    this.requestUrl  = this.otherDetailRequestUrl + assessorId;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added AssessorOtherDetail with supplied details/data
   */
  addAssessorOtherDetail(assessorOtherDetail: AssessorOtherDetail): Observable<OperationStatus> {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorOtherDetail

    // comment : here manipulate url string
    this.requestUrl = this.otherDetailRequestUrl;

    this.addRequestHeaders();

    return this.http
      .post((this.requestUrl), JSON.stringify(assessorOtherDetail), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added AssessorOtherDetail with supplied details/data
   */
  modifyAssessorOtherDetail(assessorOtherDetail: AssessorOtherDetail): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorOtherDetail/1

    // comment : here manipulate url string
    this.requestUrl = this.otherDetailRequestUrl + `${assessorOtherDetail.AssessorId || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(assessorOtherDetail), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added AssessorOtherDetail with supplied details/data
   */
  deleteAssessorOtherDetail(assessorId: number): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorOtherDetail/1

    // comment : here manipulate url string
    this.requestUrl = this.otherDetailRequestUrl +assessorId;
    
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
