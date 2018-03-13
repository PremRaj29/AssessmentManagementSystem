//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

import { SearchSkillCouncilsRequestParams } from '../../models/manage-skill-council/search-skill-councils-request-params';
import { SkillCouncil } from '../../models/manage-skill-council/skill-council';
import { OperationStatus } from '../../models/shared/operation-status';
import { SkillCouncilResponse } from '../../models/manage-skill-council/skill-council-response';

import {environment} from '../../../environments/environment';

// import Domain class

//#endregion

//#region service decorator & defination

@Injectable()
export class SkillCouncilService {

    //#region global level propertie/variables/models declaration & initlizations
  
    private skillCouncilRequestUrl: string = environment.apiUrl + 'CouncilType/';
    private requestUrl: string = null;
    private requestOptions: RequestOptions;
  
    //#endregion 
    constructor(private http: Http) { };
  
    //#region service decorator & defination
  
    /**
     * Method will return the details of supplied SkillCouncilId
     */
    getSkillCouncilDetails(skillCouncilId: number,CouncilTypeId?: number) : Observable<SkillCouncilResponse>
    {
      debugger;
      //reference-url : http://{Path}/AMS.Services/CouncilType/2/SkillCouncil/10
  
      // comment : here manipulate url string
      this.requestUrl  = this.skillCouncilRequestUrl + `${CouncilTypeId || '0'}/SkillCouncil/${skillCouncilId || ''}`;
  
      return this.http
        .get(this.requestUrl)
        .map(this.parseData)
        .catch(this.handleError);
    };
  
    /**
     * Method will return list of SkillCouncils data based on supplied search-params
     */
    searchSkillCouncils(searchParams: SearchSkillCouncilsRequestParams) : Observable<SkillCouncilResponse>
    {
      debugger;
      //reference-url : http://{Path}}/AMS.Services/CouncilType/SkillCouncil/Search?Code=TEST
  
      // comment : here manipulate url string
      this.requestUrl  = this.skillCouncilRequestUrl +`SkillCouncil/Search?Code=${searchParams.Code || ''}&Name=${searchParams.Name || ''}&SkillCouncilTypeId=${searchParams.SkillCouncilTypeId}`;
  
      return this.http
        .get(this.requestUrl)
        .map(this.parseData)
        .catch(this.handleError);
    };
  
    /**
     * Method will POST newly added SkillCouncils with supplied details/data
     */
    addSkillCouncil(skillCouncil: SkillCouncil): Observable<OperationStatus> 
    {
      debugger;
      //reference-url : http://{Path}}/AMS.Services/api/CouncilType/{councilTypeId}/SkillCouncil
  
      // comment : here manipulate url string
      this.requestUrl = this.skillCouncilRequestUrl + `${skillCouncil.CouncilTypeId || '0'}/SkillCouncil`;
      
      this.addRequestHeaders();
        
      return this.http
          .post((this.requestUrl), JSON.stringify(skillCouncil), this.requestOptions)
          .map(this.parseData)
          .catch(this.handleError);
    };
  
    /**
     * Method will PUT/UPDATE existing added SkillCouncils with supplied details/data
     */
    modifySkillCouncil(skillCouncil: SkillCouncil): Observable<OperationStatus> 
    {
      debugger;
      //reference-url : http://{Path}/AMS.Services/api/CouncilType/2/SkillCouncil
  
      // comment : here manipulate url string
      this.requestUrl = this.skillCouncilRequestUrl +`${skillCouncil.CouncilTypeId || ''}/SkillCouncil/${skillCouncil.Id || ''}`;
      
      this.addRequestHeaders();
        
      return this.http
          .put((this.requestUrl), JSON.stringify(skillCouncil), this.requestOptions)
          .map(this.parseData)
          .catch(this.handleError);
    };
  
    /**
     * Method will DELETE/REMOVE existing added SkillCouncils with supplied details/data
     */
    deleteSkillCouncil(skillCouncil: SkillCouncil): Observable<OperationStatus> 
    {
      debugger;
      //reference-url : http://{Path}/AMS.Services/api/CouncilType/2/SkillCouncil/9
  
      // comment : here manipulate url string
      this.requestUrl = this.skillCouncilRequestUrl  +`${skillCouncil.CouncilTypeId || ''}/SkillCouncil/${skillCouncil.Id || ''}`;
      
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