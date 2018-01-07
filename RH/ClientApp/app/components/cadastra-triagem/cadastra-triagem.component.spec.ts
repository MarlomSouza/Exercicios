import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastraTriagemComponent } from './cadastra-triagem.component';

describe('CadastraTriagemComponent', () => {
  let component: CadastraTriagemComponent;
  let fixture: ComponentFixture<CadastraTriagemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastraTriagemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastraTriagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
