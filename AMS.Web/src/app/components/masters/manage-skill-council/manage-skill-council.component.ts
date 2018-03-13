//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
//import {Location} from '@angular/common';

// import Domain class
import { SkillCouncil } from '../../../models/manage-skill-council/skill-council';
import { SkillCouncilResponse } from '../../../models/manage-skill-council/skill-council-response';

// import required services for this component
import { SearchSkillCouncilsRequestParams } from '../../../models/manage-skill-council/search-skill-councils-request-params';
import { ListofSkillCouncilComponent } from './listof-skill-council/listof-skill-council.component';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-manage-skill-council',
  templateUrl: './manage-skill-council.component.html',
  styleUrls: ['./manage-skill-council.component.css']
})
export class ManageSkillCouncilComponent implements OnInit {

  //#region component global level propertie/variables/models declaration & initlizations

  public skillCouncils: Array<SkillCouncil> = null;

  searchParams: any = {
      Code: '',
      Name: null,
      SkillCouncilTypeId: 0,
      SkillCouncilId: null
  };

  //selectedCouncilType: number = 0;
  //selectedSkillCouncil: number = null;
  isDataLoadingCompleted: boolean = false;
  selectedSkillCouncilId : 0;

  // get acess to Child-component
  @ViewChild(ListofSkillCouncilComponent) private childCompListofSkillCouncil: ListofSkillCouncilComponent;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private router: Router,private route: ActivatedRoute) { }

  ngOnInit() {
  }

  //#endregion 

  //#region public methods

  //#endregion

  //#region event handlers methods

  public councilTypeSelected(childData: any) {
      if (childData != 0) {
          this.searchParams.SkillCouncilTypeId = childData;
          //this.getSkillCouncils();
      }
  }

  public searchSkillCouncils() {
      this.childCompListofSkillCouncil.searchSkillCouncils(this.searchParams);
  }

  public resetSearchPanel() {
      this.searchParams = {
          Code: null,
          Name: null,
          SkillCouncilTypeId: 0,
          SkillCouncilId: null
      };
  }

  public parentMethod(childData: any) {
      this.selectedSkillCouncilId = childData;  
      this.router.navigate(['./modify', childData], { relativeTo: this.route });      
  }

  //#endregion

}

//#endregion