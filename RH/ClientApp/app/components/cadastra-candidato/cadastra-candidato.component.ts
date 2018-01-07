import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { TecnologiaService, Tecnologia } from '../../service/tecnologia.service';
import { CandidatoService, Candidato, CandidatoTecnologia } from '../../service/candidato.service';

@Component({
  selector: 'app-cadastra-candidato',
  templateUrl: './cadastra-candidato.component.html',
  styleUrls: ['./cadastra-candidato.component.css']
})
export class CadastraCandidatoComponent implements OnInit {

  private _route: ActivatedRoute;
  candidato: Candidato = new Candidato();
  private _service: CandidatoService;
  private _tecnologiaService: TecnologiaService;
  private _router: Router;
  tecnologias : Tecnologia[] = [];
  tecnologiasSelecionadas: any[]=[1];

  constructor(service: CandidatoService, tecnologiaService: TecnologiaService ,route: ActivatedRoute, router: Router ) { 
    this._service = service;
    this._tecnologiaService = tecnologiaService
    this._route = route;
    this._router = router;
    this.listarTecnologias();
    this._route.params.subscribe(params =>
      {
        let id :number = params['id'];
        
        if(id){
          this.candidato.id = id;
          this.buscarPorId(id);
        }
      });
  }

  ngOnInit() {
  
  }

  salvar(){
  console.log(this.candidato);
  this.selecionarLinguagensConhecidas();
    this._service.salvarCandidato(this.candidato)
    .subscribe(() => {
      console.log("Candidato salva com sucesso!"); 
      this._router.navigate(['/lista-candidato'])
    }, erro => console.log("ERROR ==>", erro));
  }

  private selecionarLinguagensConhecidas(){
    this.tecnologiasSelecionadas.forEach((tecnologiaId) =>{
      let candidatoTecnologia = new CandidatoTecnologia();
      candidatoTecnologia.candidatoId = this.candidato.id;
      candidatoTecnologia.tecnologiaId = tecnologiaId
      this.candidato.tecnologias.push(candidatoTecnologia);
    })
  }

  /**
   * buscarPorId
   */
  public buscarPorId(id: number) {
    this._service.listarCandidato(id).subscribe(candidato => this.candidato = candidato);
  }

  /**
   * listarTecnologias
   */
  public listarTecnologias() {
    this._tecnologiaService.listarTecnologias()
    .subscribe(tecnologias => this.tecnologias = tecnologias);
  }

}
