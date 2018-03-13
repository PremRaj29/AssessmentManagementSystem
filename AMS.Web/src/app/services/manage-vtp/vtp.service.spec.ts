import { TestBed, inject } from '@angular/core/testing';

import { VtpService } from './vtp.service';

describe('VtpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VtpService]
    });
  });

  it('should be created', inject([VtpService], (service: VtpService) => {
    expect(service).toBeTruthy();
  }));
});
