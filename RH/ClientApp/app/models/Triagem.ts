import { Candidato } from "./Candidato";

export class Triagem {
  id: number;
  ProcessoId: number;
  Candidatos: Candidato[] = [];
}