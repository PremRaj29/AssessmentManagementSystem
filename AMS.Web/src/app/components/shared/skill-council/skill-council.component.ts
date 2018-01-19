import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

import { ListofSkillCouncilService } from '../../../services/shared/listof-skill-council.service';
import { SkillCouncil } from '../../../models/manage-skill-council/skill-council';
import { SkillCouncilResponse } from '../../../models/manage-skill-council/skill-council-response';

@Component({
  selector: 'app-skill-council',
  templateUrl: './skill-council.component.html',
  styleUrls: ['./skill-council.component.css'],
  providers: [ListofSkillCouncilService],
})
export class SkillCouncilComponent implements OnInit, OnChanges {

  //interact with input & output of this components
  @Input('skillCouncilTypeId') skillCouncilTypeId: number;
  @Input('skillCouncilId') skillCouncilId: number = null;
  @Output('selectedSkillCouncil') selectedSkillCouncil = new EventEmitter<number>();

  public skillCouncils: Array<SkillCouncil> = null;

  isDataLoadingCompleted: boolean = false;
  constructor(private listofSkillCouncilService: ListofSkillCouncilService) { }

  ngOnInit() {
  }

  /**
   * 
   * @param changes Method will keep watch on @Input control value based on that take action
   */
  ngOnChanges(changes: SimpleChanges) 
  {
    debugger;

    //call only when eigther input has some valid value & change in "SkillTypeId"
    if (changes['skillCouncilTypeId'] != undefined && changes['skillCouncilTypeId'].currentValue != null) 
    {
      //#region Custom logic to resolve dependetn DDL binding/auto select issue on page LOAD

      /**
       * Reset selected value ["skillCouncilId"] of this (CHILD- SkillCouncil) component 
       * only when components already have some data (this.skillCouncils.length >0) otherwise no need.  
       */

      if (this.skillCouncils != null && this.skillCouncils.length > 0) {
        this.skillCouncils = null;
        this.skillCouncilId = null;
      }

      //#endregion

      //#region process further only if Valid "skillCouncilId" is there

      //process further only if Valid "SkillCouncilTypeId" is there
      if (!(this.skillCouncilTypeId > 0)) {
        return;
      }

      //otherwise load child compList data
      this.getSkillCouncils();

      //#endregion
    }
  }

  //#region public methods

  //#region get methods

  getSkillCouncils() {

    debugger;

    // here get Question obserable
    let observable = this.listofSkillCouncilService.getSkillCouncils(this.skillCouncilTypeId);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (skillCouncilResponse: SkillCouncilResponse) => {
        debugger;

        // if service has returned valid response then only
        if (skillCouncilResponse != null && skillCouncilResponse.OperationStatus.RequestSuccessful) {
          //this.skillCouncilId = null;

          // reset skillcouncil data
          this.skillCouncils = skillCouncilResponse.SkillCouncil;

          //also reset selectedId comp output
          this.selectedSkillCouncil.emit(this.skillCouncilId);
          //console.log(skillCouncilResponse.SkillCouncil);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while loading SkillCouncils: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('SkillCouncils loading completed'); }
      );
  }

  //#endregion

  onItemChange(data: any) {
    debugger;
    this.selectedSkillCouncil.emit(data);
  }


  //#endregion
}
