import { ItemRecurso } from "./ItemRecurso";
import { User } from "./User";


export class Recurso
{
  recursoId: string;
  dataCadastro: Date;
  itensRecurso: ItemRecurso[];
  users: User[];
  descricao: string;
}
