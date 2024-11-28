import { useContext, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { ImHome } from "react-icons/im";
import { AppContext } from "../app.context";
import { ButtonComponent } from "./button.component";
import { CiLogin } from "react-icons/ci";
import { CgUser } from "react-icons/cg";
import { MdOutlineBookmarks } from "react-icons/md";
import ModalMessageComponent, { IMessage } from "./modal-message.component";
import { EResponseCodes } from "../helpers/api-response";
import { IFavorite } from "../interfaces/favorite.interfaces";

export function HeaderComponent() {
  // Services
  const location = useLocation();
  const navigate = useNavigate();
  const { authorization, favorites } = useContext(AppContext);

  //States
  const [message, setMessage] = useState<IMessage | null>(null);

  if (location.pathname === "/login") {
    return null;
  }
  return (
    <>
      <div className="text-gray-50 bg-gray-700 p-4 flex flex-wrap  justify-between">
        <div
          className="font-bold hover:cursor-pointer block px-4 mt-3 text-2xl hover:text-blue-500"
          onClick={() => navigate("/")}
        >
          <ImHome />
        </div>
        <div className="m-0  flex flex-row justify-end gap-2 ">
          <ButtonComponent
            className="text-white"
            icon={<CgUser />}
            buttonStyle="Secondary"
            value="Usuarios"
            action={() => navigate("/users")}
          />

          <ButtonComponent
            className="text-white"
            icon={<MdOutlineBookmarks />}
            buttonStyle="Secondary"
            value="Favoritos"
            disabled={!authorization?.user}
            action={() => {
              setMessage({
                type: EResponseCodes.OK,
                title: `Comics Favoritos`,
                description: (
                  <ul>
                    {favorites.map((i: IFavorite) => {
                      return <li>{i.titule}</li>;
                    })}
                  </ul>
                ),
                onOk() {
                  setMessage(null);
                },
              });
            }}
          />
        </div>

        {authorization?.user?.name ? (
          <>
            <label className="text-base font-bold mt-3">
              Hola, {authorization?.user?.name ?? ""}
            </label>
          </>
        ) : (
          <>
            <ButtonComponent
              className="text-white"
              icon={<CiLogin />}
              buttonStyle="Secondary"
              value="Iniciar Sesion"
              action={() => navigate("/login")}
            />
          </>
        )}
      </div>
      <ModalMessageComponent
        message={message}
        clearMessage={() => setMessage(null)}
      />
    </>
  );
}
