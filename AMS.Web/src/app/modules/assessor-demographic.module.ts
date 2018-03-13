import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';
import { HttpModule,JsonpModule } from '@angular/http';

//import custom modules
import { AssessorDemographicRoutingModule,routedAssessorDemographicComponents } from './assessor-demographic-routing.module';
import { SharedCommonComponentsModule } from '../modules/shared/shared-common-components.module';

//import components & services
import { AssessorService } from '../services/assessor-demographic/assessor.service';
import { ListofAssessorComponent } from '../components/assessor-demographic/listof-assessor/listof-assessor.component';

//import all other "Assessor" child components
import {PersonalDetailComponent} from '../components/assessor-demographic/add-assessor/personal-detail/personal-detail.component';
import { CommunicationDetailComponent } from '../components/assessor-demographic/add-assessor/communication-detail/communication-detail.component';
import { OtherDetailComponent } from '../components/assessor-demographic/add-assessor/other-detail/other-detail.component';
//Grid data components
import { JobRoleDetailComponent } from '../components/assessor-demographic/add-assessor/job-role-detail/job-role-detail.component';
import { PreferredLocationDetailComponent } from '../components/assessor-demographic/add-assessor/preferred-location-detail/preferred-location-detail.component';
import { IdProofDocsDetailComponent } from '../components/assessor-demographic/add-assessor/id-proof-docs-detail/id-proof-docs-detail.component';

//import shared "SkillCouncil" module
import { SharedSkillcouncilComponentsModule} from '../modules/shared/shared-skillcouncil-components.module';


@NgModule({
  imports: [
    CommonModule
    ,FormsModule
    ,HttpModule
    ,JsonpModule
    ,AssessorDemographicRoutingModule
    ,SharedCommonComponentsModule
    ,SharedSkillcouncilComponentsModule
  ],
  declarations: [routedAssessorDemographicComponents,ListofAssessorComponent,PersonalDetailComponent,CommunicationDetailComponent
      ,OtherDetailComponent,JobRoleDetailComponent,PreferredLocationDetailComponent,IdProofDocsDetailComponent ],
  providers: [AssessorService]
})
export class AssessorDemographicModule { }
