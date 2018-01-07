import { Injectable,Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ProcessoService {

  private http: Http;
  private baseUrl: string;
  private api: string = "api/Processos";

  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) { 
    this.http = http;
    this.baseUrl = baseUrl;
  }

  listarProcessos() : Observable<Processo[]> {
    return this.http.get(this.baseUrl + this.api)
    .map(res => res.json());
  };

  listarProcesso(id: number) : Observable<Processo> {
    return this.http.get(this.baseUrl + this.api + "/" + id)
    .map(res => res.json());
  };

  salvarProcesso(processo: Processo) {
    if(processo.id)
      return this.http.put(this.baseUrl + this.api + "/" + processo.id,  processo);
      
    return this.http.post(this.baseUrl + this.api, processo);
  }

  excluirProcesso(id: number){
    return this.http.delete(this.baseUrl + this.api + "/" + id );
  }
}

export class Processo {
  id: number;
  nome: string;
  tecnologias: ProcessoTecnologia[] = [];
}

export class ProcessoTecnologia {
  processoId: number;
  tecnologiaId: number;
}
