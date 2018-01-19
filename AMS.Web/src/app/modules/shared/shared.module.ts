//#region library imports

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

//#endregion

//#region module decorator & defination

@NgModule({
  imports: [
    CommonModule, FormsModule
  ],
  declarations: []
  ,exports: [
    CommonModule, FormsModule
  ]
})
export class SharedModule { }

//#endregion
