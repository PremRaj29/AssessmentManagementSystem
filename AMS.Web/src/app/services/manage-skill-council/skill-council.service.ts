//#region library imports

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

// all the RxJS related imports
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

// import Domain class
import { SkillCouncil } from '../../models/manage-skill-council/skill-council';
//import { AppConfigs } from '../../app.constants';

//#endregion

//#region service decorator & defination

@Injectable()
export class SkillCouncilService {
    private skillCouncils: Array<SkillCouncil> = null;
    private getSkillCouncilUrl: string = 'http://localhost/AMS.Services/api/CouncilType/';

    constructor(private http: Http) {}

    //#region public method

    addSkillCouncil(skillCouncil: SkillCouncil): any {    
        this.skillCouncils.push(skillCouncil);
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