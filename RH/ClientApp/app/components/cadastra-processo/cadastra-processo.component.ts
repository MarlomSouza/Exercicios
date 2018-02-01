import { Component, OnInit } from '@angular/core';
import { ProcessoService } from '../../service/processo.service';
import { TecnologiaService } from '../../service/tecnologia.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Processo } from '../../models/Processo';
import { Tecnologia } from '../../models/Tecnologia';
import { ProcessoTecnologia } from '../../models/ProcessoTecnologia';

@Component({
  selector: 'app-cadastra-processo',
  templateUrl: './cadastra-processo.component.html',
  styleUrls: ['./cadastra-processo.component.css']
})
export class CadastraProcessoComponent implements OnInit {

  private _route: ActivatedRoute;
  processo: Processo = new Processo();
  private _service: ProcessoService;
  private _tecnologiaService: TecnologiaService;
  private _router: Router;
  tecnologias: Tecnologia[] = [];
  tecnologiasSelecionadas: any[] = [1];

  constructor(service: ProcessoService, tecnologiaService: TecnologiaService, route: ActivatedRoute, router: Router) {
    this._service = service;
    this._tecnologiaService = tecnologiaService
    this._route = route;
    this._router = router;
    this.listarTecnologias();
    this._route.params.subscribe(params => {
      let id: number = params['id'];

      if (id) {
        this.processo.id = id;
        this.buscarPorId(id);
      }
    });
  }

  ngOnInit() {

  }

  salvar() {
    this.selecionarLinguagensConhecidas();
    this._service.salvarProcesso(this.processo)
      .subscribe(() => {
        console.log("Processo salvo com sucesso!");
        this._router.navigate(['/lista-processo'])
      }, erro => console.log("ERROR ==>", erro));
  }

  private selecionarLinguagensConhecidas() {
    this.tecnologiasSelecionadas.forEach((tecnologiaId) => {
      let processoTecnologia = new ProcessoTecnologia();
      processoTecnologia.processoId = this.processo.id;
      processoTecnologia.tecnologiaId = tecnologiaId
      this.processo.tecnologias.push(processoTecnologia);
    })
  }

  /**
   * buscarPorId
   */
  public buscarPorId(id: number) {
    this._service.listarProcesso(id).subscribe(processo => this.processo = processo);
  }

  /**
   * listarTecnologias
   */
  public listarTecnologias() {
    this._tecnologiaService.listarTecnologias()
      .subscribe(tecnologias => this.tecnologias = tecnologias);
  }
}
