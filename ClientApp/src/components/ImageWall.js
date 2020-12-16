import React, { Component } from 'react';
import ImageList from './ImageList.js'

export class ImageWall extends Component {
  static displayName = ImageWall.name;

  constructor(props) {
    super(props);
      this.state = {
          images: [],
          loading: true
      };
  }

  componentDidMount() {
    this.fetchImageList();
  }

  renderImages = (images) => {
    return (
        <ImageList images={this.state.images} />
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderImages(this.state.images);

    return (
      <div>
        <h1 style={{ textAlign: "center", paddingTop: "20px" }}>Responsive Image wall</h1>
        <p style={{ textAlign: "center", paddingBottom: "15px" }}>Resize the browser window to see the responsive effect.</p>
        {contents}
      </div>
    );
  }

  async fetchImageList() {
      const response = await fetch('api/imagewall');
      const data = await response.json();
      this.setState({ images: data, loading: false });
  }
}