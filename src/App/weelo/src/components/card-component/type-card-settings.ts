export interface CardComponentConfiguration {
  cardHeader: CardHeaderComponent;
  cardMedia: CardMediaComponent;
  cardContent: string;
  sharedFunction: (id: string) => void;
  addFavoritesFunction: (id: string) => void;
}

export interface CardHeaderComponent {
  title: string;
  subheader: string;
}

export interface CardMediaComponent {
  title: string;
  image: string;
  width: number | string;
  hight: number | string;
}
