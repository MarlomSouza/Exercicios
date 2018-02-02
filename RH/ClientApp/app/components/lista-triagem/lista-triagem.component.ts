import { Component, OnInit } from '@angular/core';
import { TriagemService } from '../../service/triagem.service';
import { Triagem } from '../../Models/Triagem';

@Component({
  selector: 'app-lista-triagem',
  templateUrl: './lista-triagem.component.html',
  styleUrls: ['./lista-triagem.component.css']
})
export class ListaTriagemComponent implements OnInit {

  private service: TriagemService;
  mensagem: string;
  triagens: Triagem[] = [];

  constructor(service: TriagemService) {
    this.service = service;
  }

  ngOnInit() {
    this.listarTriagem();
  }

  private listarTriagem() {
    this.service.listarTriagens()
      .subscribe(triagens => {
        this.triagens = triagens;
        console.log("trigens", triagens[0].processo.tecnologias[0].peso);
      });
  }

}
