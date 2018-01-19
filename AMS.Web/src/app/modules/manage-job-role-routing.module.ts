import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ManageJobRoleComponent} from '../components/masters/manage-job-role/manage-job-role.component';
import { AddJobRoleComponent } from '../components/masters/manage-job-role/add-job-role/add-job-role.component';
import { ModifyJobRoleComponent } from '../components/masters/manage-job-role/modify-job-role/modify-job-role.component';

export const routes : Routes = [
  { path: '', component: ManageJobRoleComponent },
  { path: 'add', component: AddJobRoleComponent },
  //{ path: 'modify', component: ModifyJobRoleComponent },
  { path: 'modify/:id', component: ModifyJobRoleComponent },
  //{ path: 'delete/:id', component: DeleteConfirmationComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManageJobRoleRoutingModule { }

/**
 * These are just a convention we should like to use to grab a set of the routed components, 
 * instead of having to re-import each component, one by one into main Module. like 'ManageMastersModule'
 */
export const routedJobRoleComponents = [ManageJobRoleComponent,AddJobRoleComponent,ModifyJobRoleComponent];
