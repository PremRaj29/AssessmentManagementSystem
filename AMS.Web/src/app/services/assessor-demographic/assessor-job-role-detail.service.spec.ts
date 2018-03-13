import { TestBed, inject } from '@angular/core/testing';

import { AssessorJobRoleDetailService } from './assessor-job-role-detail.service';

describe('AssessorJobRoleDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AssessorJobRoleDetailService]
    });
  });

  it('should be created', inject([AssessorJobRoleDetailService], (service: AssessorJobRoleDetailService) => {
    expect(service).toBeTruthy();
  }));
});
