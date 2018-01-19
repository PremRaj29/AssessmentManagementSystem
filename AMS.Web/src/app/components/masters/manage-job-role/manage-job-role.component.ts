//#region library imports

import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
//import {Location} from '@angular/common';

// import Domain class
import { SkillCouncil } from '../../../models/manage-skill-council/skill-council';
import { SkillCouncilResponse } from '../../../models/manage-skill-council/skill-council-response';

// import required services for this component
import { ListofSkillCouncilService } from '../../../services/shared/listof-skill-council.service';
import { SearchJobRolesRequestParams } from '../../../models/manage-job-role/search-job-roles-request-params';
import { ListofJobRoleComponent } from './listof-job-role/listof-job-role.component';
import { log } from 'util';

//#endregion

//#region component decoratror & definations

@Component({
    selector: 'app-manage-job-role',
    templateUrl: './manage-job-role.component.html',
    styleUrls: ['./manage-job-role.component.css'],
    //providers: [ListofSkillCouncilService]
})
export class ManageJobRoleComponent implements OnInit {

    //#region component global level propertie/variables/models declaration & initlizations

    public skillCouncils: Array<SkillCouncil> = null;

    searchParams: any = {
        Code: 'Code-132',
        Name: null,
        SkillCouncilTypeId: 0,
        SkillCouncilId: null
    };

    //selectedCouncilType: number = 0;
    //selectedSkillCouncil: number = null;
    isDataLoadingCompleted: boolean = false;
    selectedJobRoleId : 0;

    // get acess to Child-component
    @ViewChild(ListofJobRoleComponent) private childCompListofJobRole: ListofJobRoleComponent;

    //#endregion

    //#region constructor and OnInit implementation

    constructor(private listofSkillCouncilService: ListofSkillCouncilService,private router: Router,private route: ActivatedRoute) { }

    ngOnInit() {
        // global function for closing window on click apart of model popup
        window.addEventListener("click", function (event) {
            if (event.target == document.getElementById('myModal')) {
                document.getElementById('myModal').style.display = "none";
            }
        });
    }

    //#endregion 

    //#region public methods

    //#region get methods

    getSkillCouncils() {
        // here get Question obserable
        let observable = this.listofSkillCouncilService.getSkillCouncils(this.searchParams.SkillCouncilTypeId);

        let subscription = observable.subscribe
            (
            // calls the onNext() function in the observer
            (skillCouncilResponse: SkillCouncilResponse) => {
                debugger;

                // if service has returned valid response then only
                if (skillCouncilResponse != null && skillCouncilResponse.OperationStatus.RequestSuccessful) {
                    // reset skillcouncil data
                    this.skillCouncils = skillCouncilResponse.SkillCouncil;
                    this.searchParams.SkillCouncilId = null;
                    //this.selectedSkillCouncil = null;

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
            () => { this.isDataLoadingCompleted = true; console.log('SkillCouncils loading completed'); subscription.unsubscribe(); }
            );
    }

    //#endregion

    //#endregion 

    //#region Private methods

    //model popup functionality
    openPopup() {
        document.getElementById('myModal').style.display = "block";
    }

    //model close functionality
    closePopup() {
        document.getElementById('myModal').style.display = "none";
    }

    //#endregion

    //#region event handlers methods

    public councilTypeSelected(childData: any) {
        if (childData != 0) {
            this.searchParams.SkillCouncilTypeId = childData;
            //this.getSkillCouncils();
        }
    }

    public skillCouncilChanged(childData: any) {
        if (childData != 0) {
            //set selected council-id from child component to current parent component property
            this.searchParams.SkillCouncilId = childData;
        }
    }

    public searchJobRoles() {
        this.childCompListofJobRole.searchJobRoles(this.searchParams);
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
        //alert('Selected JobRole Id : ' + (childData || ''));

        this.selectedJobRoleId = childData;
        //this.openPopup();
        //this.router.navigate(['./modify',childData,], { relativeTo: this.route });  
        this.router.navigate(['./modify', childData], { relativeTo: this.route });      
        //this.location.go( '/manage-masters/job-role/modify');
    }

    //#endregion

}

//#endregion