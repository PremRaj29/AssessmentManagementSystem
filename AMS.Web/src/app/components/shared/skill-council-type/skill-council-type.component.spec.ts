import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SkillCouncilTypeComponent } from './skill-council-type.component';

describe('SkillCouncilTypeComponent', () => {
  let component: SkillCouncilTypeComponent;
  let fixture: ComponentFixture<SkillCouncilTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SkillCouncilTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SkillCouncilTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
