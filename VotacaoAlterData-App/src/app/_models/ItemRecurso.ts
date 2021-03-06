import { Voto } from "./Voto";
import { Recurso } from './Recurso';
import { ItemRecursoVoto } from "./ItemRecursoVoto";

export class ItemRecurso
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
