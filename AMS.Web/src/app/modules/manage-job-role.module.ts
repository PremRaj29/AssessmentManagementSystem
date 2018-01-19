import { NgModule,ModuleWithProviders  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';
import { RouterModule } from '@angular/router';
//import { HttpModule,JsonpModule } from '@angular/http';

//custom module
import { ManageJobRoleRoutingModule } from './manage-job-role-routing.module';
import {routedJobRoleComponents} from './manage-job-role-routing.module';
import { ListofJobRoleComponent } from '../components/masters/manage-job-role/listof-job-role/listof-job-role.component';

//these components will go into shared module which will be used into all other modules
import { SkillCouncilTypeComponent } from '../components/shared/skill-council-type/skill-council-type.component';
import { SkillCouncilComponent } from '../components/shared/skill-council/skill-council.component';

// custom providers
import { ListofSkillCouncilService } from '../services/shared/listof-skill-council.service';
import { JobRoleService } from '../services/manage-job-role/job-role.service';


@NgModule({
  imports: [
    CommonModule
    ,RouterModule
    ,FormsModule
    //,BrowserModule
    // ,HttpModule
    // ,JsonpModule

    // custom modules
    ,ManageJobRoleRoutingModule
  ],
  declarations: [routedJobRoleComponents, ListofJobRoleComponent,SkillCouncilTypeComponent,SkillCouncilComponent],
  providers: [ListofSkillCouncilService, JobRoleService]
})
export class ManageJobRoleModule { 
  // static forRoot(): ModuleWithProviders {
  //     return {
  //       ngModule: ManageJobRoleModule,
  //       providers: [SkillCouncilService]
  //     }
  // };
}
