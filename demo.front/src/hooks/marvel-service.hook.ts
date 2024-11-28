import { ApiResponse } from "../helpers/api-response";
import { useApiService } from "../helpers/api-service";
import { IComic, IComicFilter } from "../interfaces/marvel.interfaces";

export function useMarvelService() {
  const apiURL = import.meta.env.VITE_URL_API ?? "";
  const userUrl = "/api/Marvel";
  const { post } = useApiService(apiURL);

  async function getPaginatedComics(
    filters: IComicFilter
  ): Promise<ApiResponse<IComic[]>> {
    const endpoint = "/get-paginated-comics";
    return post(`${userUrl}${endpoint}`, filters);
  }

  return {
    getPaginatedComics,
  };
}
