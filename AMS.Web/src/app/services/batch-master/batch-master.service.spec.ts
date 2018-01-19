import { TestBed, inject } from '@angular/core/testing';

import { BatchMasterService } from './batch-master.service';

describe('BatchMasterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BatchMasterService]
    });
  });

  it('should be created', inject([BatchMasterService], (service: BatchMasterService) => {
    expect(service).toBeTruthy();
  }));
});
