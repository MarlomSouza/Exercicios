import { Injectable,Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProcessoService {

  private http: Http;
  private baseUrl: string;
  private api: string = "/api/Processos";


  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) { 
    this.http = http;
    this.baseUrl = baseUrl;
  }

  listarProcessos() : Observable<Processo[]> {
    return this.http.get(this.baseUrl + this.api)
    .map(res => res.json());
  };

  listarProcesso(id: number) : Observable<Processo> {
    return this.http.get(this.baseUrl + this.api+ "/" + id)
    .map(res => res.json());
  };

  salvarProcesso(processo: Processo) {
    if(processo.Id)
      return this.http.post(this.baseUrl + this.api, processo);
      // .subscribe(() => {console.log("processo salvo com sucesso!")});

    return this.http.put(this.baseUrl + this.api + "/" + processo.Id,  processo);
    // .subscribe(() => {console.log("processo alterado com sucesso!")});
  }

  excluirProcesso(id: number){
    return this.http.delete(this.baseUrl + this.api + "/" + id );
  }
  
}

export interface Processo {
  Id: number;
  Nome: string;
}

