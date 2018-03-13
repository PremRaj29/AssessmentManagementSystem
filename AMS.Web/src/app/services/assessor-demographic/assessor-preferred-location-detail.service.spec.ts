import { TestBed, inject } from '@angular/core/testing';

import { AssessorPreferredLocationDetailService } from './assessor-preferred-location-detail.service';

describe('AssessorPreferredLocationDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssessorPreferredLocationDetailService]
    });
  });

  it('should be created', inject([AssessorPreferredLocationDetailService], (service: AssessorPreferredLocationDetailService) => {
    expect(service).toBeTruthy();
  }));
});
