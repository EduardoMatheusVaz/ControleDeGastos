import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  Container,
  Typography,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Button,
  Box,
  TextField
} from "@mui/material";

import type { Transacao } from "../../types/Transacao";
import { transacaoService } from "../../services/transacaoService";
import { LayoutBase } from "../Layouts/layoutBase";

export default function Transacoes() {
  const [transacoes, setTransacoes] = useState<Transacao[]>([]);
  const [filtroId, setFiltroId] = useState("");
  const navigate = useNavigate();

  const carregarTransacoes = () => {
    transacaoService.listar()
      .then(setTransacoes)
      .catch(err => console.error(err));
  };

  useEffect(() => {
    carregarTransacoes();
  }, []);

  const handleBuscar = async () => {
    if (!filtroId) {
      carregarTransacoes();
      return;
    }

    const lista = await transacaoService.listar();
    const filtrado = lista.filter(
      t => t.idTransacao === Number(filtroId)
    );
    setTransacoes(filtrado);
  };

  return (
    <LayoutBase>
      <Container maxWidth="lg">
        <Box display="flex" justifyContent="space-between" mb={3}>
          <Typography variant="h4">Transações</Typography>

          <Button
            variant="contained"
            onClick={() => navigate("/transacoes/nova")}
          >
            + Nova Transação
          </Button>
        </Box>

        <Box display="flex" gap={2} mb={3}>
          <TextField
            fullWidth
            label="Buscar por ID"
            type="number"
            value={filtroId}
            onChange={(e) => setFiltroId(e.target.value)}
          />
          <Button
            variant="contained"
            onClick={handleBuscar}
          >
            Buscar
          </Button>
        </Box>

        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Id</TableCell>
              <TableCell>Descrição</TableCell>
              <TableCell>Valor</TableCell>
              <TableCell>Tipo de Despesa</TableCell>
              <TableCell>Id Categoria</TableCell>
              <TableCell>Id Pessoa</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {transacoes.map((t) => (
              <TableRow key={t.idTransacao}>
                <TableCell>{t.idTransacao}</TableCell>
                <TableCell>{t.descricao}</TableCell>
                <TableCell>{t.valor}</TableCell>
                <TableCell>{t.tipoDespesa}</TableCell>
                <TableCell>{t.idCategoria}</TableCell>
                <TableCell>{t.idPessoa}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </Container>
    </LayoutBase>
  );
}