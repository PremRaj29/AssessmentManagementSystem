import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VtpComponent } from './vtp.component';

describe('VtpComponent', () => {
  let component: VtpComponent;
  let fixture: ComponentFixture<VtpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VtpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VtpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
