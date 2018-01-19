import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//import custom components
import { BatchMasterComponent } from '../components/batch-master/batch-master.component';
import { AddBatchMasterComponent } from '../components/batch-master/add-batch-master/add-batch-master.component';
import { ModifyBatchMasterComponent } from '../components/batch-master/modify-batch-master/modify-batch-master.component';
import { BatchAllocationComponent } from '../components/batch-master/batch-allocation/batch-allocation.component';

export const routes: Routes = [
  { path: '', component: BatchMasterComponent },
  { path: 'add', component: AddBatchMasterComponent },
  { path: 'modify/:id', component: ModifyBatchMasterComponent },
  { path: 'allocate-batch', component: BatchAllocationComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BatchMasterRoutingModule { }

/**
 * These are just a convention we should like to use to grab a set of the routed components, 
 * instead of having to re-import each component, one by one into main Module. like 'ManageMastersModule'
 */
export const routedJobRoleComponents = [BatchMasterComponent,AddBatchMasterComponent,ModifyBatchMasterComponent];
