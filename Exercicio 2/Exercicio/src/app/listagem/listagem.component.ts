import { Component, Input, OnInit } from '@angular/core';
import { Http } from "@angular/http";
import { Response } from '@angular/http/src/static_response';
import { HttpResponse } from 'selenium-webdriver/http';
import { Headers } from '@angular/http/src/headers';
import { UsuarioService, Link } from '../usuario/usuario.service';

@Component({
  moduleId: module.id,
  selector: 'app-listagem',
  templateUrl: 'listagem.component.html'
})
export class ListagemComponent implements OnInit {

  @Input() busca: string = "";
  usuarios: Object[] = [];
  http: Http;
 

  service: UsuarioService;

  constructor(service: UsuarioService, http: Http) {
    this.http = http;
    this.service = service;
  }

  ngOnInit(): void {
    this.obterTodosUsuarios();
  }

  obterTodosUsuarios(){
    this.service
        .listarUsuarios()
        .subscribe(usuarios => this.usuarios = usuarios), error => console.log("ERRO ====>>> ", error);
  };


  buscarUsuario() {
    
    if(this.busca.length ==0){
      this.obterTodosUsuarios();
      return;
    }

    if(this.busca.length < 3)
      return;

    this.service
        .listarUsuariosAproximacao(this.busca)
        .subscribe(usuarios => this.usuarios = usuarios), error => console.log("ERRO ====>>> ", error);
  }

  obterMaisUsuarios(){

    this.service
    .carregarMais()
    .subscribe(usuarios => 
      {
        if(this.busca.length ==0)
          this.usuarios = this.usuarios.concat(usuarios);   
        else
          this.usuarios = this.usuarios.concat(usuarios.items);   

      }), error => console.log("ERRO ====>>> ", error);
  };
  
}


