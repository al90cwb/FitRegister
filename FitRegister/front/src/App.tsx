import { BrowserRouter } from "react-router-dom";
import { AppRoutes } from "./routes";
import { DrawerProvider, AppThemeProvider } from "./shared/context";
import { MenuLateral } from "./shared/components";
//import AlunoListar from "./pages/aluno/AlunoListar";
//import PlanoListar from "./pages/plano/PlanoListar";

function App() {
  return (
    <AppThemeProvider>
      <DrawerProvider>

        <BrowserRouter>

          <MenuLateral>
            <AppRoutes/>
          </MenuLateral>


        </BrowserRouter>
        
      </DrawerProvider>
    </AppThemeProvider>
  );
}
export default App;

// <PlanoListar />
// <AlunoListar />