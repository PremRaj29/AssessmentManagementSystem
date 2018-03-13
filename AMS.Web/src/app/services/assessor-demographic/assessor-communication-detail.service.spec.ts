import { TestBed, inject } from '@angular/core/testing';

import { AssessorCommunicationDetailService } from './assessor-communication-detail.service';

describe('AssessorCommunicationDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssessorCommunicationDetailService]
    });
  });

  it('should be created', inject([AssessorCommunicationDetailService], (service: AssessorCommunicationDetailService) => {
    expect(service).toBeTruthy();
  }));
});
