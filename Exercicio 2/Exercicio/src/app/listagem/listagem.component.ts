import { Component} from '@angular/core';
import { Http } from "@angular/http";

@Component({
  moduleId: module.id,
  selector: 'app-listagem',
  templateUrl: 'listagem.component.html'
})
export class ListagemComponent {


  usuarios: Object[] = [];
  constructor(http: Http){
      http
      .get('https://api.github.com/users')
      .map(result => result.json())
      .subscribe(usuarios => {this.usuarios = usuarios; console.log(usuarios)}), error => console.log("ERRO ====>>> ", error);
  }




}
