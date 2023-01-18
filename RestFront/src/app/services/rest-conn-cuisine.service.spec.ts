import { TestBed } from '@angular/core/testing';

import { RestConnCuisineService } from './rest-conn-cuisine.service';

describe('RestConnCuisineService', () => {
  let service: RestConnCuisineService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RestConnCuisineService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
