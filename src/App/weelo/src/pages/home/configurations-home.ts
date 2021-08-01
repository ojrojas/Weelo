import { CardComponentConfiguration } from "../../components/card-component/type-card-settings";
import image from '../../assets/rana.jpg'

export const AddFavorites = () => {
  console.log("favorites")
};
export const Shared = () => {
  console.log("sharedd.")
};

export const CardContentHomeConfiguration: CardComponentConfiguration = {
  cardHeader: {
    subheader:"PropertySubName",
    title:"PropertyName"
  },
  cardMedia: {
    image:image,
    title:"Carmedia nombre",
    hight: '100%',
    width: '100%'
  },
  addFavoritesFunction: AddFavorites,
  sharedFunction: Shared,
  cardContent: "dfasdfsdf asdfds fadsf asdfasdfasdfasdfasdf asdfas dfasdfasdfasd fasdfasd f  "
 };
