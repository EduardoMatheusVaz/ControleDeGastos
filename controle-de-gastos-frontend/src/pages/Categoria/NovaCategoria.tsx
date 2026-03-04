import { useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  Container,
  TextField,
  Button,
  Typography,
  Box
} from "@mui/material";

import { categoriaService } from "../../services/categoriaService";
import { LayoutBase } from "../Layouts/layoutBase";
import type { Categoria } from "../../types/Categoria";

export default function NovaCategoria() {
  const navigate = useNavigate();

  const [categoria, setCategoria] = useState<Categoria>({
    idCategoria: 0,
    descricao: "",
    finalidade: 0
  });

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();

  try {
    await categoriaService.criar({
      descricao: categoria.descricao,
      finalidade: categoria.finalidade
    } as Categoria);

    navigate("/categorias");
  } catch (error: unknown) {
    if (error instanceof Error) {
      alert(error.message);
    } else {
      alert("Erro desconhecido");
    }
  }
};

  return (
    <LayoutBase>
      <Container maxWidth="sm">
        <Typography variant="h4" mb={3}>
          Nova Categoria
        </Typography>

        <Box component="form" onSubmit={handleSubmit}>
          <TextField
            fullWidth
            label="Descrição"
            margin="normal"
            value={categoria.descricao}
            onChange={(e) =>
              setCategoria({ ...categoria, descricao: e.target.value })
            }
          />

          <TextField
            fullWidth
            label="Finalidade"
            type="number"
            margin="normal"
            value={categoria.finalidade}
            onChange={(e) =>
              setCategoria({ ...categoria, finalidade: Number(e.target.value) })
            }
          />

          <Box display="flex" justifyContent="center" mt={2}>
            <Button type="submit" variant="contained">
              Salvar
            </Button>
          </Box>
        </Box>
      </Container>
    </LayoutBase>
  );
}