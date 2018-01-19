import { TestBed, inject } from '@angular/core/testing';

import { ListofVtpService } from './listof-vtp.service';

describe('ListofVtpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ListofVtpService]
    });
  });

  it('should be created', inject([ListofVtpService], (service: ListofVtpService) => {
    expect(service).toBeTruthy();
  }));
});
