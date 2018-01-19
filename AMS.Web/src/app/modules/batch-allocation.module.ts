import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';
import { HttpModule,JsonpModule } from '@angular/http';

//import cutom modules
import { BatchAllocationComponent } from '../components/batch-master/batch-allocation/batch-allocation.component';
import { BatchDetailsComponent } from '../components/batch-master/batch-allocation/batch-details/batch-details.component';
import { AssessorListComponent } from '../components/batch-master/batch-allocation/assessor-list/assessor-list.component';

@NgModule({
  imports: [
    CommonModule
    ,FormsModule
    ,HttpModule
    ,JsonpModule
  ],
  declarations: [BatchAllocationComponent,BatchDetailsComponent, AssessorListComponent],
  exports:[]
})
export class BatchAllocationModule { }
