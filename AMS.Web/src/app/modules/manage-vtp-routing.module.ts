import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ManageVtpComponent } from '../components/masters/manage-vtp/manage-vtp.component';
import { AddVtpComponent } from '../components/masters/manage-vtp/add-vtp/add-vtp.component';
import { ModifyVtpComponent } from '../components/masters/manage-vtp/modify-vtp/modify-vtp.component';

export const routes : Routes = [
  { path: '', component: ManageVtpComponent },
  { path: 'add', component: AddVtpComponent },
  //{ path: 'modify', component: ModifyVtpComponent },
  { path: 'modify/:id', component: ModifyVtpComponent },
  //{ path: 'delete/:id', component: DeleteConfirmationComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManageVtpRoutingModule { }

/**
 * These are just a convention we should like to use to grab a set of the routed components, 
 * instead of having to re-import each component, one by one into main Module. like 'ManageMastersModule'
 */
export const routedVtpComponents = [ManageVtpComponent,AddVtpComponent,ModifyVtpComponent];