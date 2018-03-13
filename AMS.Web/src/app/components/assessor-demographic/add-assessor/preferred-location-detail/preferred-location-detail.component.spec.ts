import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreferredLocationDetailComponent } from './preferred-location-detail.component';

describe('PreferredLocationDetailComponent', () => {
  let component: PreferredLocationDetailComponent;
  let fixture: ComponentFixture<PreferredLocationDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PreferredLocationDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreferredLocationDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
