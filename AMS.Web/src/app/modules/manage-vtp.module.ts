import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//import custom components
import {ManageVtpRoutingModule,routedVtpComponents} from '../modules/manage-vtp-routing.module';
import { ListofVtpComponent } from '../components/masters/manage-vtp/listof-vtp/listof-vtp.component';

// custom providers
import { VtpService } from '../services/manage-vtp/vtp.service';

@NgModule({
  imports: [
    CommonModule
    ,FormsModule
    ,ManageVtpRoutingModule
  ],
  declarations: [routedVtpComponents, ListofVtpComponent],
  providers: [VtpService]
})
export class ManageVtpModule { }
