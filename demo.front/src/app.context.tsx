import {
  useState,
  createContext,
  useMemo,
  ReactElement,
  Dispatch,
  SetStateAction,
  useEffect,
} from "react";
import { IUserAuth } from "./interfaces/auth.interfaces";
import { IFavorite } from "./interfaces/favorite.interfaces";
import useFavoriteService from "./hooks/favorite-service.hook";
import { EResponseCodes } from "./helpers/api-response";

interface IAppContext {
  authorization: IUserAuth;
  setAuthorization: Dispatch<SetStateAction<IUserAuth>>;
  favorites: IFavorite[];
  setFavorites: Dispatch<SetStateAction<IFavorite[]>>;
  validateActionAccess: (indicator: string) => boolean;
}

interface IProps {
  children: ReactElement | ReactElement[];
}

export const AppContext = createContext<IAppContext>({
  authorization: {} as IUserAuth,
  setAuthorization: () => {},
  validateActionAccess: () => false,
  favorites: [],
  setFavorites: () => {},
});

export function AppContextProvider({ children }: Readonly<IProps>) {
  // Services
  const { getFavoritesByUserId } = useFavoriteService();

  // States
  const [favorites, setFavorites] = useState<IFavorite[]>([]);
  const [authorization, setAuthorization] = useState<IUserAuth>({
    token: "",
  } as IUserAuth);

  function validateActionAccess(_indicator: string): boolean {
    return true;
  }

  useEffect(() => {
    if (authorization.user) {
      getFavoritesByUserId(authorization.user.id).then((res) => {
        if (res.operation.code == EResponseCodes.OK) setFavorites(res.data);
      });
    }
  }, [authorization]);

  const values = useMemo<IAppContext>(() => {
    return {
      authorization,
      setAuthorization,
      favorites,
      setFavorites,
      validateActionAccess,
    };
  }, [authorization]);

  return <AppContext.Provider value={values}>{children}</AppContext.Provider>;
}
