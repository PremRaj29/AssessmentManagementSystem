import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManageSchemeComponent } from '../components/masters/manage-scheme/manage-scheme.component';
import { AddSchemeComponent } from '../components/masters/manage-scheme/add-scheme/add-scheme.component';
import { ModifySchemeComponent } from '../components/masters/manage-scheme/modify-scheme/modify-scheme.component';
import { ListofSchemeComponent } from '../components/masters/manage-scheme/listof-scheme/listof-scheme.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ManageSchemeComponent, AddSchemeComponent, ModifySchemeComponent, ListofSchemeComponent]
})
export class ManageSchemeModule { }
