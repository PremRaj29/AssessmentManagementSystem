import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { ListofVtpService } from '../../../services/shared/listof-vtp.service';
import { VocationalTrainingProvider } from '../../../models/manage-vtp/vtp';
import { VocationalTrainingProviderResponse } from '../../../models/manage-vtp/vtp-response';

@Component({
  selector: 'app-vtp',
  templateUrl: './vtp.component.html',
  styleUrls: ['./vtp.component.css'],
  providers: [ListofVtpService]
})
export class VtpComponent implements OnInit {

  //interact with input & output of this components
  @Input('vtpId') vtpId: number;
  @Output('selectedVtp') selectedVtp = new EventEmitter<number>();

  public vtps: Array<VocationalTrainingProvider> = null;

  isDataLoadingCompleted: boolean = false;

  constructor(private listofVtpService: ListofVtpService) { }

  ngOnInit() {
    this.getVtp();
  }

  //#region public methods

  //#region get methods

  getVtp() {

    // here get vtp0-service obserable
    let observable = this.listofVtpService.getVtp();

    let subscription = observable.subscribe
      (
      // calls the onNext() function in the observer
      (vtpResponse: VocationalTrainingProviderResponse) => {
        debugger;

        // if service has returned valid response then only
        if (vtpResponse != null && vtpResponse.OperationStatus.RequestSuccessful) {
          // reset skillcouncil data
          this.vtps = vtpResponse.VocationalTrainingProvider;
          //console.log(vtpResponse.VocationalTrainingProvider);
        }
        else {
          // show error message on screen
        }
      },

      // calls onError() function either when the Observable calls the error() method or when any error is thrown in the process.
      // here we can also call our logger service to log this exception
      (error: string) => console.log('error while loading VTPs: ' + error),

      // calls the onComplete() function in the observer
      () => { this.isDataLoadingCompleted = true; console.log('VTPs loading completed'); }
      );
  }

  //#endregion

  onItemChange(data: any) {
    debugger;
    this.selectedVtp.emit(data);
  }


  //#endregion
}

