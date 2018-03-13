import { NgModule,ModuleWithProviders  } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
//import { FormsModule }   from '@angular/forms';
import { RouterModule } from '@angular/router';
//import { HttpModule,JsonpModule } from '@angular/http';

//custom module
import { ManageJobRoleRoutingModule,routedJobRoleComponents } from './manage-job-role-routing.module';
import { SharedSkillcouncilComponentsModule} from '../modules/shared/shared-skillcouncil-components.module';
import { ListofJobRoleComponent } from '../components/masters/manage-job-role/listof-job-role/listof-job-role.component';

// custom providers
import { ListofSkillCouncilService } from '../services/shared/listof-skill-council.service';
import { JobRoleService } from '../services/manage-job-role/job-role.service';


@NgModule({
  imports: [
    CommonModule
    ,RouterModule
    //,FormsModule
    //,BrowserModule
    // ,HttpModule
    // ,JsonpModule

    // custom modules
    ,ManageJobRoleRoutingModule
    ,SharedSkillcouncilComponentsModule
  ],
  declarations: [routedJobRoleComponents, ListofJobRoleComponent],
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
