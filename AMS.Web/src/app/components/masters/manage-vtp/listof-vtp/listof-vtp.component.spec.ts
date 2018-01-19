import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListofVtpComponent } from './listof-vtp.component';

describe('ListofVtpComponent', () => {
  let component: ListofVtpComponent;
  let fixture: ComponentFixture<ListofVtpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListofVtpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListofVtpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
