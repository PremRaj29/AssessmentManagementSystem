import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddVtpComponent } from './add-vtp.component';

describe('AddVtpComponent', () => {
  let component: AddVtpComponent;
  let fixture: ComponentFixture<AddVtpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddVtpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddVtpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
