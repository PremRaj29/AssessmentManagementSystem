//#region library imports

//import built-in angular libraries
import { Routes, RouterModule } from '@angular/router';
import { Router, ActivatedRoute, Params } from '@angular/router';

//import user-defined components
import { DashboardComponent} from './components/dashboard/dashboard.component';

//#endregion

//#region export routes configuration

//route configuration
export const routes : Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: DashboardComponent },
    { path: 'manage-masters', loadChildren: './modules/manage-masters.module#ManageMastersModule' },
    { path: 'batch-master', loadChildren: './modules/batch-master.module#BatchMasterModule' },
    { path: 'assessor-demographic', loadChildren: './modules/assessor-demographic.module#AssessorDemographicModule' },
    //{ path: 'post-assessment', loadChildren: './modules/post-assessment.module#PostAssessmentModule' }

    //just for reference Lazy-Module loading
    //{ path: 'eager', redirectTo: 'home', pathMatch: 'full' },
    //{ path: 'lazy', loadChildren: './modules/manage-masters.module#ManageMastersModule' }
];

export const AppRouterModule = RouterModule.forRoot(routes, { useHash: true });

//#endregion