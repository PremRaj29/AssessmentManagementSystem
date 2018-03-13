//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
//import {Location} from '@angular/common';

// import Domain class
import { Scheme } from '../../../models/manage-scheme/scheme';
import { SchemeResponse } from '../../../models/manage-scheme/scheme-response';

// import required services for this component
//import { SearchSchemesRequestParams } from '../../../models/manage-scheme/search-schemes-request-params';
import { ListofSchemeComponent } from './listof-scheme/listof-scheme.component';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-manage-scheme',
  templateUrl: './manage-scheme.component.html',
  styleUrls: ['./manage-scheme.component.css']
})
export class ManageSchemeComponent implements OnInit 
{

  //#region component global level propertie/variables/models declaration & initlizations

  public skillCouncils: Array<Scheme> = null;

  searchParams: any = {
      Code: '',
      Name: null
  };

  isDataLoadingCompleted: boolean = false;
  selectedSchemeId : 0;

  // get acess to Child-component
  @ViewChild(ListofSchemeComponent) private childCompListofScheme: ListofSchemeComponent;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private router: Router,private route: ActivatedRoute) { }

  ngOnInit() {
  }

  //#endregion 

  //#region public methods

  //#endregion

  //#region event handlers methods

  public searchSchemes() {
      this.childCompListofScheme.searchSchemes(this.searchParams);
  }

  public resetSearchPanel() {
      this.searchParams = {
          Code: null,
          Name: null
      };
  }

  public parentMethod(childData: any) 
  {
      this.selectedSchemeId = childData;  
      this.router.navigate(['./modify', childData], { relativeTo: this.route });      
  }

  //#endregion

}

//#endregion