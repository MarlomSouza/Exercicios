import { CandidatoTecnologia } from "./CandidatoTecnologia";

export class Candidato {
  id: number;
  nome: string;
  tecnologias: CandidatoTecnologia[] = [];
}