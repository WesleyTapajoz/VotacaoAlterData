import { Recurso } from "./Recurso";
import { Voto } from "./Voto";

export class ItemRecursoVoto
{
  itemRecursoId: number;
  dataCadastro: Date;
  recursoId: string;
  descricao: string;
  active: boolean = false;
  recurso: Recurso;
  votado: boolean;
  votos: Voto[];
}
