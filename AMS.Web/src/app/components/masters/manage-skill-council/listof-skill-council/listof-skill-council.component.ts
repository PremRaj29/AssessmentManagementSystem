//#region library imports

import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';

// import reuired services for this component
import {SkillCouncilService} from '../../../../services/manage-skill-council/skill-council.service';
import { SkillCouncilResponse } from '../../../../models/manage-skill-council/skill-council-response';
import {} from '../../';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-listof-skill-council',
  templateUrl: './listof-skill-council.component.html',
  styleUrls: ['./listof-skill-council.component.css']
})
export class ListofSkillCouncilComponent implements OnInit 
{
  //#region component global level propertie/variables/models declaration & initlizations

  @Output('selectedSkillCouncil') selectedSkillCouncil = new EventEmitter<string>();
  isDataLoadingCompleted: boolean = true;
  searchedSkillCouncils: any = null;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private skillCouncilService: SkillCouncilService) { }
  
  ngOnInit() { }

  //#endregion 

  //#region public methods

  public searchSkillCouncils(skillCouncilSearchParams: any)
  {
    //alert('Working Child');

    //reset data every time before calling
    this.searchedSkillCouncils =  null;
    this.isDataLoadingCompleted = null;

    // here get Question obserable
    let observable = this.skillCouncilService.searchSkillCouncils(skillCouncilSearchParams);

    let subscription = observable.subscribe
        (
            // calls the onNext() function in the observer
            (searchedSkillCouncilResponse: SkillCouncilResponse) =>
            {
              debugger;

                // if service has returned valid response then only
                if (searchedSkillCouncilResponse != null 
                    && searchedSkillCouncilResponse.OperationStatus.RequestSuccessful == true
                    && searchedSkillCouncilResponse.SkillCouncil.length >0
                  )
                {
                    this.searchedSkillCouncils = searchedSkillCouncilResponse.SkillCouncil;
                    console.log(searchedSkillCouncilResponse);
                }
                else
                {
                    // show error message on screen
                }
            },

            // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
            // here we can also call our logger service to log this exception
            (error: string) => console.log('error while searching SkillCouncils: ' + error),

            // calls the onComplete() function in the observer
            () => { this.isDataLoadingCompleted = true; console.log('SkillCouncils searching completed'); subscription.unsubscribe(); }
        );
  }

  //#endregion 

  //#region private methods
  
  onRowClick(event, id) 
  {
    debugger;
    //console.log(event.target.outerText, id);  //cell/column text = outerText; row-id : "id" param
    //alert(event.target.outerText);
    
    //event.currentTarget.style.backgroundColor="red";
    //alert(event.t);

    //alert(id);
    this.selectedSkillCouncil.emit(id);
  }
  
  //#endregion

}

//#endregion