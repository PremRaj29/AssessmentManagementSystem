import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifySkillCouncilComponent } from './modify-skill-council.component';

describe('ModifySkillCouncilComponent', () => {
  let component: ModifySkillCouncilComponent;
  let fixture: ComponentFixture<ModifySkillCouncilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifySkillCouncilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifySkillCouncilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
