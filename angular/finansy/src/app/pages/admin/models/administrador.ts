export interface AdministradorViewModel {
  id: number;
  nome: string;
  email: string;
  telefone?: string;
  cpf: string;
  desativado: boolean;
}

export interface CadastrarViewModel {
  nome: string;
  email: string;
  senha: string;
  telefone?: string;
  cpf: string;
}

export interface LoginViewModel {
  email: string;
  senha: string;
}

export interface AtualizarViewModel {
  id: number;
  nome: string;
  email: string;
  telefone?: string;
  cpf: string;
}
