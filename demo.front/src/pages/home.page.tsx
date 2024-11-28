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

function HomePage(): JSX.Element {
  // Services
  const { getPaginatedComics } = useMarvelService();
  const { authorization } = useContext(AppContext);

  //States
  const [comics, setComics] = useState<IComic[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
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
                  />

                  <ButtonComponent
                    className="absolute top-2 right-2"
                    value=""
                    icon={<MdOutlineBookmarkAdd size={32} />}
                    buttonStyle="Primary"
                    disabled={!authorization.user}
                  />

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
