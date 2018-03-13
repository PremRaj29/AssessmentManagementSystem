//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { IdProofTypeResponse } from '../../models/manage-id-proof-type/id-proof-type-response';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { environment } from '../../../environments/environment';

// import Domain class

//#endregion

//#region service decorator & defination

@Injectable()
export class ListofIdProofDocTypeServiceService 
{
  
  //#region global level propertie/variables/models declaration & initlizations

  private idProofTypeRequestUrl: string = environment.apiUrl + 'IdProofDocumentType/';
  private requestUrl: string = null;
  private requestOptions: RequestOptions;

  //#endregion 
  constructor(private http: Http) { };

  //#region service decorator & defination

  /**
   * Method will return list of IdProofTypes based on id i.e. specific or all
   */
  getIdProofTypes(idProofTypeId?: number) : Observable<IdProofTypeResponse>
  {
    debugger;
    //reference-url : http://{Path}/AMS.Services/IdProofType/2

    // comment : here manipulate url string
    this.requestUrl  = this.idProofTypeRequestUrl + `${idProofTypeId || '0'}`;

    return this.http
      .get(this.requestUrl)
      .map(this.parseData)
      .catch(this.handleError);
  };

  //#endregion

  //#region private methods

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
