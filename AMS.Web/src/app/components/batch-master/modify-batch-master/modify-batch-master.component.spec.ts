import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyBatchMasterComponent } from './modify-batch-master.component';

describe('ModifyBatchMasterComponent', () => {
  let component: ModifyBatchMasterComponent;
  let fixture: ComponentFixture<ModifyBatchMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifyBatchMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyBatchMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
