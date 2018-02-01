import { ProcessoTecnologia } from "./ProcessoTecnologia";

export class Processo {
  id: number;
  nome: string;
  tecnologias: ProcessoTecnologia[] = [];
}
