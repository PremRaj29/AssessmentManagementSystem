import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//import custom components
import { AssessorComponent } from '../components/assessor-demographic/assessor.component';
import { AddAssessorComponent } from '../components/assessor-demographic/add-assessor/add-assessor.component';
import { ModifyAssessorComponent } from '../components/assessor-demographic/modify-assessor/modify-assessor.component';

const routes: Routes = [
  { path: '', component: AssessorComponent },
  { path: 'add', component: AddAssessorComponent },
  { path: 'modify/:id', component: ModifyAssessorComponent },
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
export const routedAssessorDemographicComponents = [AssessorComponent,AddAssessorComponent,ModifyAssessorComponent];

