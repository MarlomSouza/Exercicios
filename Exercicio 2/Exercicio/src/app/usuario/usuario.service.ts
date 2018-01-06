import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operator/map';

@Injectable()
export class UsuarioService {

  private http: Http
  private Client_Id : string = "e2f8d5f949ac1b6d9717";
  private client_secret : string = "38c8e714d646a07455ba50741135b16f110016f4";
  private id_secret : string = "&client_id="+ this.Client_Id +"&client_secret=" + this.client_secret;

  private Url_Api : string = "https://api.github.com";
  header_link: string;

  constructor(http: Http) { 
    this.http = http;
  }

  listarUsuarios()  {
    return this.http.get(this.Url_Api + '/users?per_page=10&client_id='+ this.id_secret)
                    .map((rep) => {
                      this.header_link = rep.headers.get("link");
                      return rep.json()
                    });
  };

  listarUsuariosAproximacao(login: string) {
    return this.http.get(this.Url_Api + '/search/users?type=Users&q=' +login + this.id_secret)
                    .map((rep) => {
                      this.header_link = rep.headers.get("link");
                      return rep.json().items
                    });
  };

  ObterUsuario(login: string) : Observable<Response> {
      return this.http.get(this.Url_Api + '/users/' + login + '?' + this.id_secret)  
                      .map(rep => rep.json());
  };

  obterRepositorioUsuario (login : string){
    return this.http.get( this.Url_Api + '/users/' + login + '/repos?' + this.id_secret)
                    .map((rep) => {
                      this.header_link = rep.headers.get("link");
                      return rep.json()
                    });
  };
  
  carregarMais()  {
    return this.http.get(this.parse_link_header(this.header_link).url)
    .map((rep) => {
      this.header_link = rep.headers.get("link");
        if(this.header_link.includes("next") == false){
          this.header_link = undefined;
        }
      return rep.json()
    });
  };

  parse_link_header(header:string) : Link {
    let link: Link;
    
    if (!header || header.length == 0) 
      throw new Error("Header está vazio.");

    let parts = header.split(',');
  
    for(let i=0; i< parts.length; i++){
        var section = parts[i].split(';');

        if (section.length != 2)
          throw new Error("Não é possivel separar a URL");
        
        var url = section[0].replace(/<(.*)>/, '$1').trim();
        let name = section[1].replace(/rel="(.*)"/, '$1').trim();
        if(name.includes("next"))
          link = new Link(name, url);
      }

      return link;
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
