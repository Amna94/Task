import { TestBed } from '@angular/core/testing';

import { RpDetailService } from './rp-detail.service';

describe('RpDetailService', () => {
  let service: RpDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RpDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
