import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyVtpComponent } from './modify-vtp.component';

describe('ModifyVtpComponent', () => {
  let component: ModifyVtpComponent;
  let fixture: ComponentFixture<ModifyVtpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifyVtpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyVtpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
