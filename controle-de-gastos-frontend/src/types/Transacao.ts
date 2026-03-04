export interface Transacao {
  idTransacao: number;
  descricao: string;
  valor: number;
  tipoDespesa: number;
  idCategoria: number;
  idPessoa: number;
}