import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaTriagemComponent } from './lista-triagem.component';

describe('ListaTriagemComponent', () => {
  let component: ListaTriagemComponent;
  let fixture: ComponentFixture<ListaTriagemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaTriagemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaTriagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
