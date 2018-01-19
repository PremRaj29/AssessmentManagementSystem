import { TestBed, inject } from '@angular/core/testing';

import { ListofSkillCouncilService } from './listof-skill-council.service';

describe('ListofSkillCouncilService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ListofSkillCouncilService]
    });
  });

  it('should be created', inject([ListofSkillCouncilService], (service: ListofSkillCouncilService) => {
    expect(service).toBeTruthy();
  }));
});
