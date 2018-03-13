//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { Scheme } from '../../models/manage-scheme/scheme';
import { OperationStatus } from '../../models/shared/operation-status';
import { SchemeResponse } from '../../models/manage-scheme/scheme-response';

import {environment} from '../../../environments/environment';

// import Domain class

//#endregion

//#region service decorator & defination

@Injectable()
export class SchemeService {

  //#region global level propertie/variables/models declaration & initlizations

  private schemeRequestUrl: string = environment.apiUrl + 'Scheme/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) { };

  //#region service decorator & defination

  /**
   * Method will return the details of supplied SchemeId
   */
  getSchemeDetails(schemeId: number) : Observable<SchemeResponse>
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/Scheme/10

    // comment : here manipulate url string
    this.requestUrl  = this.schemeRequestUrl + `${schemeId || ''}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will return list of Schemes data based on supplied search-params
   */
  searchSchemes(searchParams: any) : Observable<SchemeResponse>
  {
    debugger;
    //reference-url : http://{Path}}/AMS.Services/Scheme/Search?Code=TEST

    // comment : here manipulate url string
    this.requestUrl  = this.schemeRequestUrl +`Search?schemeCode=${searchParams.Code || ''}&schemeName=${searchParams.Name || ''}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  /**
   * Method will POST newly added Schemes with supplied details/data
   */
  addScheme(scheme: Scheme): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}}/AMS.Services/api/Scheme

    // comment : here manipulate url string
    this.requestUrl = this.schemeRequestUrl;
    
    this.addRequestHeaders();
      
    return this.http
        .post((this.requestUrl), JSON.stringify(scheme), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will PUT/UPDATE existing added Schemes with supplied details/data
   */
  modifyScheme(scheme: Scheme): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/Scheme

    // comment : here manipulate url string
    this.requestUrl = this.schemeRequestUrl +`${scheme.Id || ''}`;
    
    this.addRequestHeaders();
      
    return this.http
        .put((this.requestUrl), JSON.stringify(scheme), this.requestOptions)
        .map(this.parseData)
        .catch(this.handleError);
  };

  /**
   * Method will DELETE/REMOVE existing added Schemes with supplied details/data
   */
  deleteScheme(scheme: Scheme): Observable<OperationStatus> 
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/api/Scheme/9

    // comment : here manipulate url string
    this.requestUrl = this.schemeRequestUrl  +`${scheme.Id || ''}`;
    
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