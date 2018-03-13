import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JobRoleDetailComponent } from './job-role-detail.component';

describe('JobRoleDetailComponent', () => {
  let component: JobRoleDetailComponent;
  let fixture: ComponentFixture<JobRoleDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JobRoleDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JobRoleDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
