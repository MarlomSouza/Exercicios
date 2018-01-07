import { Component, OnInit } from '@angular/core';
import { CandidatoService, Candidato } from '../../service/candidato.service';

@Component({
  selector: 'app-lista-candidato',
  templateUrl: './lista-candidato.component.html'
})
export class ListaCandidatoComponent implements OnInit {

  private _service: CandidatoService;
  candidatos : Candidato[] = []

  constructor(service: CandidatoService) { 
    this._service = service;
  }

  ngOnInit() {
    this.listarCandidatos();
  }

  private listarCandidatos(){
    this._service.listarCandidatos()
    .subscribe(candidatos => this.candidatos = candidatos);
  }

  excluir(id: number, index: number){
    this._service.excluirUsuario(id).subscribe(() => {

      this.candidatos.splice(index , 1);

      console.log("Candidato excluido com sucesso!");

    }, error => console.log("ERRO ===> ", error));
  }
}

