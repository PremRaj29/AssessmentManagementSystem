import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListofSkillCouncilComponent } from './listof-skill-council.component';

describe('ListofSkillCouncilComponent', () => {
  let component: ListofSkillCouncilComponent;
  let fixture: ComponentFixture<ListofSkillCouncilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListofSkillCouncilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListofSkillCouncilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
