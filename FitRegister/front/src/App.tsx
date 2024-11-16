import React from "react";
import { BrowserRouter } from "react-router-dom";
import AlunoListar from "./pages/aluno/AlunoListar";
import PlanoListar from "./pages/plano/PlanoListar";
import { AppRoutes } from "./routes";
import { ThemeProvider } from "@emotion/react";
import { LightTheme } from "./shared/themes";

function App() {
  return (
    <ThemeProvider theme={LightTheme}>
      <BrowserRouter>
        <AppRoutes/>
      </BrowserRouter>
    </ThemeProvider>
  );
}
export default App;

// <PlanoListar />
// <AlunoListar />