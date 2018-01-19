import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageSkillCouncilComponent } from '../components/masters/manage-skill-council/manage-skill-council.component';
import { AddSkillCouncilComponent } from '../components/masters/manage-skill-council/add-skill-council/add-skill-council.component';
import { ModifySkillCouncilComponent } from '../components/masters/manage-skill-council/modify-skill-council/modify-skill-council.component';
import { ListofSkillCouncilComponent } from '../components/masters/manage-skill-council/listof-skill-council/listof-skill-council.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ManageSkillCouncilComponent, AddSkillCouncilComponent, ModifySkillCouncilComponent, ListofSkillCouncilComponent]
})
export class ManageSkillCouncilModule { }
