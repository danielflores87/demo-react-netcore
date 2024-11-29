import { useContext, useEffect, useState } from "react";
import { useMarvelService } from "../hooks/marvel-service.hook";
import { IComic } from "../interfaces/marvel.interfaces";
import { EResponseCodes } from "../helpers/api-response";
import ModalMessageComponent, {
  IMessage,
} from "../componets/modal-message.component";
import { PageComponent } from "../componets/content";
import { Pagination, Spin } from "antd";
import { ButtonComponent } from "../componets/button.component";
import { MdOutlineBookmarkAdd } from "react-icons/md";
import { AppContext } from "../app.context";
import useFavoriteService from "../hooks/favorite-service.hook";
import { BsBookmarkStarFill } from "react-icons/bs";
import LabelComponent from "../componets/label.component";

function HomePage(): JSX.Element {
  // Services
  const { getPaginatedComics } = useMarvelService();
  const { authorization, favorites, setFavorites } = useContext(AppContext);
  const { addFavorite } = useFavoriteService();

  //States
  const [comics, setComics] = useState<IComic[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const [adding, setAdding] = useState<number | null>(null);
  const [total, setTotal] = useState<number>(0);
  const [page, setPage] = useState<number>(1);
  const [message, setMessage] = useState<IMessage | null>(null);

  // Effect que hace la carga inicial de los comics
  useEffect(() => {
    searchComics(1);
  }, []);

  // Metodo que hace la peticion
  function searchComics(newPage: number): void {
    setLoading(true);
    getPaginatedComics({ page: newPage, perPage: 20 }).then((res) => {
      setLoading(false);
      if (res.operation.code == EResponseCodes.OK) {
        setComics(res.data);
        setTotal(res.total ?? 0);
      } else {
        setMessage({
          type: res.operation.code,
          title: `Consultar Comics`,
          description: res.operation.message,
          onOk() {
            setMessage(null);
          },
        });
      }
    });
  }

  async function actionAddFavorite(comic: IComic): Promise<void> {
    if (!authorization.user) return;
    setAdding(comic.id);

    const res = await addFavorite({
      codeComic: comic.id,
      titule: comic.title,
      userId: authorization.user.id,
    });

    if (res.operation.code == EResponseCodes.OK) {
      setFavorites((prev) => {
        const updated = [...prev, res.data];
        return updated;
      });
    } else {
      setMessage({
        type: res.operation.code,
        title: `Agregar Favorito`,
        description: res.operation.message,
        onOk() {
          setMessage(null);
        },
      });
    }

    setAdding(null);
  }

  function showDetail(comic: IComic) {
    setMessage({
      title: comic.title,
      description: (
        <div className="max-h-[400px] overflow-y-auto border border-gray-300 p-4">
          
          
          <LabelComponent type="SubTitle" value={"Precios"} />

          <ul>
            {comic.prices?.map((i) => {
              return <li key={i.type}>{i.type} : ${i.price}</li>;
            })}
          </ul>

          <LabelComponent className="mt-4" type="SubTitle" value={"Personajes"} />
          <ul>
            {comic.characters.items.map((i) => {
              return <li key={i.name}>{i.name}</li>;
            })}
          </ul>
        </div>
      ),
      onOk() {
        setMessage(null);
      },
    });
  }

  return (
    <>
      <PageComponent>
        <Spin spinning={loading}>
          <PageComponent.ContentCard
            title="Marvel - Comics"
            headOptions={
              <Pagination
                align="end"
                defaultCurrent={page}
                total={total}
                pageSize={20}
                pageSizeOptions={[20]}
                onChange={(newPage) => {
                  setPage(newPage);
                  searchComics(newPage);
                }}
              />
            }
          >
            <div className="flex flex-wrap gap-5 text-center justify-center">
              {comics.map((comic: IComic) => (
                <div
                  key={comic.id}
                  className="relative w-60 h-96 rounded-lg overflow-hidden shadow-lg hover:shadow-xl hover:scale-105 transform transition cursor-pointer"
                >
                  <img
                    src={`${comic.thumbnail.path}.${comic.thumbnail.extension}`}
                    alt={comic.title}
                    className="absolute inset-0 w-full h-full object-cover"
                    onClick={() => showDetail(comic)}
                  />

                  {favorites.some((i) => i.codeComic == comic.id) ? (
                    <div className="absolute top-2 right-2 text-yellow-500">
                      <BsBookmarkStarFill size={32} />
                    </div>
                  ) : (
                    <ButtonComponent
                      className="absolute top-2 right-2"
                      value=""
                      loading={adding == comic.id}
                      icon={<MdOutlineBookmarkAdd size={32} />}
                      buttonStyle="Primary"
                      action={() => actionAddFavorite(comic)}
                      disabled={!authorization.user}
                    />
                  )}
                  <div className="absolute bottom-0 w-full bg-black bg-opacity-70 text-white text-center p-2">
                    <h3 className="text-sm font-semibold break-words">
                      {comic.title}
                    </h3>
                  </div>
                </div>
              ))}
            </div>
          </PageComponent.ContentCard>
        </Spin>
      </PageComponent>

      <ModalMessageComponent
        message={message}
        clearMessage={() => setMessage(null)}
      />
    </>
  );
}

export default HomePage;
