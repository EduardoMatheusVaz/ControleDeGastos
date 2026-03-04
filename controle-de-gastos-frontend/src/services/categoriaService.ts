import { api } from "./api";
import type { Categoria } from "../types/Categoria";

export const categoriaService = {
  listar: async (): Promise<Categoria[]> => {
    return api.get<Categoria[]>("categorias");
  },

  criar: async (categoria: Categoria): Promise<number> => {
    return api.post<number>(
      `categorias?descricao=${categoria.descricao}&finalidade=${categoria.finalidade}`
    );
  },
};