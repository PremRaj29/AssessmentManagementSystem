import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageVtpComponent } from './manage-vtp.component';

describe('ManageVtpComponent', () => {
  let component: ManageVtpComponent;
  let fixture: ComponentFixture<ManageVtpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageVtpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageVtpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
