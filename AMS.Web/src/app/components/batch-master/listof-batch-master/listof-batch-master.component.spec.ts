import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListofBatchMasterComponent } from './listof-batch-master.component';

describe('ListofBatchMasterComponent', () => {
  let component: ListofBatchMasterComponent;
  let fixture: ComponentFixture<ListofBatchMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListofBatchMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListofBatchMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
