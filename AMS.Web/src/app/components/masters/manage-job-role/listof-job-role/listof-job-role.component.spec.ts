import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListofJobRoleComponent } from './listof-job-role.component';

describe('ListofJobRoleComponent', () => {
  let component: ListofJobRoleComponent;
  let fixture: ComponentFixture<ListofJobRoleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListofJobRoleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListofJobRoleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
