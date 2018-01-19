import { TestBed, inject } from '@angular/core/testing';

import { ListofJobRoleService } from './listof-job-role.service';

describe('ListofJobRoleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ListofJobRoleService]
    });
  });

  it('should be created', inject([ListofJobRoleService], (service: ListofJobRoleService) => {
    expect(service).toBeTruthy();
  }));
});
