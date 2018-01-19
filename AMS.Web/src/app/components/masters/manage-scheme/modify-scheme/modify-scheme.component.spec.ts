import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifySchemeComponent } from './modify-scheme.component';

describe('ModifySchemeComponent', () => {
  let component: ModifySchemeComponent;
  let fixture: ComponentFixture<ModifySchemeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifySchemeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifySchemeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
