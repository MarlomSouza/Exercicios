import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operator/map';
import { Tecnologia } from '../models/Tecnologia';

@Injectable()
export class TecnologiaService {

  private http: Http;
  private baseUrl: string;
  private api: string = "api/Tecnologias";


  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  listarTecnologias(): Observable<Tecnologia[]> {
    return this.http.get(this.baseUrl + this.api)
      .map(res => res.json());
  };

  listarTecnologia(id: number): Observable<Tecnologia> {
    return this.http.get(this.baseUrl + this.api + "/" + id)
      .map(res => res.json());
  };

  salvarTecnologia(tecnologia: Tecnologia) {
    if (tecnologia.id)
      return this.http.put(this.baseUrl + this.api + "/" + tecnologia.id, tecnologia);

    return this.http.post(this.baseUrl + this.api, tecnologia);
  }

  excluirTecnologia(id: number) {
    return this.http.delete(this.baseUrl + this.api + "/" + id);
  }
}