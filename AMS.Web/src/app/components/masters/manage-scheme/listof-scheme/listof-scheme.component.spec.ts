import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListofSchemeComponent } from './listof-scheme.component';

describe('ListofSchemeComponent', () => {
  let component: ListofSchemeComponent;
  let fixture: ComponentFixture<ListofSchemeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListofSchemeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListofSchemeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
