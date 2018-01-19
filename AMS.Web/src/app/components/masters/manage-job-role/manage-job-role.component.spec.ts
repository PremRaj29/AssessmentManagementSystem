import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageJobRoleComponent } from './manage-job-role.component';

describe('ManageJobRoleComponent', () => {
  let component: ManageJobRoleComponent;
  let fixture: ComponentFixture<ManageJobRoleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageJobRoleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageJobRoleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
