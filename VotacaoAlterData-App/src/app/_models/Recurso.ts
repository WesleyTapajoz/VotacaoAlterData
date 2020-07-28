import { ItemRecurso } from "./ItemRecurso";
import { RecursoUser } from "./RecursoUser";


export class Recurso
{
  recursoId: string;
  dataCadastro: Date;
  itensRecurso: ItemRecurso[];
  recursosUsers: RecursoUser[];
  descricao: string;
  ativo: boolean;
}
