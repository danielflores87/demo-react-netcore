export interface IComic {
  id: number;
  title: string;
  thumbnail: {
    path: string;
    extension: string;
  };
  prices: {
    price: number;
  };
  characters: {
    items: {
      name: string;
      resourceURI: string;
    }[];
  };
}


export interface IComicFilter {
  title?: string;
  perPage: number;
  page: number;
}
