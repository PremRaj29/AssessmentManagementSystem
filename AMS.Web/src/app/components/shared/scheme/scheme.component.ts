import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { ListofSchemeService } from '../../../services/shared/listof-scheme.service';
import { Scheme } from '../../../models/manage-scheme/scheme';
import { SchemeResponse } from '../../../models/manage-scheme/scheme-response';

@Component({
  selector: 'app-scheme',
  templateUrl: './scheme.component.html',
  styleUrls: ['./scheme.component.css'],
  providers: [ListofSchemeService]
})
export class SchemeComponent implements OnInit {

  //interact with input & output of this components
  @Input('schemeId') schemeId: number;
  @Output('selectedScheme') selectedScheme = new EventEmitter<number>();

  public schemes: Array<Scheme> = null;

  isDataLoadingCompleted: boolean = false;

  constructor(private listofSchemeService: ListofSchemeService) { }

  ngOnInit() {
    this.getSchemes();
  }

  //#region public methods

  //#region get methods

  getSchemes() {

    // here get scheme-service obserable
    let observable = this.listofSchemeService.getSchemes();

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (schemeResponse: SchemeResponse) => {
        debugger;

        // if service has returned valid response then only
        if (schemeResponse != null && schemeResponse.OperationStatus.RequestSuccessful) {
          // reset skillcouncil data
          this.schemes = schemeResponse.Scheme;
          //console.log(schemeResponse.Scheme);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while loading Schemes: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('Schemes loading completed'); }
      );
  }

  //#endregion

  onItemChange(data: any) {
    debugger;
    this.selectedScheme.emit(data);
  }


  //#endregion
}

