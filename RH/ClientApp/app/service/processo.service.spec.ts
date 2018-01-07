import { TestBed, inject } from '@angular/core/testing';

import { ProcessoService } from './processo.service';

describe('ProcessoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProcessoService]
    });
  });

  it('should be created', inject([ProcessoService], (service: ProcessoService) => {
    expect(service).toBeTruthy();
  }));
});
