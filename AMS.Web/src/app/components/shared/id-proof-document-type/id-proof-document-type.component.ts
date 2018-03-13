import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-id-proof-document-type',
  templateUrl: './id-proof-document-type.component.html',
  styleUrls: ['./id-proof-document-type.component.css']
})
export class IdProofDocumentTypeComponent implements OnInit {

  //recieve parent component inputs 
  @Input('setSelectedIdProofDocTypeId') idProofDocTypeId: number = 0;

  //emit selected id-proof-doc-type to parent component
  @Output('selectedIdProofDocTypeId') selectedIdProofDocType = new EventEmitter<number>();

  //councilType: number = 0;
  constructor() { }

  ngOnInit() {
  }

  onItemChange(data:any){
    debugger;
    this.selectedIdProofDocType.emit(data);
  }

}
