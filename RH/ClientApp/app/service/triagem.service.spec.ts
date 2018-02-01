import { TestBed, inject } from '@angular/core/testing';

import { TriagemService } from './triagem.service';

describe('TriagemService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TriagemService]
    });
  });

  it('should be created', inject([TriagemService], (service: TriagemService) => {
    expect(service).toBeTruthy();
  }));
});
