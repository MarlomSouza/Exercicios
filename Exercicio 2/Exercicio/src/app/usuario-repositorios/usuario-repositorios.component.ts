import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { RepositorioComponent } from '../repositorio/repositorio.component';
import { ActivatedRoute } from "@angular/router";
import { UsuarioComponent } from '../usuario/usuario.component';

@Component({
  selector: 'app-usuario-repositorios',
  templateUrl: './usuario-repositorios.component.html',
  styleUrls: ['./usuario-repositorios.component.css']
})
export class UsuarioRepositoriosComponent implements OnInit {

  http: Http;
  repositorios: object[] = [];
  route: ActivatedRoute;
  usuario: object;

  constructor(http: Http, route: ActivatedRoute) { 
    this.http = http;
    this.route = route;
  }

  ngOnInit() {
    this.route.params.subscribe(params =>{
      let login:string = params['login'];
      this.obterRepositorio(login);
    });
  }

  obterRepositorio(login:string){
    this.http
    .get('https://api.github.com/users/'+login+'/repos')
    .map(result => result.json())
    .subscribe(repositorios => { this.repositorios = repositorios; this.obterUsuario(); }), error => console.log("ERRO ====>>> ", error);
  };

  obterUsuario(){
    this.usuario = this.repositorios[0]["owner"];
    console.log(this.usuario);
  };


}
