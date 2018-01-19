import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SkillCouncilComponent } from './skill-council.component';

describe('SkillCouncilComponent', () => {
  let component: SkillCouncilComponent;
  let fixture: ComponentFixture<SkillCouncilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SkillCouncilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SkillCouncilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
