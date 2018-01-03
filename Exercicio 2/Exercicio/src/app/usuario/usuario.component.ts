import { Component, OnInit, Input } from '@angular/core';

@Component({
  moduleId: module.id,
  selector: 'usuario',
  templateUrl: 'usuario.component.html'
})
export class UsuarioComponent {

  @Input() avatar_url : string;
  @Input() id_usuario: number;
  @Input() login: string;
  @Input() repositorio: string;

}
