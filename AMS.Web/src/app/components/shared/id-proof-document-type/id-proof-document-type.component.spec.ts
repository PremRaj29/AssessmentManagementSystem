import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IdProofDocumentTypeComponent } from './id-proof-document-type.component';

describe('IdProofDocumentTypeComponent', () => {
  let component: IdProofDocumentTypeComponent;
  let fixture: ComponentFixture<IdProofDocumentTypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IdProofDocumentTypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IdProofDocumentTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
