//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { OperationStatus } from '../../models/shared/operation-status';
import { BatchAllocation } from '../../models/batch-allocation/batch-allocation';
import { SearchBatchMatchingAssessorRequestParams } from '../../models/batch-allocation/search-batch-matching-assessor-request-params';
import { BatchMatchingAssessorResponse } from '../../models/batch-allocation/batch-matching-assessor-response';

//import environment variables 
import {environment} from '../../../environments/environment';

//#endregion

//#region service decorator & defination
@Injectable()
export class BatchAllocationService {

  //#region global level propertie/variables/models declaration & initlizations

  private batchAllocationRequestUrl: string = environment.apiUrl + 'BatchAllocation/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) {};

  //#region service decorator & defination

  /**
   * Method will return the of details of supplied BatchAllocationId
   */
  getBatchAllocationDetails(batchAllocationId: number) : Observable<any>
  {
    //debugger;
    //reference-url : http://{Path}/AMS.Services/api/BatchAllocation/1

    // comment : here manipulate url string
    this.requestUrl  = this.batchAllocationRequestUrl + batchAllocationId;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added BatchAllocation with supplied details/data
   */
  addBatchAllocation(batchAllocation: BatchAllocation): Observable<OperationStatus> {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/BatchAllocation

    // comment : here manipulate url string
    this.requestUrl = this.batchAllocationRequestUrl;

    this.addRequestHeaders();

    return this.http
      .post((this.requestUrl), JSON.stringify(batchAllocation), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will return list of Assessor data based on supplied search-params
   */
  searchBatchMatchingAssessors(searchParams: SearchBatchMatchingAssessorRequestParams): Observable<BatchMatchingAssessorResponse> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/BatchAllocation/Search?BatchId=386312

    // comment : here manipulate url string
    this.requestUrl  = this.batchAllocationRequestUrl + 'SearchAssessor';
    
    this.addRequestHeaders();

    return this.http
      .post(this.requestUrl, JSON.stringify(searchParams), this.requestOptions)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added BatchAllocation with supplied details/data
   */
  deleteBatchAllocation(batchMasterId: number,assessorId: number,batchAllocationId: number=0): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/BatchAllocation/{0/1}/BatchMaster/3/Assessor/61

    // comment : here manipulate url string
    this.requestUrl = this.batchAllocationRequestUrl +`${batchAllocationId || '0'}/BatchMaster/${batchMasterId || ''}/Assessor/${assessorId || ''}`;
    
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
