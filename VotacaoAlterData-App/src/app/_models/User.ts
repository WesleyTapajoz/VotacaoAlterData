import { RecursoUser } from "./RecursoUser";

export class User{
  id: number;
  email: string;
  fullName: string;
  endereco: string;
  cpf: string;
  telefone: string;
  ativo: boolean;
  recursosUsers: RecursoUser[];
}
