//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { SkillCouncil } from '../../models/manage-skill-council/skill-council';

//#endregion

//#region service decorator & defination

@Injectable()
export class ListofSkillCouncilService {

  constructor(private http: Http) { };

  //#region service decorator & defination

  /**
   * Method will return list of SkillConuncils of requested CouncilType
   */
  getSkillCouncils(councilTypeId: number, skillCouncilId?: number) {
    debugger;
    //reference-url : http://localhost/AMS.Services/api/CouncilType/1/SkillCouncil/4

    // comment : here manipulate url string
    let requestUrl = `http://localhost/AMS.Services/api/CouncilType/${councilTypeId}/SkillCouncil/${skillCouncilId || ''}`;

    return this.http
      .get(requestUrl)
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
