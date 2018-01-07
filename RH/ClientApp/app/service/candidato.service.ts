import { Injectable,Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CandidatoService {

  private http: Http;
  private baseUrl: string;
  private api: string = "/api/Candidatos";


  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) { 
    this.http = http;
    this.baseUrl = baseUrl;
  }

  listarCandidatos() :  Observable<Candidato[]> {
    return this.http.get(this.baseUrl + this.api)
    .map(res => res.json());
  };

  salvarCandidato(candidato: Candidato) {
    if(candidato.Id)
      return this.http.post(this.baseUrl + this.api, candidato);
      // .subscribe(() => {console.log("Candidato salvo com sucesso!")});

    return this.http.put(this.baseUrl + this.api + "/" + candidato.Id,  candidato);
    // .subscribe(() => {console.log("Candidato alterado com sucesso!")});
  }

  excluirUsuario(id: number){
    return this.http.delete(this.baseUrl + this.api + "/" + id );
  }

  
}

export interface Candidato {
  Id: number;
  Nome: string;
}

