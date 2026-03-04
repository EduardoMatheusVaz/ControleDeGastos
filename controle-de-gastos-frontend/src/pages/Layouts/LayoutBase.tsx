import { Box, AppBar, Toolbar, Button } from "@mui/material";
import HomeIcon from "@mui/icons-material/Home";
import { useNavigate } from "react-router-dom";
import type { ReactNode } from "react";

interface LayoutBaseProps {
  children: ReactNode;
}

export const LayoutBase = ({ children }: LayoutBaseProps) => {
  const navigate = useNavigate();

  return (
    <Box
      sx={{
        minHeight: "100vh",
        width: "100%",
        backgroundColor: "#EAE7DD",
        display: "flex",
        flexDirection: "column"
      }}
    >
      <AppBar position="fixed">
        <Toolbar
          sx={{
            display: "flex",
            justifyContent: "center",
            gap: 3,
            backgroundColor: "#7E6CE9"
          }}
        >
          <Button color="inherit" onClick={() => navigate("/pessoas")}>
            Pessoas
          </Button>
          <Button color="inherit" onClick={() => navigate("/categorias")}>
            Categorias
          </Button>
          <Button color="inherit" onClick={() => navigate("/transacoes")}>
            Transações
          </Button>
        </Toolbar>
      </AppBar>

      <Toolbar /> 

      <Box sx={{ flex: 1, p: 3 }}>
        {children}
      </Box>

      <Box
        sx={{
          position: "fixed",
          bottom: 20,
          left: 20
        }}
      >
        <Button
        variant="contained"
        startIcon={<HomeIcon />}
        onClick={() => navigate("/")}>
        Home
      </Button>
      </Box>
    </Box>
  );
};