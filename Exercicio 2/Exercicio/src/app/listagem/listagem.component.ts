import { Component, Input, OnInit } from '@angular/core';
import { Http } from "@angular/http";

@Component({
  moduleId: module.id,
  selector: 'app-listagem',
  templateUrl: 'listagem.component.html'
})
export class ListagemComponent implements OnInit {

  @Input() search: string;

  usuarios: Object[] = [];
  http: Http;

  constructor(http: Http) {
    this.http = http;
  }

  ngOnInit(): void {
    this.obterTodosUsuarios();
  }

  obterTodosUsuarios(){
    this.http
    .get('https://api.github.com/users')
    .map(result => result.json())
    .subscribe(usuarios => { this.usuarios = usuarios; console.log(usuarios) }), error => console.log("ERRO ====>>> ", error);
  };

  searchUser() {
    console.log("this.search.length",this.search.length);
    if(this.search.length ==0){
      this.obterTodosUsuarios();
      return;
    }

    this.http
      .get('https://api.github.com/search/users?type=Users&q='+this.search +'&client_id=e2f8d5f949ac1b6d9717&client_secret=38c8e714d646a07455ba50741135b16f110016f4')
      .map(result => result.json())
      .subscribe(usuarios => { this.usuarios = usuarios.items;}), error => console.log("ERRO ====>>> ", error);
  }






}
