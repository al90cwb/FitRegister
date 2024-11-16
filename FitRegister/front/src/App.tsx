import React from "react";
import { BrowserRouter } from "react-router-dom";
import AlunoListar from "./pages/aluno/AlunoListar";
import PlanoListar from "./pages/plano/PlanoListar";
import { AppRoutes } from "./routes";
import { ThemeProvider } from "@emotion/react";
import { LightTheme } from "./shared/themes";
import { AppThemeProvider } from "./shared/context";

function App() {
  return (
    <AppThemeProvider>
      <BrowserRouter>
        <AppRoutes/>
      </BrowserRouter>
    </AppThemeProvider>
  );
}
export default App;

// <PlanoListar />
// <AlunoListar />