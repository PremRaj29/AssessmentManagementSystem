import { Component, OnInit,Output,Input,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-skill-council-type',
  templateUrl: './skill-council-type.component.html',
  styleUrls: ['./skill-council-type.component.css']
})
export class SkillCouncilTypeComponent implements OnInit {

  //recieve parent component inputs 
  @Input('setSelectedCouncilType') councilType: number = 0;

  //emit selected council-type to parent component
  @Output('selectedCouncilType') selectedType = new EventEmitter<number>();

  //councilType: number = 0;
  constructor() { }

  ngOnInit() {
  }

  onItemChange(data:any){
    debugger;
    this.selectedType.emit(data);
  }

}
