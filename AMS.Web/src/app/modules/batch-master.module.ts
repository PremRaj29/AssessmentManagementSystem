import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
//import { FormsModule }   from '@angular/forms';
import { HttpModule,JsonpModule } from '@angular/http';

//import custom modules
import { BatchMasterRoutingModule,routedBatchMasterComponents } from './batch-master-routing.module';
import { SharedCustomComponentsModule } from '../modules/shared/shared-custom-components.module';
import { SharedCommonComponentsModule } from '../modules/shared/shared-common-components.module';
import { SharedSkillcouncilComponentsModule} from '../modules/shared/shared-skillcouncil-components.module';
import { SharedModule } from '../modules/shared/shared.module';

// import { SkillCouncilTypeComponent} from '../components/shared/skill-council-type/skill-council-type.component';
// import { SkillCouncilComponent} from '../components/shared/skill-council/skill-council.component';
// import { JobRoleComponent } from '../components/shared/job-role/job-role.component';
// import { SchemeComponent } from '../components/shared/scheme/scheme.component';
// import { VtpComponent } from '../components/shared/vtp/vtp.component';
// import { StateComponent } from '../components/shared/geography/state/state.component';
// import { CityComponent } from '../components/shared/geography/city/city.component';

//service
import { BatchMasterService } from '../services/batch-master/batch-master.service';
import { ListofBatchMasterComponent } from '../components/batch-master/listof-batch-master/listof-batch-master.component';
import { BatchAllocationModule } from './batch-allocation.module';

@NgModule({
  imports: [
    CommonModule
    //,FormsModule
    ,HttpModule
    ,JsonpModule
    ,BatchMasterRoutingModule
    ,BatchAllocationModule
    ,SharedCommonComponentsModule
    ,SharedCustomComponentsModule
    ,SharedSkillcouncilComponentsModule
    ,SharedModule
  ],
  declarations: [
    routedBatchMasterComponents
    //,SkillCouncilTypeComponent,SkillCouncilComponent, JobRoleComponent, SchemeComponent, VtpComponent,StateComponent, CityComponent
    , ListofBatchMasterComponent
  ],
  providers:[BatchMasterService]
})
export class BatchMasterModule { }
