import { TestBed } from '@angular/core/testing';

import { PermissionDetailService } from './permission-detail.service';

describe('PermissionDetailService', () => {
  let service: PermissionDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PermissionDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
