import { Container, Typography, Box } from "@mui/material";
import { LayoutBase } from "./Layouts/layoutBase";

export default function Home() {
  return (
    <LayoutBase>
      <Container maxWidth="md">
        <Box sx={{ textAlign: "center", mt: 6 }}>
          <Typography
            variant="h2"
            component="h1"
            fontWeight="bold">
            Controle de Gastos
          </Typography>

          <Typography
            variant="h6"
            sx={{ mt: 2, opacity: 0.7 }}
          >
            Organize suas finanças com clareza.
          </Typography>
        </Box>
      </Container>
    </LayoutBase>
  );
}