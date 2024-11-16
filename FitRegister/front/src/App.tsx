import React from "react";
import { BrowserRouter } from "react-router-dom";
import AlunoListar from "./pages/aluno/AlunoListar";
import PlanoListar from "./pages/plano/PlanoListar";
import { AppRoutes } from "./routes";

function App() {
  return (
    <BrowserRouter>
      <AppRoutes/>
      <div>
        
      </div>
    </BrowserRouter>
  );
}
export default App;

// <PlanoListar />
// <AlunoListar />