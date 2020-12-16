import React from 'react';
import ImageCard from './ImageCard.js';
import './ImageList.css';

const ImageList = (props) => {
    const images = props.images.map((image) => {
        const bucketRegion = "us-east-2";
        return <ImageCard key={image.key} image={image} bucketRegion={bucketRegion} />
    });

    return <div className="image-list">{images}</div>;
}
export default ImageList;
