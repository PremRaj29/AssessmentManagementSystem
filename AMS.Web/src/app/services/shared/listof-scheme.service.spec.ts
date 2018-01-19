import { TestBed, inject } from '@angular/core/testing';

import { ListofSchemeService } from './listof-scheme.service';

describe('ListofSchemeService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ListofSchemeService]
    });
  });

  it('should be created', inject([ListofSchemeService], (service: ListofSchemeService) => {
    expect(service).toBeTruthy();
  }));
});
