import { TestBed } from '@angular/core/testing';

import { RoleDetailService } from './role-detail.service';

describe('RoleDetailService', () => {
  let service: RoleDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoleDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
