import { api } from "./api";
import type { Pessoa } from "../types/Pessoa";
import type { TotaisPessoa } from "../types/TotaisPessoas";

export const pessoaService = {
  listar: async (): Promise<Pessoa[]> => {
    return api.get<Pessoa[]>("pessoas/todas_pessoas");
  },

  criar: async (pessoa: Pessoa): Promise<number> => {
    return api.post<number>(
      `pessoas?nome=${pessoa.nome}&idade=${pessoa.idade}`
    );
  },

  atualizar: async (id: number, pessoa: Pessoa): Promise<boolean> => {
    return api.put<boolean>(
      `pessoas/${id}?nome=${pessoa.nome}&idade=${pessoa.idade}`
    );
  },

  deletar: async (id: number): Promise<void> => {
    return api.delete(`pessoas/${id}`);
  },

  obterTotais: async (): Promise<TotaisPessoa[]> => {
    return api.get<TotaisPessoa[]>("pessoas/totais_pessoas");
  },
};