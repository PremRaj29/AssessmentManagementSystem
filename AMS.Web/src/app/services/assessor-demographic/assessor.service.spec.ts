import { TestBed, inject } from '@angular/core/testing';

import { AssessorService } from './assessor.service';

describe('AssessorService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssessorService]
    });
  });

  it('should be created', inject([AssessorService], (service: AssessorService) => {
    expect(service).toBeTruthy();
  }));
});
