import { TestBed, inject } from '@angular/core/testing';

import { TecnologiaService } from './tecnologia.service';

describe('TecnologiaService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TecnologiaService]
    });
  });

  it('should be created', inject([TecnologiaService], (service: TecnologiaService) => {
    expect(service).toBeTruthy();
  }));
});
