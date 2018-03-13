import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//import custom Modules & Components 
import { SchemeComponent } from '../../components/shared/scheme/scheme.component';
import { VtpComponent } from '../../components/shared/vtp/vtp.component';
//import { StateComponent } from '../../components/shared/geography/state/state.component';
//import { CityComponent } from '../../components/shared/geography/city/city.component';

@NgModule({
  imports: [
    CommonModule,FormsModule
  ]
  ,declarations: [SchemeComponent,VtpComponent]
  ,exports: [FormsModule,SchemeComponent,VtpComponent]
})
export class SharedCustomComponentsModule { }
