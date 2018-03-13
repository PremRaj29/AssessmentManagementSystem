import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//import custom Modules & Components 
import { SkillCouncilTypeComponent } from '../../components/shared/skill-council-type/skill-council-type.component';
import { SkillCouncilComponent } from '../../components/shared/skill-council/skill-council.component';
import { JobRoleComponent } from '../../components/shared/job-role/job-role.component';

@NgModule({
  imports: [
    CommonModule
    ,FormsModule
  ]
  ,declarations: [SkillCouncilTypeComponent,SkillCouncilComponent,JobRoleComponent]
  ,exports:[FormsModule,SkillCouncilTypeComponent,SkillCouncilComponent,JobRoleComponent]
})
export class SharedSkillcouncilComponentsModule { }
