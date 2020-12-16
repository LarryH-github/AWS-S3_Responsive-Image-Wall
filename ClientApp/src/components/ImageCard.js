import React from 'react';

export default class ImageCard extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            rowSpan: 0
        };
        this.imageRef = React.createRef();
    }

    componentDidMount() {
        //Use the reference attached to the images to add an event listener to the image
        //Then run the callback function (setSpans) after the image has loaded (which is why we use "load" as first argument)
        this.imageRef.current.addEventListener("load", this.setSpan);
    }

    setSpan = () => {
        const height = this.imageRef.current.clientHeight;
        const rowSpan = Math.ceil(height / 10); //Measure the number of rows an image should span based on its height
                                                //We divide by 10 since that is the row height we set in our CSS (ImageList.css)
                                                //Using a smaller number like 10 instead of 200 gives much more fine control
        this.setState({ rowSpan: rowSpan });
    }

    render() {
        const { image, bucketRegion } = this.props;

        return (
            <div style={{ gridRowEnd: `span ${this.state.rowSpan}` }}> {/*Tell the 'div' how many rows to span*/}
                <img ref={this.imageRef} src={`https://${image.bucketName}.s3.${bucketRegion}.amazonaws.com/${image.key}`} />
            </div>
        );
    }
}