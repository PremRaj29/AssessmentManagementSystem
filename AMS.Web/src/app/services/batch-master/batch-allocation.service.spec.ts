import { TestBed, inject } from '@angular/core/testing';

import { BatchAllocationService } from './batch-allocation.service';

describe('BatchAllocationService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BatchAllocationService]
    });
  });

  it('should be created', inject([BatchAllocationService], (service: BatchAllocationService) => {
    expect(service).toBeTruthy();
  }));
});
