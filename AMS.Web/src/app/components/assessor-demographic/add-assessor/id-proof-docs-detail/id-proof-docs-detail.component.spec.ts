import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IdProofDocsDetailComponent } from './id-proof-docs-detail.component';

describe('IdProofDocsDetailComponent', () => {
  let component: IdProofDocsDetailComponent;
  let fixture: ComponentFixture<IdProofDocsDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IdProofDocsDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IdProofDocsDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
