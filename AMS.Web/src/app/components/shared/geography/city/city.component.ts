import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';

import { City } from '../../../../models/geography/city';
import { ListofGeographyService } from '../../../../services/shared/listof-geography.service';
import { GeographyResponse } from '../../../../models/geography/geography-response';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css'],
  providers: [ListofGeographyService]
})
export class CityComponent implements OnInit {

  //interact with input & output of this components
  @Input('stateId') stateId: number = null;
  @Input('cityId') cityId: number = null;
  @Output('selectedCity') selectedCity = new EventEmitter<number>();

  public cities: Array<City> = null;
  isDataLoadingCompleted: boolean = false;
  dataLoadingText: string = 'loading, wait..';
  defaultDDL_Option: string = (this.stateId != null) ? this.dataLoadingText : 'Select';

  constructor(private listofGeographyService: ListofGeographyService) { }

  ngOnInit() {
  }

  /**
 * 
 * @param changes Method will keep watch on @Input control value based on that take action
 */
  ngOnChanges(changes: SimpleChanges) 
  {
    if (changes['stateId'] != undefined && changes['stateId'] != null
      && changes['stateId'].currentValue != null) 
      {
        //#region Custom logic to resolve dependetn DDL binding/auto select issue on page LOAD
  
        /**
         * Reset selected value ["cityId"] of this (CHILD- Cities) component 
         * only when components already have some data (this.Cities.length >0) otherwise no need.  
         */
  
        if (this.cities != null && this.cities.length > 0) {
          this.cities = null;
          this.cityId = null;
        }
  
        //#endregion
  
        //#region process further only if Valid "stateId" is there
  
        //process further only if Valid "stateId" is there
        if (!(this.stateId > 0)) {
          return;
        }
  
        //otherwise load child compList data
        this.getCities();
  
        //#endregion
      }
  }


  //#region public methods

  //#region get methods

  getCities() {
    //debugger;

    this.isDataLoadingCompleted = false;
    this.defaultDDL_Option = this.dataLoadingText;

    // here get geography-service obserable
    let observable = this.listofGeographyService.getCities(this.stateId);

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (geographyResponse: GeographyResponse) => {
        debugger;

        // if service has returned valid response then only
        if (geographyResponse != null && geographyResponse.OperationStatus.RequestSuccessful) {
          // reset skillcouncil data
          this.cities = geographyResponse.Cities;

          //also reset selectedId comp output
          this.selectedCity.emit(this.cityId);

          //console.log(geographyResponse.Cities);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while loading Cities: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; this.defaultDDL_Option = 'Select'; console.log('Cities loading completed'); }
      );
  }

  //#endregion

  onItemChange(data: any) {
    debugger;
    this.selectedCity.emit(data);
  }


  //#endregion
}

