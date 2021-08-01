import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardMedia from "@material-ui/core/CardMedia";
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import IconButton from "@material-ui/core/IconButton";
import Typography from "@material-ui/core/Typography";
import { red } from "@material-ui/core/colors";
import FavoriteIcon from "@material-ui/icons/Favorite";
import ShareIcon from "@material-ui/icons/Share";
import MoreVertIcon from "@material-ui/icons/MoreVert";
import { CardComponentConfiguration } from "./type-card-settings";
import { Paper } from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
  root: {
    maxWidth: 345,
  },
  card_title: {
    fontSize: 6,
  },
  expand: {
    transform: "rotate(0deg)",
    marginLeft: "auto",
    transition: theme.transitions.create("transform", {
      duration: theme.transitions.duration.shortest,
    }),
  },
  expandOpen: {
    transform: "rotate(180deg)",
  },
  avatar: {
    backgroundColor: red[500],
  },
}));

type Props = {
  cardComponentConfiguration: CardComponentConfiguration;
};

export default function CardComponent(props: Props) {
  const {
    cardContent,
    sharedFunction,
    addFavoritesFunction,
    cardHeader,
    cardMedia,
  } = props.cardComponentConfiguration;
  const classes = useStyles();

  return (
   <Paper elevation={1}  style={{margin:5}} >
      <Card className={classes.root}>
      <CardHeader
        className={classes.card_title}
        action={
          <IconButton aria-label="settings">
            <MoreVertIcon />
          </IconButton>
        }
        title={cardHeader.title}
        subheader={cardHeader.subheader}
      />
      <CardMedia
        style={{ height: cardMedia.hight, width: cardMedia.width, paddingTop: '56.25%' }}
        image={cardMedia.image}
        title={cardMedia.title}
      />
      <CardContent>
        <Typography variant="body2" color="textSecondary" component="p">
          {cardContent}
        </Typography>
      </CardContent>
      <CardActions disableSpacing>
        <IconButton
          onClick={addFavoritesFunction}
          aria-label="add to favorites"
        >
          <FavoriteIcon />
        </IconButton>
        <IconButton onClick={sharedFunction} aria-label="share">
          <ShareIcon />
        </IconButton>
      </CardActions>
    </Card>
   </Paper>
  );
}
