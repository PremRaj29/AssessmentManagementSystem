import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  // { path: '', component: BatchMasterComponent },
  // { path: 'add', component: AddBatchMasterComponent },
  // { path: 'modify/:id', component: ModifyBatchMasterComponent },
  // { path: 'allocate-batch', component: BatchAllocationComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssessorDemographicRoutingModule { }

/**
 * These are just a convention we should like to use to grab a set of the routed components, 
 * instead of having to re-import each component, one by one into main Module. like 'ManageMastersModule'
 */
export const routedBatchMasterComponents = [];

