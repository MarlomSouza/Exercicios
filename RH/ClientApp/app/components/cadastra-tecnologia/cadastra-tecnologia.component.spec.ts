import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastraTecnologiaComponent } from './cadastra-tecnologia.component';

describe('CadastraTecnologiaComponent', () => {
  let component: CadastraTecnologiaComponent;
  let fixture: ComponentFixture<CadastraTecnologiaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastraTecnologiaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastraTecnologiaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
