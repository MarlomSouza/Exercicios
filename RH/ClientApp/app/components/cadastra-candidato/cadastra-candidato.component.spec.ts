import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastraCandidatoComponent } from './cadastra-candidato.component';

describe('CadastraCandidatoComponent', () => {
  let component: CadastraCandidatoComponent;
  let fixture: ComponentFixture<CadastraCandidatoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastraCandidatoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastraCandidatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
