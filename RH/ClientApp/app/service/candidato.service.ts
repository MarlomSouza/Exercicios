import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operator/map';
import { Candidato } from '../models/Candidato';

@Injectable()
export class CandidatoService {

  private http: Http;
  private baseUrl: string;
  private api: string = "api/Candidatos";


  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  listarCandidatos() {
    return this.http.get(this.baseUrl + this.api)
      .map(res => res.json());
  };

  listarCandidato(id: number): Observable<Candidato> {
    return this.http.get(this.baseUrl + this.api + "/" + id)
      .map(res => res.json());
  };

  salvarCandidato(candidato: Candidato) {
    if (candidato.id)
      return this.http.put(this.baseUrl + this.api + "/" + candidato.id, candidato);

    return this.http.post(this.baseUrl + this.api, candidato);
  }

  excluirUsuario(id: number) {
    return this.http.delete(this.baseUrl + this.api + "/" + id);
  }
}