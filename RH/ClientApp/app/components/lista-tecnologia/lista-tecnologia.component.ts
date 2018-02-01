import { Component, OnInit } from '@angular/core';
import { TecnologiaService } from '../../service/tecnologia.service';
import { Tecnologia } from '../../models/Tecnologia';

@Component({
  selector: 'app-lista-tecnologia',
  templateUrl: './lista-tecnologia.component.html',
  styleUrls: ['./lista-tecnologia.component.css']
})
export class ListaTecnologiaComponent implements OnInit {

  private service: TecnologiaService;
  mensagem: string;
  tecnologias: Tecnologia[] = []

  constructor(service: TecnologiaService) {
    this.service = service;
  }

  ngOnInit() {
    this.listarTecnologias();
  }

  private listarTecnologias() {
    this.service.listarTecnologias()
      .subscribe(tecnologias => this.tecnologias = tecnologias);
  }

  excluir(id: number, index: number) {
    this.service.excluirTecnologia(id).subscribe(() => {

      this.tecnologias.splice(index, 1);

      console.log("Tecnologia excluida com sucesso!");

    }, error => console.log("ERRO ===> ", error));
  }

}
