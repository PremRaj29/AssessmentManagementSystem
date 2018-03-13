import { TestBed, inject } from '@angular/core/testing';

import { AssessorOtherDetailService } from './assessor-other-detail.service';

describe('AssessorOtherDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssessorOtherDetailService]
    });
  });

  it('should be created', inject([AssessorOtherDetailService], (service: AssessorOtherDetailService) => {
    expect(service).toBeTruthy();
  }));
});
