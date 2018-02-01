import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Triagem } from '../Models/Triagem';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class TriagemService {

  private http: Http;
  private baseUrl: string;
  private api: string = "api/Triagens";


  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  listarTriagens() {


  }
  listarTecnologias(): Observable<Triagem[]> {
    return this.http.get(this.baseUrl + this.api)
      .map(res => res.json());
  };

}
