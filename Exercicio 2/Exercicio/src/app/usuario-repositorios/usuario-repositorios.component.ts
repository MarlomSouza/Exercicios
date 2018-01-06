import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { RepositorioComponent } from '../repositorio/repositorio.component';
import { ActivatedRoute } from "@angular/router";
import { UsuarioComponent } from '../usuario/usuario.component';
import { UsuarioService } from '../usuario/usuario.service';


@Component({
  moduleId: module.id,
  selector: 'app-usuario-repositorios',
  templateUrl: 'usuario-repositorios.component.html',
})
export class UsuarioRepositoriosComponent implements OnInit {

  http: Http;
  repositorios: Object[] = [];
  route: ActivatedRoute;
  usuario: object;
  service: UsuarioService;

  constructor(http: Http, route: ActivatedRoute, service: UsuarioService) { 
    this.http = http;
    this.route = route;
    this.service = service;
  }

  ngOnInit() {
    this.route.params.subscribe(params =>
    {
      let login:string = params['login'];
      this.obterUsuario(login);
      this.obterRepositorio(login);
    });
  }

  obterUsuario(login:string){
    this.service
        .ObterUsuario(login)
        .subscribe(usuario => this.usuario = usuario), error => console.log("ERRO ====>>> ", error);
  };

  obterRepositorio(login:string){
    this.service
        .obterRepositorioUsuario(login)
        .subscribe(repositorios =>  this.repositorios = repositorios), error => console.log("ERRO ====>>> ", error);
  };

  obterMaisRepositorios(){
    this.service
    .carregarMais()
    .subscribe(repositorios => 
    {
        this.repositorios = this.repositorios.concat(repositorios.json());
        
        this.service.header_link = repositorios.headers.get("link");
        if(this.service.header_link.includes("next") == false){
          this.service.header_link = undefined;
        }
    }), error => console.log("ERRO ====>>> ", error);
  };


}
