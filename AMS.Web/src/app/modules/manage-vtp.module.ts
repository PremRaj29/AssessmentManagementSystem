import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageVtpComponent } from '../components/masters/manage-vtp/manage-vtp.component';
import { AddVtpComponent } from '../components/masters/manage-vtp/add-vtp/add-vtp.component';
import { ModifyVtpComponent } from '../components/masters/manage-vtp/modify-vtp/modify-vtp.component';
import { ListofVtpComponent } from '../components/masters/manage-vtp/listof-vtp/listof-vtp.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ManageVtpComponent, AddVtpComponent, ModifyVtpComponent, ListofVtpComponent]
})
export class ManageVtpModule { }
