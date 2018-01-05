import { Component, Input, OnInit } from '@angular/core';
import { Http } from "@angular/http";
import { Response } from '@angular/http/src/static_response';
import { HttpResponse } from 'selenium-webdriver/http';
import { Headers } from '@angular/http/src/headers';

@Component({
  moduleId: module.id,
  selector: 'app-listagem',
  templateUrl: 'listagem.component.html'
})
export class ListagemComponent implements OnInit {

  @Input() search: string = "";

  usuarios: Object[] = [];
  http: Http;
  links: Link[] = []

  constructor(http: Http) {
    this.http = http;
  }

  ngOnInit(): void {
    this.obterTodosUsuarios();
  }

  obterTodosUsuarios(){
    this.http
    .get('https://api.github.com/users?per_page=10&client_id=e2f8d5f949ac1b6d9717&client_secret=38c8e714d646a07455ba50741135b16f110016f4')
    .subscribe(usuarios => 
      { this.usuarios = usuarios.json(); 
        this.parse_link_header(usuarios.headers.get("link"));
      }), error => console.log("ERRO ====>>> ", error);
  };

  searchUser() {
    
    if(this.search.length ==0){
      this.obterTodosUsuarios();
      return;
    }
    console.log("CHEGOU AQUI");
    if(this.search.length < 3)
      return;

    this.http
      .get('https://api.github.com/search/users?type=Users&q='+this.search +'&client_id=e2f8d5f949ac1b6d9717&client_secret=38c8e714d646a07455ba50741135b16f110016f4')
      .subscribe(usuarios => { 
        this.usuarios = usuarios.json().items; 
         this.parse_link_header(usuarios.headers.get("link"));
      }), error => console.log("ERRO ====>>> ", error);

  }

  obterMaisUsuarios(){
    console.log("this.links", this.links.find((v) => v.nome == "next").url);
    this.http
    .get(this.links.find((link) => link.nome == "next").url)
    .subscribe(usuarios => 
      {
        if(this.search.length ==0)
          this.usuarios = this.usuarios.concat(usuarios.json());   
        else
          this.usuarios = this.usuarios.concat(usuarios.json().items);   

          this.parse_link_header(usuarios.headers.get("link"));
      }), error => console.log("ERRO ====>>> ", error);
  };

   parse_link_header(header:string) {
    this.links =[];

    if (header.length == 0) 
      throw new Error("input must not be of zero length");

    // Split parts by comma
    let parts = header.split(',');
    
    // Parse each part into a named link
    for(let i=0; i< parts.length; i++){
      var section = parts[i].split(';');
      if (section.length != 2) {
        throw new Error("section could not be split on ';'");
      }
      
      var url = section[0].replace(/<(.*)>/, '$1').trim();
      let name = section[1].replace(/rel="(.*)"/, '$1').trim();

      this.links.push( new Link(name, url));
      }
    };
}

export class Link{
    nome: string;
    url: string;

    constructor(nome, url){
      this.nome = nome;
      this.url = url;
    };
    
}
