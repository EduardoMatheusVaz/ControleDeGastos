import { useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  Container,
  TextField,
  Button,
  Typography,
  Box
} from "@mui/material";

import { pessoaService } from "../../services/pessoaService";
import { LayoutBase } from "../Layouts/layoutBase";
import type { Pessoa } from "../../types/Pessoa";

export default function NovaPessoa() {
  const navigate = useNavigate();

  const [pessoa, setPessoa] = useState<Pessoa>({
    idPessoa: 0,
    nome: "",
    idade: 0
  });

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
        await pessoaService.criar({
        nome: pessoa.nome,
        idade: pessoa.idade
        } as Pessoa);

        navigate("/pessoas");
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
          Nova Pessoa
        </Typography>

        <Box component="form" onSubmit={handleSubmit}>
          <TextField
            fullWidth
            label="Nome"
            margin="normal"
            value={pessoa.nome}
            onChange={(e) =>
              setPessoa({ ...pessoa, nome: e.target.value })
            }
          />

          <TextField
            fullWidth
            label="Idade"
            type="number"
            margin="normal"
            value={pessoa.idade}
            onChange={(e) =>
              setPessoa({ ...pessoa, idade: Number(e.target.value) })
            }
          />

          <Box display="flex" justifyContent="center" mt={2}>
            <Button
                type="submit"
                variant="contained">
                Salvar
            </Button>
        </Box>
        </Box>
      </Container>
    </LayoutBase>
  );
}