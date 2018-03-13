//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { OperationStatus } from '../../models/shared/operation-status';
import { AssessorIdProofDetail } from '../../models/assessor-demographic/assessor-id-proof-detail';
import { IdProofDetailsResponse } from '../../models/assessor-demographic/id-proof-details-response';

//import environment variables 
import {environment} from '../../../environments/environment';

//#endregion

//#region service decorator & defination

@Injectable()
export class AssessorIdProofDocsDetailService 
{
  //#region global level propertie/variables/models declaration & initlizations

  private assessorIdProofDetailRequestUrl: string = environment.apiUrl + 'AssessorIdProofDetail/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) {};

  //#region service decorator & defination

  /**
   * Method will return the of details of supplied AssessorIdProofDetailId
   */
  getAssessorIdProofDetails(assessorId: number) : Observable<IdProofDetailsResponse>
  {
    //debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorIdProofDetail/1

    // comment : here manipulate url string
    this.requestUrl  = this.assessorIdProofDetailRequestUrl + assessorId;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added AssessorIdProofDetail with supplied details/data
   */
  addAssessorIdProofDetail(assessorIdProofDetail: AssessorIdProofDetail): Observable<OperationStatus> {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorIdProofDetail

    // comment : here manipulate url string
    this.requestUrl = this.assessorIdProofDetailRequestUrl;

    this.addRequestHeaders();

    return this.http
      .post((this.requestUrl), JSON.stringify(assessorIdProofDetail), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added AssessorIdProofDetail with supplied details/data
   */
  modifyAssessorIdProofDetail(assessorIdProofDetail: AssessorIdProofDetail): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorIdProofDetail/1

    // comment : here manipulate url string
    this.requestUrl = this.assessorIdProofDetailRequestUrl + `${assessorIdProofDetail.AssessorId || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(assessorIdProofDetail), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added AssessorIdProofDetail with supplied details/data
   */
  deleteAssessorIdProofDetail(assessorId: number,idProofTypeId: number,id: number =0): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/AssessorIdProofDetail/1

    // comment : here manipulate url string
    this.requestUrl = this.assessorIdProofDetailRequestUrl + `${assessorId || ''}/${idProofTypeId || ''}`;
    
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