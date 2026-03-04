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
  IconButton,
  Button,
  Box,
  TextField
} from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";

import type { Pessoa as PessoaType } from "../../types/Pessoa";
import type { TotaisPessoa } from "../../types/TotaisPessoas";
import { pessoaService } from "../../services/pessoaService";
import { LayoutBase } from "../Layouts/layoutBase";

export default function Pessoas() {
  const [pessoas, setPessoas] = useState<PessoaType[]>([]);
  const [mostrarTotais, setMostrarTotais] = useState(false);
  const [totais, setTotais] = useState<TotaisPessoa[]>([]);
  const [filtroId, setFiltroId] = useState("");
  const navigate = useNavigate();

  const carregarPessoas = () => {
    pessoaService.listar()
      .then(setPessoas)
      .catch(err => console.error(err));
  };

  useEffect(() => {
    carregarPessoas();
  }, []);

  const handleBuscar = async () => {
    if (!filtroId) {
      carregarPessoas();
      return;
    }

    const lista = await pessoaService.listar();
    const filtrado = lista.filter(p => p.idPessoa === Number(filtroId));
    setPessoas(filtrado);
  };

  const handleExcluir = async (id: number) => {
    if (!window.confirm("Deseja realmente excluir?")) return;

    await pessoaService.deletar(id);
    setPessoas(pessoas.filter(p => p.idPessoa !== id));
  };

  const handleVerTotais = async () => {
    const lista = await pessoaService.obterTotais();
    setTotais(lista);
    setMostrarTotais(true);
  };

  return (
    <LayoutBase>
      <Container maxWidth="lg">
        <Box display="flex" justifyContent="space-between" mb={3}>
          <Typography variant="h4">Pessoas</Typography>
          <Button variant="contained" onClick={() => navigate("/pessoas/nova")}>
            + Nova Pessoa
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
          <Button variant="contained" onClick={handleBuscar}>
            Buscar
          </Button>
          <Button variant="outlined" onClick={handleVerTotais}>
            Ver Totais
          </Button>
        </Box>

        {/* Lista normal de pessoas */}
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Id</TableCell>
              <TableCell>Nome</TableCell>
              <TableCell>Idade</TableCell>
              <TableCell align="right">Ações</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {pessoas.map((p) => (
              <TableRow key={p.idPessoa}>
                <TableCell>{p.idPessoa}</TableCell>
                <TableCell>{p.nome}</TableCell>
                <TableCell>{p.idade}</TableCell>
                <TableCell align="right">
                  <IconButton onClick={() => navigate(`/pessoas/editar/${p.idPessoa}`)}>
                    <EditIcon />
                  </IconButton>
                  <IconButton color="error" onClick={() => handleExcluir(p.idPessoa)}>
                    <DeleteIcon />
                  </IconButton>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>

        {/* Consulta de Totais por pessoa */}
        {mostrarTotais && (
          <>
            <Typography variant="h5" mt={4} mb={2}>
              Totais por Pessoa
            </Typography>
            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>Nome</TableCell>
                  <TableCell>Receitas</TableCell>
                  <TableCell>Despesas</TableCell>
                  <TableCell>Saldo</TableCell>
                </TableRow>
              </TableHead>

              <TableBody>
                {totais.map(t => (
                  <TableRow key={t.idPessoa}>
                    <TableCell>{t.nome}</TableCell>
                    <TableCell>{t.receitas}</TableCell>
                    <TableCell>{t.despesas}</TableCell>
                    <TableCell>{t.saldo}</TableCell>
                  </TableRow>
                ))}
                {/* Linha do total geral */}
                <TableRow>
                  <TableCell><strong>Total Geral</strong></TableCell>
                  <TableCell>
                    <strong>{totais.reduce((acc, t) => acc + t.receitas, 0)}</strong>
                  </TableCell>
                  <TableCell>
                    <strong>{totais.reduce((acc, t) => acc + t.despesas, 0)}</strong>
                  </TableCell>
                  <TableCell>
                    <strong>{totais.reduce((acc, t) => acc + t.saldo, 0)}</strong>
                  </TableCell>
                </TableRow>
              </TableBody>
            </Table>
          </>
        )}
      </Container>
    </LayoutBase>
  );
}