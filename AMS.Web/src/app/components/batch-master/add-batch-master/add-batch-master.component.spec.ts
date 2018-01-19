import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBatchMasterComponent } from './add-batch-master.component';

describe('AddBatchMasterComponent', () => {
  let component: AddBatchMasterComponent;
  let fixture: ComponentFixture<AddBatchMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddBatchMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBatchMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
