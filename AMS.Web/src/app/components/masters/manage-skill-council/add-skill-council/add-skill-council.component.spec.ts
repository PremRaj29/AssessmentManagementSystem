import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSkillCouncilComponent } from './add-skill-council.component';

describe('AddSkillCouncilComponent', () => {
  let component: AddSkillCouncilComponent;
  let fixture: ComponentFixture<AddSkillCouncilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddSkillCouncilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSkillCouncilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
