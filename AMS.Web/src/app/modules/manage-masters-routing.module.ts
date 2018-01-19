import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent} from '../components/masters/dashboard/dashboard.component';
//import { ManageJobRoleComponent} from '../components/masters/manage-job-role/manage-job-role.component';
import { ManageSchemeComponent} from '../components/masters/manage-scheme/manage-scheme.component';
import { ManageVtpComponent} from '../components/masters/manage-vtp/manage-vtp.component';
import { ManageSkillCouncilComponent } from '../components/masters/manage-skill-council/manage-skill-council.component';

export const routes : Routes = [
  //{ path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '', component: DashboardComponent },
  //{ path: 'job-role', component: ManageJobRoleComponent },
  { path: 'job-role', loadChildren: './manage-job-role.module#ManageJobRoleModule' },
  { path: 'scheme', component: ManageSchemeComponent },
  { path: 'vtp', component: ManageVtpComponent },
  { path: 'skill-council', component: ManageSkillCouncilComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManageMastersRoutingModule { }

/**
 * These are just a convention we should like to use to grab a set of the routed components, 
 * instead of having to re-import each component, one by one into main Module. like 'ManageMastersModule'
 */
export const routedComponents = [DashboardComponent];
