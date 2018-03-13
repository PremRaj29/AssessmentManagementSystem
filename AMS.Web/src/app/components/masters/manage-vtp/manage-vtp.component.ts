//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
//import {Location} from '@angular/common';

// import Domain class
import { VocationalTrainingProvider } from '../../../models/manage-vtp/vtp';
import { VocationalTrainingProviderResponse } from '../../../models/manage-vtp/vtp-response';

// import required services for this component
import { ListofVtpComponent } from './listof-vtp/listof-vtp.component';

//#endregion

//#region component decoratror & definations

@Component({
  selector: 'app-manage-vtp',
  templateUrl: './manage-vtp.component.html',
  styleUrls: ['./manage-vtp.component.css']
})
export class ManageVtpComponent implements OnInit 
{

  //#region component global level propertie/variables/models declaration & initlizations

  public skillCouncils: Array<VocationalTrainingProvider> = null;

  searchParams: any = {
      Code: '',
      Name: null
  };

  isDataLoadingCompleted: boolean = false;
  selectedVtpId : 0;

  // get acess to Child-component
  @ViewChild(ListofVtpComponent) private childCompListofVtp: ListofVtpComponent;

  //#endregion

  //#region constructor and OnInit implementation

  constructor(private router: Router,private route: ActivatedRoute) { }

  ngOnInit() {
  }

  //#endregion 

  //#region public methods

  //#endregion

  //#region event handlers methods

  public searchVtps() {
      this.childCompListofVtp.searchVtps(this.searchParams);
  }

  public resetSearchPanel() {
      this.searchParams = {
          Code: null,
          Name: null
      };
  }

  public parentMethod(childData: any) 
  {
      this.selectedVtpId = childData;  
      this.router.navigate(['./modify', childData], { relativeTo: this.route });      
  }

  //#endregion

}

//#endregion