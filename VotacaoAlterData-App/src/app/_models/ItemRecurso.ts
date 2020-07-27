import { Voto } from "./Voto";

export class ItemRecurso
{
  itemRecursoId: number;
  dataCadastro: Date;
  recursoId: string;
  votos: Voto[];
  descricao: string;
}
