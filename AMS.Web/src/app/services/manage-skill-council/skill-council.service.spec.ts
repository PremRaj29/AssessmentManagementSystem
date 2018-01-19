import { TestBed, inject } from '@angular/core/testing';

import { SkillCouncilService } from './skill-council.service';

describe('SkillCouncilService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SkillCouncilService]
    });
  });

  it('should be created', inject([SkillCouncilService], (service: SkillCouncilService) => {
    expect(service).toBeTruthy();
  }));
});
