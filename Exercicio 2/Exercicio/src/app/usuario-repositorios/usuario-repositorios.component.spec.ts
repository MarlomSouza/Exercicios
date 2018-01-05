import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioRepositoriosComponent } from './usuario-repositorios.component';

describe('UsuarioRepositoriosComponent', () => {
  let component: UsuarioRepositoriosComponent;
  let fixture: ComponentFixture<UsuarioRepositoriosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsuarioRepositoriosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioRepositoriosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
