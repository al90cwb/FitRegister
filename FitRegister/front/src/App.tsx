import React from "react";
import { BrowserRouter } from "react-router-dom";
import AlunoListar from "./pages/aluno/AlunoListar";
import PlanoListar from "./pages/plano/PlanoListar";
import { AppRoutes } from "./routes";
import { ThemeProvider } from "@emotion/react";
import { LightTheme } from "./shared/themes";
import { AppThemeProvider } from "./shared/context";
import { MenuLateral } from "./shared/components";

function App() {
  return (
    <AppThemeProvider>
      <BrowserRouter>
        <MenuLateral>
          <AppRoutes/>
        </MenuLateral>
      </BrowserRouter>
    </AppThemeProvider>
  );
}
export default App;

// <PlanoListar />
// <AlunoListar />