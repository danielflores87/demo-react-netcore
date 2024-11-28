export interface IFavorite {
  id: number;
  userId: number;
  titule: string;
  codeComic: number;
  date: Date;
}

export interface IAddFavorite {
  userId: number;
  titule: string;
  codeComic: number;
}
