import { Component, Input } from '@angular/core';


@Component({
  moduleId: module.id,
  selector: 'repositorio',
  templateUrl: 'repositorio.component.html',
  styleUrls: ['repositorio.component.css']
})
export class RepositorioComponent {

  // @Input() avatar_url : string;
  
  // @Input() login: string;
  // @Input() url: string;

  @Input() id: number;
  @Input() nome: string;
  @Input() descricao: string;
  @Input() url: string; 
  
  @Input() data_criacao: Date;
  @Input() clone_url: Date;
  @Input() stars: number;
  @Input() watchers: number;
  @Input() linguagem: string;
  @Input() forks: number;
  @Input() branch: string;
  

  constructor()  {
   }



}
