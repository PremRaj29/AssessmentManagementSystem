import { TestBed, inject } from '@angular/core/testing';

import { ListofGeographyService } from './listof-geography.service';

describe('ListofGeographyService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ListofGeographyService]
    });
  });

  it('should be created', inject([ListofGeographyService], (service: ListofGeographyService) => {
    expect(service).toBeTruthy();
  }));
});
