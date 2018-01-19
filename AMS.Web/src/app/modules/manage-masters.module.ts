import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { FormsModule }   from '@angular/forms';
import { HttpModule,JsonpModule } from '@angular/http';

//import custom modules under main Manage-Master-Module
import { ManageMastersRoutingModule,routedComponents } from './manage-masters-routing.module';
import { ManageJobRoleModule } from './manage-job-role.module';
import { ManageSchemeModule } from './manage-scheme.module';
import { ManageVtpModule } from './manage-vtp.module';
import { ManageSkillCouncilModule } from './manage-skill-council.module';

//import custom components
import { DashboardComponent } from '../components/masters/dashboard/dashboard.component';

@NgModule({
  imports: [
    CommonModule
    //,FormsModule
    ,HttpModule
    ,JsonpModule
    
    // custom modules
    ,ManageMastersRoutingModule
    //,ManageJobRoleModule
    ,ManageSchemeModule
    ,ManageVtpModule
    ,ManageSkillCouncilModule
  ],
  declarations: [
    DashboardComponent
  ]
})
export class ManageMastersModule { }
