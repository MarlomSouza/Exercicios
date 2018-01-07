import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaTecnologiaComponent } from './lista-tecnologia.component';

describe('ListaTecnologiaComponent', () => {
  let component: ListaTecnologiaComponent;
  let fixture: ComponentFixture<ListaTecnologiaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaTecnologiaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaTecnologiaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
