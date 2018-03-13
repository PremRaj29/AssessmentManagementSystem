import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ManageSkillCouncilComponent } from '../components/masters/manage-skill-council/manage-skill-council.component';
import { AddSkillCouncilComponent } from '../components/masters/manage-skill-council/add-skill-council/add-skill-council.component';
import { ModifySkillCouncilComponent } from '../components/masters/manage-skill-council/modify-skill-council/modify-skill-council.component';

export const routes : Routes = [
  { path: '', component: ManageSkillCouncilComponent },
  { path: 'add', component: AddSkillCouncilComponent },
  //{ path: 'modify', component: ModifySkillCouncilComponent },
  { path: 'modify/:id', component: ModifySkillCouncilComponent },
  //{ path: 'delete/:id', component: DeleteConfirmationComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ManageSkillCouncilRoutingModule { }

/**
 * These are just a convention we should like to use to grab a set of the routed components, 
 * instead of having to re-import each component, one by one into main Module. like 'ManageMastersModule'
 */
export const routedSkillCouncilComponents = [ManageSkillCouncilComponent,AddSkillCouncilComponent,ModifySkillCouncilComponent];
