import { connect } from "react-redux";
import { Property } from "../../../models/property.model";
import { AppState } from "../../../store/root-reducer";
import { CardComponentConfiguration } from "../../../components/card-component/type-card-settings";
import CardComponent from "../../../components/card-component/card.properties.component";

const PropertyListPage = (props: Props) => {
  const { properties } = props;

  const addFavorites = (propertyId: string) => {

  };

  const sharedProperty = (propertyId: string) => {
    
  };

  return (
    <div>
      {properties.map((property) => {
        let configuration: CardComponentConfiguration = {
          cardMedia: {
            hight: property.propertyImage.height,
            width: property.propertyImage.width,
            image: property.propertyImage.file,
            title: property.codeInternal.toString(),
          },
          cardContent: property.name,
          cardHeader: {
            subheader: property.codeInternal.toString(),
            title: property.propertyTrace.name,
          },
          addFavoritesFunction: (propertyId: string) =>
            addFavorites(propertyId),
          sharedFunction: (propertyId) => sharedProperty(propertyId),
        };
        return <CardComponent key={property.id} cardComponentConfiguration={configuration} />;
      })}
    </div>
  );
};

const mapStateToProps = (state: AppState) => ({
  propertyState: state.property,
});

const mapDispatchToProps = {
};

type Props = {
  properties: Property[];
};

export default connect(mapStateToProps, mapDispatchToProps)(PropertyListPage);
