import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//import custom components
import {ManageSkillCouncilRoutingModule,routedSkillCouncilComponents} from '../modules/manage-skill-council-routing.module';
import { SharedSkillcouncilComponentsModule} from '../modules/shared/shared-skillcouncil-components.module';
import { ListofSkillCouncilComponent } from '../components/masters/manage-skill-council/listof-skill-council/listof-skill-council.component';

// custom providers
import { SkillCouncilService } from '../services/manage-skill-council/skill-council.service';

@NgModule({
  imports: [
    CommonModule,
    ManageSkillCouncilRoutingModule,
    SharedSkillcouncilComponentsModule
  ],
  declarations: [routedSkillCouncilComponents,ListofSkillCouncilComponent],
  providers: [SkillCouncilService]
})
export class ManageSkillCouncilModule { }
