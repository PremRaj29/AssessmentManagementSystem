import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//import custom components
import {ManageSchemeRoutingModule,routedSchemeComponents} from '../modules/manage-scheme-routing.module';
import { ListofSchemeComponent } from '../components/masters/manage-scheme/listof-scheme/listof-scheme.component';

// custom providers
import { SchemeService } from '../services/manage-scheme/scheme.service';

@NgModule({
  imports: [
    CommonModule
    ,FormsModule
    ,ManageSchemeRoutingModule
  ],
  declarations: [routedSchemeComponents, ListofSchemeComponent],
  providers: [SchemeService]
})
export class ManageSchemeModule { }
