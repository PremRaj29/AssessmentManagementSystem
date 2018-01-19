//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { OperationStatus } from '../../models/shared/operation-status';
import { BatchMaster } from '../../models/batch-master/batch-master';
import { SearchBatchMasterRequestParams } from '../../models/batch-master/search-batch-master-request-params';
import { BatchMasterResponse } from '../../models/batch-master/batch-master-response';

//import environment variables 
import {environment} from '../../../environments/environment';

//#endregion

//#region service decorator & defination

@Injectable()
export class BatchMasterService {

  //#region global level propertie/variables/models declaration & initlizations

  private batchMasterRequestUrl: string = environment.apiUrl + 'BatchMaster/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) {};

  //#region service decorator & defination

  /**
   * Method will return the of details of supplied BatchMasterId
   */
  getBatchMasterDetails(batchMasterId: number) : Observable<BatchMasterResponse>
  {
    //debugger;
    //reference-url : http://localhost/AMS.Services/api/BatchMaster/1

    // comment : here manipulate url string
    this.requestUrl  = this.batchMasterRequestUrl + batchMasterId;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will return the of details of based on supplied BatchId/BatchName
   */
  getBatchMasterDetailsV2(batchId: string = null,batchName: string = null) : Observable<BatchMasterResponse>
  {
    //debugger;
    //reference-url : http://localhost/AMS.Services/api/BatchMaster/36541/{ #123/Prem/$TRACE }

    // comment : here manipulate url string
    this.requestUrl  = this.batchMasterRequestUrl + `?BatchId=${batchId || ''}&BatchName=${batchName || ''}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added BatchMaster with supplied details/data
   */
  addBatchMaster(batchMaster: BatchMaster): Observable<OperationStatus> {
    debugger;
    //reference-url : http://localhost/AMS.Services/api/BatchMaster

    // comment : here manipulate url string
    this.requestUrl = this.batchMasterRequestUrl;

    this.addRequestHeaders();

    return this.http
      .post((this.requestUrl), JSON.stringify(batchMaster), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will return list of BatchMaster data based on supplied search-params
   */
  searchBatchMaster(searchParams: SearchBatchMasterRequestParams): Observable<BatchMasterResponse> {
    debugger;
    //reference-url : http://localhost/AMS.Services/api/BatchMaster/Search?BatchId=386312

    // comment : here manipulate url string
    this.requestUrl = this.batchMasterRequestUrl + `Search?BatchId=${searchParams.BatchId || ''}&BatchName=${searchParams.BatchName || ''}&SchemeId=${searchParams.SchemeId}&JobRoleId=${searchParams.JobRoleId}&CityId=${searchParams.CityId}&VTP_Id=${searchParams.VTP_Id}&TotalCandidates=${searchParams.TotalCandidates}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added BatchMaster with supplied details/data
   */
  modifyBatchMaster(batchMaster: BatchMaster): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://localhost/AMS.Services/api/SkillCouncil/5/JobRole/127

    // comment : here manipulate url string
    this.requestUrl = this.batchMasterRequestUrl + `${batchMaster.Id || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(batchMaster), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added BatchMaster with supplied details/data
   */
  deleteBatchMaster(batchMasterId: number): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://localhost/AMS.Services/api/BatchMaster/1

    // comment : here manipulate url string
    this.requestUrl = this.batchMasterRequestUrl +batchMasterId;
    
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
