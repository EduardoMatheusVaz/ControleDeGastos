import { api } from "./api";
import type { Transacao } from "../types/Transacao";

export const transacaoService = {
  listar: async (): Promise<Transacao[]> => {
    return api.get<Transacao[]>("transacoes");
  },

  criar: async (transacao: Transacao): Promise<number> => {
    return api.post<number>(
      `transacoes?descricao=${transacao.descricao}&valor=${transacao.valor}&tipoDespesa=${transacao.tipoDespesa}&categoria=${transacao.idCategoria}&idPessoa=${transacao.idPessoa}`
    );
  }
};