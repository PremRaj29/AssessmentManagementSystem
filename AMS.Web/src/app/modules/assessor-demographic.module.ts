import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';
import { HttpModule,JsonpModule } from '@angular/http';

import { AssessorDemographicRoutingModule } from './assessor-demographic-routing.module';

@NgModule({
  imports: [
    CommonModule
    ,FormsModule
    ,HttpModule
    ,JsonpModule
    ,AssessorDemographicRoutingModule
  ],
  declarations: []
})
export class AssessorDemographicModule { }
