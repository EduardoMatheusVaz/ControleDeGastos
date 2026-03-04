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

import type { Categoria } from "../../types/Categoria";
import { categoriaService } from "../../services/categoriaService";
import { LayoutBase } from "../Layouts/layoutBase";

export default function Categorias() {
  const [categorias, setCategorias] = useState<Categoria[]>([]);
  const [filtroId, setFiltroId] = useState("");
  const navigate = useNavigate();

  const carregarCategorias = () => {
    categoriaService.listar()
      .then(setCategorias)
      .catch(err => console.error(err));
  };

useEffect(() => {
  categoriaService.listar()
    .then(data => {
      console.log("RETORNO:", data);
      setCategorias(data);
    })
    .catch(err => console.error(err));
}, []);

  const handleBuscar = async () => {
    if (!filtroId) {
      carregarCategorias();
      return;
    }

    const lista = await categoriaService.listar();
    const filtrado = lista.filter(
      c => c.idCategoria === Number(filtroId)
    );
    setCategorias(filtrado);
  };

  return (
    <LayoutBase>
      <Container maxWidth="lg">
        <Box display="flex" justifyContent="space-between" mb={3}>
          <Typography variant="h4">Categorias</Typography>

          <Button
            variant="contained"
            onClick={() => navigate("/categorias/nova")}
          >
            + Nova Categoria
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
              <TableCell>Finalidade</TableCell>
            </TableRow>
          </TableHead>

          <TableBody>
            {categorias.map((c) => (
              <TableRow key={c.idCategoria}>
                <TableCell>{c.idCategoria}</TableCell>
                <TableCell>{c.descricao}</TableCell>
                <TableCell>{c.finalidade}</TableCell>
                <TableCell>
                  {c.finalidade === 1 ? "Saída" : "Entrada"}
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </Container>
    </LayoutBase>
  );
}