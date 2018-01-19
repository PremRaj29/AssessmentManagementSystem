import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyJobRoleComponent } from './modify-job-role.component';

describe('ModifyJobRoleComponent', () => {
  let component: ModifyJobRoleComponent;
  let fixture: ComponentFixture<ModifyJobRoleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifyJobRoleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyJobRoleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
