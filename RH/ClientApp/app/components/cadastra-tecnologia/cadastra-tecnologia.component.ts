import { Component, OnInit } from '@angular/core';
import { TecnologiaService } from '../../service/tecnologia.service';
import { ActivatedRoute, Router } from "@angular/router";
import { Tecnologia } from '../../models/Tecnologia';

@Component({
  selector: 'app-cadastra-tecnologia',
  templateUrl: './cadastra-tecnologia.component.html',
  styleUrls: ['./cadastra-tecnologia.component.css']
})
export class CadastraTecnologiaComponent implements OnInit {

  private _route: ActivatedRoute;
  tecnologia: Tecnologia = new Tecnologia();
  private _service: TecnologiaService;
  private _router: Router;

  constructor(service: TecnologiaService, route: ActivatedRoute, router: Router) {
    this._service = service;
    this._route = route;
    this._router = router;

    this._route.params.subscribe(params => {
      let id: number = params['id'];

      if (id) {
        this.tecnologia.id = id;
        this.buscarPorId(id);
      }
    });
  }

  ngOnInit() {

  }

  salvar() {

    this._service.salvarTecnologia(this.tecnologia)
      .subscribe(() => {
        console.log("Tecnologia salva com sucesso!");
        this._router.navigate(['/lista-tecnologia'])
      }, erro => console.log("ERROR ==>", erro));
  }

  /**
   * buscarPorId
   */
  public buscarPorId(id: number) {
    this._service.listarTecnologia(id).subscribe(tecnologia => this.tecnologia = tecnologia);
  }

}