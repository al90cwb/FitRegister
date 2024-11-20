import React, { createContext, useCallback, useState, useContext } from "react";

interface IDrawerContextData {
  isDrawerOpen: boolean;
  toggleDrawerOpen: () => void;
  drawerOptions: IDrawerOptions[];
  setDrawerOptions: (newDraweOptions: IDrawerOptions[]) => void;
}

const DrawerContext = createContext<IDrawerContextData | undefined>(undefined);

export const useDrawerContext = () => {
  const context = useContext(DrawerContext);
  if (!context) {
    throw new Error("useDrawerContext must be used within a AppDrawerProvider");
  }
  return context;
};

interface IAppDrawerProviderProps {
  children: React.ReactNode;
}

interface IDrawerOptions{
    icon:string;
    label:string;
    path:string;
}

export const DrawerProvider: React.FC<IAppDrawerProviderProps> = ({ children }) => {
  const [isDrawerOpen, setIsDrawerOpen] = useState(false);
  const [drawerOptions, setdrawerOptions] = useState<IDrawerOptions[]>([]);

  const toggleDrawerOpen = useCallback(() => {
    setIsDrawerOpen((oldDrawerOpen) => !oldDrawerOpen);
  }, []);

  //recebne por parametros njovas oções de menu
  const handleSetDrawerOption = useCallback((newDrawerOptions: IDrawerOptions[]) => {
    setdrawerOptions(newDrawerOptions);
  }, []);


  return (
    <DrawerContext.Provider value={{ isDrawerOpen, drawerOptions, toggleDrawerOpen, setDrawerOptions: handleSetDrawerOption}}>
      {children}
    </DrawerContext.Provider>
  );
};