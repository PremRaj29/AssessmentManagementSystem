import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListofAssessorComponent } from './listof-assessor.component';

describe('ListofAssessorComponent', () => {
  let component: ListofAssessorComponent;
  let fixture: ComponentFixture<ListofAssessorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListofAssessorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListofAssessorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
