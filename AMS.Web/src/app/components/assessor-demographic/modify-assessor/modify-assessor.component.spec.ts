import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyAssessorComponent } from './modify-assessor.component';

describe('ModifyAssessorComponent', () => {
  let component: ModifyAssessorComponent;
  let fixture: ComponentFixture<ModifyAssessorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifyAssessorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyAssessorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
