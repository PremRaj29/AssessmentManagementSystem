import { TestBed, inject } from '@angular/core/testing';

import { AssessorPersonalDetailService } from './assessor-personal-detail.service';

describe('AssessorPersonalDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssessorPersonalDetailService]
    });
  });

  it('should be created', inject([AssessorPersonalDetailService], (service: AssessorPersonalDetailService) => {
    expect(service).toBeTruthy();
  }));
});
