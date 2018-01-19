import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

// import shared modules
import { SharedModule } from './modules/shared/shared.module';

import { AppComponent } from './app.component';
import { AppRouterModule} from './app.routes';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { BatchMasterModule } from './modules/batch-master.module';


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
  ],
  imports: [
    BrowserModule
    ,SharedModule
    //,BatchMasterModule
    // ,HttpModule
    // ,JsonpModule
    ,AppRouterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
