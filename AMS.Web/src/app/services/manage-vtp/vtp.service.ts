//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { VocationalTrainingProvider } from '../../models/manage-vtp/vtp';
import { OperationStatus } from '../../models/shared/operation-status';
import { VocationalTrainingProviderResponse } from '../../models/manage-vtp/vtp-response';

import {environment} from '../../../environments/environment';

// import Domain class

//#endregion

//#region service decorator & defination

@Injectable()
export class VtpService {

  //#region global level propertie/variables/models declaration & initlizations

  private vtpRequestUrl: string = environment.apiUrl + 'VocationalTrainingProvider/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) { };

  //#region service decorator & defination

  /**
   * Method will return the details of supplied VtpId
   */
  getVtpDetails(vtpId: number) : Observable<VocationalTrainingProviderResponse>
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/VocationalTrainingProvider/10

    // comment : here manipulate url string
    this.requestUrl  = this.vtpRequestUrl + `${vtpId || ''}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will return list of VocationalTrainingProviders data based on supplied search-params
   */
  searchVtps(searchParams: any) : Observable<VocationalTrainingProviderResponse>
  {
    debugger;
    //reference-url : http://{Path}}/AMS.Services/VocationalTrainingProvider/Search?Code=TEST

    // comment : here manipulate url string
    this.requestUrl  = this.vtpRequestUrl +`Search?vtpCode=${searchParams.Code || ''}&vtpName=${searchParams.Name || ''}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added VocationalTrainingProviders with supplied details/data
   */
  addVtp(vtp: VocationalTrainingProvider): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}}/AMS.Services/api/VocationalTrainingProvider

    // comment : here manipulate url string
    this.requestUrl = this.vtpRequestUrl;
    
    this.addRequestHeaders();
      
    return this.http
        .post((this.requestUrl), JSON.stringify(vtp), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added VocationalTrainingProviders with supplied details/data
   */
  modifyVtp(vtp: VocationalTrainingProvider): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/VocationalTrainingProvider

    // comment : here manipulate url string
    this.requestUrl = this.vtpRequestUrl +`${vtp.Id || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(vtp), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added VocationalTrainingProviders with supplied details/data
   */
  deleteVtp(vtp: VocationalTrainingProvider): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/VocationalTrainingProvider/9

    // comment : here manipulate url string
    this.requestUrl = this.vtpRequestUrl  +`${vtp.Id || ''}`;
    
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