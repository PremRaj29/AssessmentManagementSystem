//#region library imports

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//custom components,service, pipe
import { AssessmentTimingPipe } from '../../pipes/assessment-timing.pipe';

//#endregion

//#region module decorator & defination

@NgModule({
  imports: [
    CommonModule, FormsModule
  ],
  declarations: [AssessmentTimingPipe]
  ,exports: [
    CommonModule, FormsModule,AssessmentTimingPipe
  ]
})
export class SharedModule { }

//#endregion
