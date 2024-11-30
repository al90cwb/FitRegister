import { BrowserRouter } from "react-router-dom";
import { AppRoutes } from "./routes";
import { DrawerProvider, AppThemeProvider } from "./shared/context";
import { MenuLateral } from "./shared/components";
import { useEffect, useState } from "react";

function App() {
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    const authStatus = localStorage.getItem("isAuthenticated") === "true";
    setIsAuthenticated(authStatus);
  }, []);

  return (
    <AppThemeProvider>
      <DrawerProvider>
        <BrowserRouter>
          {isAuthenticated ? (
            <MenuLateral>
              <AppRoutes />
            </MenuLateral>
          ) : (
            <AppRoutes />
          )}
        </BrowserRouter>
      </DrawerProvider>
    </AppThemeProvider>
  );
}
export default App;
