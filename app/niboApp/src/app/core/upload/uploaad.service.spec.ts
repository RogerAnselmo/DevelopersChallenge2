import { TestBed } from '@angular/core/testing';

import { UploaadService } from './uploaad.service';

describe('UploaadService', () => {
  let service: UploaadService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UploaadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
