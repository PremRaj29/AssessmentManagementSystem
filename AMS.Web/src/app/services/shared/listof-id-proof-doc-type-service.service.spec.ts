import { TestBed, inject } from '@angular/core/testing';

import { ListofIdProofDocTypeServiceService } from './listof-id-proof-doc-type-service.service';

describe('ListofIdProofDocTypeServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ListofIdProofDocTypeServiceService]
    });
  });

  it('should be created', inject([ListofIdProofDocTypeServiceService], (service: ListofIdProofDocTypeServiceService) => {
    expect(service).toBeTruthy();
  }));
});
