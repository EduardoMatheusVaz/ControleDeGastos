import { useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  Container,
  TextField,
  Button,
  Typography,
  Box
} from "@mui/material";

import { transacaoService } from "../../services/transacaoService";
import type { Transacao } from "../../types/Transacao";
import { LayoutBase } from "../Layouts/layoutBase";

export default function NovaTransacao() {
  const navigate = useNavigate();

  const [transacao, setTransacao] = useState<Transacao>({
    idTransacao: 0,
    descricao: "",
    valor: 0,
    tipoDespesa: 0,
    idPessoa: 0,
    idCategoria: 0
  });

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
    try {
        await transacaoService.criar(transacao);
        navigate("/transacoes");
    } catch (err: unknown) {
        if (err instanceof Error) {
        alert(err.message);
        } else {
        alert("Erro ao cadastrar transação");
        }
    }
    };

  return (
    <LayoutBase>
      <Container maxWidth="sm">
        <Typography variant="h4" mb={3}>
          Nova Transação
        </Typography>

        <Box component="form" onSubmit={handleSubmit}>
          <TextField
            fullWidth
            label="Descrição"
            margin="normal"
            value={transacao.descricao}
            onChange={(e) =>
              setTransacao({ ...transacao, descricao: e.target.value })
            }
          />
          <TextField
            fullWidth
            label="Valor"
            type="number"
            margin="normal"
            value={transacao.valor}
            onChange={(e) =>
              setTransacao({ ...transacao, valor: Number(e.target.value) })
            }
          />
          <TextField
            fullWidth
            label="Tipo de Despesa"
            type="number"
            margin="normal"
            value={transacao.tipoDespesa}
            onChange={(e) =>
              setTransacao({ ...transacao, tipoDespesa: Number(e.target.value) })
            }
          />
          <TextField
            fullWidth
            label="ID da Pessoa"
            type="number"
            margin="normal"
            value={transacao.idPessoa}
            onChange={(e) =>
              setTransacao({ ...transacao, idPessoa: Number(e.target.value) })
            }
          />
          <TextField
            fullWidth
            label="ID da Categoria"
            type="number"
            margin="normal"
            value={transacao.idCategoria}
            onChange={(e) =>
              setTransacao({ ...transacao, idCategoria: Number(e.target.value) })
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