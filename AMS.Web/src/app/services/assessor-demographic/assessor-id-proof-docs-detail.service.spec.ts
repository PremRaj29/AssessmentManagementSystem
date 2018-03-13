import { TestBed, inject } from '@angular/core/testing';

import { AssessorIdProofDocsDetailService } from './assessor-id-proof-docs-detail.service';

describe('AssessorIdProofDocsDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssessorIdProofDocsDetailService]
    });
  });

  it('should be created', inject([AssessorIdProofDocsDetailService], (service: AssessorIdProofDocsDetailService) => {
    expect(service).toBeTruthy();
  }));
});
