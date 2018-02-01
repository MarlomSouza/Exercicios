import { Component, OnInit } from '@angular/core';
import { ProcessoService } from '../../service/processo.service';
import { Processo } from '../../models/Processo';

@Component({
  selector: 'app-lista-processo',
  templateUrl: './lista-processo.component.html',
  styleUrls: ['./lista-processo.component.css']
})
export class ListaProcessoComponent implements OnInit {

  private service: ProcessoService;
  mensagem: string;
  processos: Processo[] = []

  constructor(service: ProcessoService) {
    this.service = service;
  }

  ngOnInit() {
    this.listarProcessos();
  }

  private listarProcessos() {
    this.service.listarProcessos()
      .subscribe(processos => this.processos = processos);
  }

  excluir(id: number, index: number) {
    this.service.excluirProcesso(id).subscribe(() => {

      this.processos.splice(index, 1);

      console.log("Processo excluido com sucesso!");

    }, error => console.log("ERRO ===> ", error));
  }

}
