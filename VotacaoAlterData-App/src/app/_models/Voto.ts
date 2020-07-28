import { ItemRecursoVoto } from "./ItemRecursoVoto";

export class Voto
{
  votoId: number;
  itemRecursoId: number;
  dataDataCadastro: Date;
  comentario: string;
  itemRecursoVoto: ItemRecursoVoto[];

}
