//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { OperationStatus } from '../../models/shared/operation-status';
import { AssessorCommunicationDetail } from '../../models/assessor-demographic/assessor-communication-detail';
import { CommunicationDetailsResponse } from '../../models/assessor-demographic/communication-details-response';

//import environment variables 
import {environment} from '../../../environments/environment';

//#endregion

//#region service decorator & defination

@Injectable()
export class AssessorCommunicationDetailService {

  //#region global level propertie/variables/models declaration & initlizations

  private communicationDetailRequestUrl: string = environment.apiUrl + 'AssessorCommunicationDetail/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) {};

  //#region service decorator & defination

  /**
   * Method will return the of details of supplied AssessorCommunicationDetailId
   */
  getAssessorCommunicationDetails(assessorId: number) : Observable<CommunicationDetailsResponse>
  {
    //debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorCommunicationDetail/1

    // comment : here manipulate url string
    this.requestUrl  = this.communicationDetailRequestUrl + assessorId;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added AssessorCommunicationDetail with supplied details/data
   */
  addAssessorCommunicationDetail(assessorCommunicationDetail: AssessorCommunicationDetail): Observable<OperationStatus> {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorCommunicationDetail

    // comment : here manipulate url string
    this.requestUrl = this.communicationDetailRequestUrl;

    this.addRequestHeaders();

    return this.http
      .post((this.requestUrl), JSON.stringify(assessorCommunicationDetail), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added AssessorCommunicationDetail with supplied details/data
   */
  modifyAssessorCommunicationDetail(assessorCommunicationDetail: AssessorCommunicationDetail): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorCommunicationDetail/1

    // comment : here manipulate url string
    this.requestUrl = this.communicationDetailRequestUrl + `${assessorCommunicationDetail.AssessorId || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(assessorCommunicationDetail), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added AssessorCommunicationDetail with supplied details/data
   */
  deleteAssessorCommunicationDetail(assessorId: number): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorCommunicationDetail/1

    // comment : here manipulate url string
    this.requestUrl = this.communicationDetailRequestUrl +assessorId;
    
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
