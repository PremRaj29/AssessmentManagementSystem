import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { State } from '../../../../models/geography/state';
import { ListofGeographyService } from '../../../../services/shared/listof-geography.service';
import { GeographyResponse } from '../../../../models/geography/geography-response';


@Component({
  selector: 'app-state',
  templateUrl: './state.component.html',
  styleUrls: ['./state.component.css'],
  providers: [ListofGeographyService]
})
export class StateComponent implements OnInit {

  //interact with input & output of this components
  @Input('stateId') stateId: number;
  @Output('selectedState') selectedState = new EventEmitter<number>();

  public states: Array<State> = null;

  isDataLoadingCompleted: boolean = false;

  constructor(private listofGeographyService: ListofGeographyService) { }

  ngOnInit() {
    this.getStates();
  }

  //#region public methods

  //#region get methods

  getStates() {

    debugger;
    // here get geography-service obserable
    let observable = this.listofGeographyService.getStates();

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (geographyResponse: GeographyResponse) => {
        debugger;

        // if service has returned valid response then only
        if (geographyResponse != null && geographyResponse.OperationStatus.RequestSuccessful) {
          // reset skillcouncil data
          this.states = geographyResponse.States;
          //console.log(geographyResponse.States);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while loading States: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('States loading completed'); }
      );
  }

  //#endregion

  onItemChange(data: any) {
    debugger;
    this.selectedState.emit(data);
  }


  //#endregion
}

