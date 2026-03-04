import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "../src/pages/Home";
import Pessoas from "../src/pages/Pessoas";
import Categorias from "../src/pages/Categoria";
import Transacoes from "../src/pages/Transacao";
import PessoaEditar from "./pages/Pessoas/PessoaEditar";
import NovaPessoa from "./pages/Pessoas/NovaPessoa";
import NovaCategoria from "./pages/Categoria/NovaCategoria";
import NovaTransacao from "./pages/Transacao/NovaTransacao";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        {/* 👇 PÁGINA INICIAL */}
        <Route path="/" element={<Home />} />

        <Route path="/pessoas" element={<Pessoas />} />
        <Route path="/categorias" element={<Categorias />} />
        <Route path="/transacoes" element={<Transacoes />} />
        <Route path="/pessoas/editar/:id" element={<PessoaEditar />} />
        <Route path="/pessoas/nova" element={<NovaPessoa/>} />
        <Route path="/categorias/nova" element={<NovaCategoria/>} />
        <Route path="/transacoes/nova" element={<NovaTransacao/>} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;