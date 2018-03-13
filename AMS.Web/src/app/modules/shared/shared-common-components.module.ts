import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//import custom Modules & Components 
import { StateComponent } from '../../components/shared/geography/state/state.component';
import { CityComponent } from '../../components/shared/geography/city/city.component';
import { IdProofDocumentTypeComponent } from '../../components/shared/id-proof-document-type/id-proof-document-type.component';

@NgModule({
  imports: [
    CommonModule,FormsModule
  ]
  ,declarations: [StateComponent,CityComponent,IdProofDocumentTypeComponent]
  ,exports: [FormsModule,StateComponent,CityComponent,IdProofDocumentTypeComponent]
})
export class SharedCommonComponentsModule { }
