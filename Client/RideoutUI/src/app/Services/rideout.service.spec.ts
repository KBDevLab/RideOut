import { TestBed } from '@angular/core/testing';

import { RideoutService } from './rideout.service';

describe('RideoutService', () => {
  let service: RideoutService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RideoutService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
