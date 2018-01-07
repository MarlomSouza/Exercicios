import { Injectable,Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class TecnologiaService {

  private http: Http;
  private baseUrl: string;
  private api: string = "/api/Tecnologias";


  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) { 
    this.http = http;
    this.baseUrl = baseUrl;
  }

  listarTecnologias() : Observable<Tecnologia[]> {
    return this.http.get(this.baseUrl + this.api)
    .map(res => res.json());
  };

  listarTecnologia(id: number) : Observable<Tecnologia> {
    return this.http.get(this.baseUrl + this.api+ "/" + id)
    .map(res => res.json());
  };

  salvarTecnologia(tecnologia: Tecnologia) {
    if(tecnologia.Id)
      return this.http.post(this.baseUrl + this.api, tecnologia);
      // .subscribe(() => {console.log("Candidato salvo com sucesso!")});

    return this.http.put(this.baseUrl + this.api + "/" + tecnologia.Id,  tecnologia);
    // .subscribe(() => {console.log("Candidato alterado com sucesso!")});
  }

  excluirTecnologia(id: number){
    return this.http.delete(this.baseUrl + this.api + "/" + id );
  }
  
}

export interface Tecnologia {
  Id: number;
  Nome: string;
}

