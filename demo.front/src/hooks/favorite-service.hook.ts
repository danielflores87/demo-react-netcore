import { ApiResponse } from "../helpers/api-response";
import { useApiService } from "../helpers/api-service";
import { IAddFavorite, IFavorite } from "../interfaces/favorite.interfaces";

export function useFavoriteService() {
  const apiURL = import.meta.env.VITE_URL_API ?? "";

  const basePath = "/api/favorites";
  const { post, get } = useApiService(apiURL);

  async function addFavorite(
    data: IAddFavorite
  ): Promise<ApiResponse<IFavorite>> {
    return await post(`${basePath}/add-favorite`, data);
  }

  async function getFavoritesByUserId(
    id: number
  ): Promise<ApiResponse<IFavorite[]>> {
    return await get(`${basePath}/get-by-user-id/${id}`);
  }

  return {
    addFavorite,
    getFavoritesByUserId,
  };
}

export default useFavoriteService;
