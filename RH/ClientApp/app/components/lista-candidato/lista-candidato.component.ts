import { Component, OnInit } from '@angular/core';
import { CandidatoService, Candidato } from '../../service/candidato.service';

@Component({
  selector: 'app-lista-candidato',
  templateUrl: './lista-candidato.component.html'
})
export class ListaCandidatoComponent implements OnInit {

  private service: CandidatoService;
  candidatos : Candidato[] = []

  constructor(service: CandidatoService) { 
    this.service = service;
  }

  ngOnInit() {
    this.listaCandidatos();
  }

  private listaCandidatos(){
    this.service.listarCandidatos()
    .subscribe(candidatos => this.candidatos = candidatos);
  }

}

