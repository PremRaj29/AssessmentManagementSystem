import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ManageSchemeComponent } from '../components/masters/manage-scheme/manage-scheme.component';
import { AddSchemeComponent } from '../components/masters/manage-scheme/add-scheme/add-scheme.component';
import { ModifySchemeComponent } from '../components/masters/manage-scheme/modify-scheme/modify-scheme.component';

export const routes : Routes = [
  { path: '', component: ManageSchemeComponent },
  { path: 'add', component: AddSchemeComponent },
  //{ path: 'modify', component: ModifySkillCouncilComponent },
  { path: 'modify/:id', component: ModifySchemeComponent },
  //{ path: 'delete/:id', component: DeleteConfirmationComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManageSchemeRoutingModule { }

/**
 * These are just a convention we should like to use to grab a set of the routed components, 
 * instead of having to re-import each component, one by one into main Module. like 'ManageMastersModule'
 */
export const routedSchemeComponents = [ManageSchemeComponent,AddSchemeComponent,ModifySchemeComponent];