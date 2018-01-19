import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageSkillCouncilComponent } from './manage-skill-council.component';

describe('ManageSkillCouncilComponent', () => {
  let component: ManageSkillCouncilComponent;
  let fixture: ComponentFixture<ManageSkillCouncilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageSkillCouncilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageSkillCouncilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
